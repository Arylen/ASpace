using System;
using System.Collections.Generic;
using System.Linq;
using Logger = ASpace.Core.Logging.Logger;

namespace ASpace.Core.Emulation.Components;

public static class OpTable
{
    private static Dictionary<byte, CpuOp>? _ops = null;
    private static Logger _logger = new (nameof(OpTable));
    
    private static void BuildOpTable()
    {
        _logger.Info("Building CPU Operation Table.");
        
        _ops = new();
        
        // Fill first layer with InvalidOp backing.
        for (byte i = 0; i < byte.MaxValue; i++)
            _ops[i] = new CpuOp($"BAD OP ${i:X2}", (_) => 1);

        // NOPs
        foreach (var idx in (byte[])[0x00, 0x10, 0x20, 0x30, 0x08, 0x18, 0x28, 0x38])
            _ops[idx] = new CpuOp("NOP", (_) => 4);

        // MVI {dest}, d8
        foreach (var op in new byte[] {
            0x06, 0x16, 0x26, 0x36,
            0x0E, 0x1E, 0x2E, 0x3E,
        }) 
        {
            var registers = Registers.GetEncodedRegs(op);
            var dest = registers.Destination;
            _ops[op] = new CpuOp(
                $"MVI {dest}, %d8",
                (cpu) =>
                {
                    // For moving a byte into mem at address {HL}
                    // MVI M, %d8
                    if (dest == Registers.Name.M)
                    {
                        cpu.Bus.WriteByte(cpu.Reg.HL, cpu.FetchByte());
                        return 10;
                    }
                    
                    // For other ops.
                    cpu.Reg.SetByName(dest, cpu.FetchByte());
                    return 7;
                }                
            );
        }
        
        // MOV ops
        foreach (var op in new byte[]
        {
            // 5-cycle Reg-to-Reg MOVs
            0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4F,
            0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x57, 0x58, 0x59, 0x5A, 0x5B, 0x5C, 0x5D, 0x5F,
            0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6F,
                                                      0x78, 0x79, 0x7A, 0x7B, 0x7C, 0x7D, 0x7F,
            // 7-cycle Reg-to-Mem MOVs
            0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x77,
            // 7-cycle Mem-to-Reg MOVs
            0x46, 0x56, 0x66, 0x4E, 0x5E, 0x6E, 0x7E, 
        })
        {
            var registers = Registers.GetEncodedRegs(op);
            var dest = registers.Destination;
            var src = registers.Source;
            _ops[op] = new CpuOp(
                $"MOV {dest}, {src}",
                (cpu) =>
                {
                    // Reg-to-reg MOVs
                    if (dest != Registers.Name.M && src != Registers.Name.M)
                    {
                        cpu.Reg.SetByName(dest, cpu.Reg.GetByName(src));
                        return 5;
                    }
                    
                    if (src == Registers.Name.M)
                        cpu.Reg.SetByName(dest, cpu.Bus.ReadByte(cpu.Reg.HL));
                    else
                        cpu.Bus.WriteByte(cpu.Reg.HL, cpu.Reg.GetByName(src));
                    
                    return 7;
                }
            );
        }
        
        // HLT
        _ops[0x76] = new CpuOp("HLT", (cpu) => { cpu.Halted = true; return 7; });
        
        // Calculate percentage of instructions that are "BAD OP" just to get a percentage of implemented instructions.
        var missingOpcodes = new List<byte>();
        for (byte i = 0; i < byte.MaxValue; i++)
        {
            if (_ops[i].DasmTemplate.StartsWith("BAD OP"))
            {
                missingOpcodes.Add(i);
            }
        }
        var percentageImplemented = (100f - (missingOpcodes.Count / (float)_ops.Count) * 100f);
        _logger.Info($"Table coverage: (Total={_ops.Count} Unimplemented={missingOpcodes.Count} Percentage={percentageImplemented:F2})");
        _logger.Info($"Missing opcodes: {string.Join(", ", missingOpcodes.Select(op => $"{op:X2}"))}");
    }
    
    public static CpuOp Get(byte opcode)
    {
        if (_ops == null)
            BuildOpTable();
        return _ops![opcode];
    }
}
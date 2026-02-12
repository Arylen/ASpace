using System;
using ASpace.Core.Logging;

namespace ASpace.Core.Emulation.Components;

public class CpuOp(string dasmTemplate, Func<CPU, int> handler)
{
    private static Logger _logger = new(nameof(CpuOp));
    
    public string DasmTemplate { get; init; } = dasmTemplate;
    public Func<CPU, int> Handler { get; init; } = handler;

    public string BuildMnemonic(CPU cpu, ushort address)
    {
        try
        {
            var bytes = new[]
            {
                cpu.Bus.ReadByte(address),
                cpu.Bus.ReadByte((ushort)(address + 1)),
                cpu.Bus.ReadByte((ushort)(address + 2)),
            };

            var d8 = $"${bytes[1]:X2}";
            var d16 = $"${((bytes[2] << 8) | bytes[1]): X4}";

            return DasmTemplate
                .Replace("{d16}", d16)
                .Replace("{a16}", d16)
                .Replace("{d8}", d8);
        }
        catch (Exception e)
        {
            _logger.Error($"Failed to build instruction mnemonic. {e.Message}");
            return "EXCEPTION";
        }
    }
}
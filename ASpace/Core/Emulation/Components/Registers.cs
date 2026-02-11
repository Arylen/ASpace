using System;

namespace ASpace.Core.Emulation.Components;

public class Registers
{
    public enum Name
    {
        B = 0b000,
        C = 0b001,
        D = 0b010,
        E = 0b011,
        H = 0b100,
        L = 0b101,
        M = 0b110,
        A = 0b111,
    }

    public struct EncodedRegisters
    {
        public Name Source { get; set; }
        public Name Destination { get; set; }
    }
    
    public ushort PC, SP;
    public byte A, B, C, D, E, H, L;

    public Flags Flags = new ();

    public ushort BC { get => GetPair(B, C); set => SetPair(value, ref B, ref C); }
    public ushort DE { get => GetPair(D, E); set => SetPair(value, ref D, ref E); }
    public ushort HL { get => GetPair(H, L); set => SetPair(value, ref H, ref L); }

    public ushort PSW
    {
        get => GetPair(A, Flags.Value);
        set
        {
            A = (byte)(value >> 8);
            Flags.Value = (byte)value;
        }
    }
    
    private ushort GetPair(byte hi, byte lo) => (ushort)((hi << 8) | lo);
    private void SetPair(ushort v, ref byte hi, ref byte lo)
    {
        hi = (byte)(v >> 8);
        lo = (byte)v;
    }

    public byte GetByName(Name name)
    {
        return name switch
        {
            Name.A => A,
            Name.B => B,
            Name.C => C,
            Name.D => D,
            Name.E => E,
            Name.H => H,
            Name.L => L,
            Name.M => throw new ArgumentOutOfRangeException(nameof(name), "Cannot get M register by name."),
            _ => throw new NotImplementedException("Attempted to get register.")
        };
    }
    
    public void SetByName(Name name, byte value)
    {
        switch (name)
        {
            case Name.A: A = value; return;
            case Name.B: B = value; return;
            case Name.C: C = value; return;
            case Name.D: D = value; return;
            case Name.E: E = value; return;
            case Name.H: H = value; return;
            case Name.L: L = value; return;
            case Name.M: throw new ArgumentOutOfRangeException(nameof(name), "Cannot set M register by name.");
            default: throw new NotImplementedException("Attempted to set unknown register.");
        };
    }

    public static EncodedRegisters GetEncodedRegs(byte value)
    {
        const byte destMask = 0b00111000;
        const byte sourceMask = 0b00000111;

        var dest = (Name)((value & destMask) >> 3);
        var source = (Name)(value & sourceMask);
        
        return new EncodedRegisters
        {
            Source = source,
            Destination = dest,
        };
    }
}
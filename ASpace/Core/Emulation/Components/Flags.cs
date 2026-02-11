using ASpace.Core.Extensions;

namespace ASpace.Core.Emulation.Components;

public class Flags
{
    private enum FlagBit
    {
        Carry    = 0,
        Bit1     = 1,
        Parity   = 2,
        Bit3     = 3,
        AuxCarry = 4,
        Bit5     = 5,
        Zero     = 6,
        Sign     = 7,
    }
    
    public byte Value
    {
        get
        {
            byte value = 0;
            value = value.WithBit((byte)FlagBit.Carry, Carry)
                .WithBit((byte)FlagBit.Bit1, true)
                .WithBit((byte)FlagBit.Parity, Parity)
                .WithBit((byte)FlagBit.Bit3, false)
                .WithBit((byte)FlagBit.AuxCarry, AuxCarry)
                .WithBit((byte)FlagBit.Bit5, false)
                .WithBit((byte)FlagBit.Zero, Zero)
                .WithBit((byte)FlagBit.Sign, Sign);
            return value;
        }
        set
        {
            Carry = value.GetBit((byte)FlagBit.Carry);
            Parity = value.GetBit((byte)FlagBit.Parity);
            AuxCarry = value.GetBit((byte)FlagBit.AuxCarry);
            Zero = value.GetBit((byte)FlagBit.Zero);
            Sign = value.GetBit((byte)FlagBit.Sign);
        }
    }

    public bool Carry { get; set; }
    public bool Parity { get; set; }
    public bool AuxCarry { get; set; }
    public bool Zero { get; set; }
    public bool Sign { get; set; }
}
using ASpace.Core.Emulation.Components;

namespace ASpace.Test;

[TestFixture]
public class FlagsTests
{
    private Flags _flags;
    
    [SetUp]
    public void SetUp()
    {
        _flags = new Flags();
    }
    
    [Test]
    public void Value_AllFlagsClear_Bit1IsSet()
    {
        // Bit 1 is always 1, so minimum value is 0x02
        Assert.That(_flags.Value, Is.EqualTo(0b00000010));
    }
    
    [Test]
    public void Value_CarrySet_ReturnsCorrectValue()
    {
        _flags.Carry = true;
        
        Assert.That(_flags.Value, Is.EqualTo(0b00000011));
    }
    
    [Test]
    public void Value_ParitySet_ReturnsCorrectValue()
    {
        _flags.Parity = true;
        
        Assert.That(_flags.Value, Is.EqualTo(0b00000110));
    }
    
    [Test]
    public void Value_AuxCarrySet_ReturnsCorrectValue()
    {
        _flags.AuxCarry = true;
        
        Assert.That(_flags.Value, Is.EqualTo(0b00010010));
    }
    
    [Test]
    public void Value_ZeroSet_ReturnsCorrectValue()
    {
        _flags.Zero = true;
        
        Assert.That(_flags.Value, Is.EqualTo(0b01000010));
    }
    
    [Test]
    public void Value_SignSet_ReturnsCorrectValue()
    {
        _flags.Sign = true;
        
        Assert.That(_flags.Value, Is.EqualTo(0b10000010));
    }
    
    [Test]
    public void Value_AllFlagsSet_ReturnsCorrectValue()
    {
        _flags.Carry = true;
        _flags.Parity = true;
        _flags.AuxCarry = true;
        _flags.Zero = true;
        _flags.Sign = true;
        
        // 0b11010111 = 0xD7
        Assert.That(_flags.Value, Is.EqualTo(0b11010111));
    }
    
    [Test]
    public void Value_Bit3And5_AlwaysClear()
    {
        _flags.Carry = true;
        _flags.Parity = true;
        _flags.AuxCarry = true;
        _flags.Zero = true;
        _flags.Sign = true;
        
        // Bits 3 and 5 should always be 0
        Assert.That(_flags.Value & 0b00001000, Is.EqualTo(0));
        Assert.That(_flags.Value & 0b00100000, Is.EqualTo(0));
    }
    
    [Test]
    public void Value_Bit1_AlwaysSet()
    {
        Assert.That(_flags.Value & 0b00000010, Is.EqualTo(0b00000010));
        
        _flags.Carry = true;
        _flags.Sign = true;
        
        Assert.That(_flags.Value & 0b00000010, Is.EqualTo(0b00000010));
    }
    
    // Tests for the setter (if you add it)
    
    [Test]
    public void ValueSetter_AllBitsSet_SetsCorrectFlags()
    {
        _flags.Value = 0b11010111;
        
        Assert.That(_flags.Sign, Is.True);
        Assert.That(_flags.Zero, Is.True);
        Assert.That(_flags.AuxCarry, Is.True);
        Assert.That(_flags.Parity, Is.True);
        Assert.That(_flags.Carry, Is.True);
    }
    
    [Test]
    public void ValueSetter_AllBitsClear_ClearsFlags()
    {
        _flags.Sign = true;
        _flags.Zero = true;
        _flags.AuxCarry = true;
        _flags.Parity = true;
        _flags.Carry = true;
        
        _flags.Value = 0x00;
        
        Assert.That(_flags.Sign, Is.False);
        Assert.That(_flags.Zero, Is.False);
        Assert.That(_flags.AuxCarry, Is.False);
        Assert.That(_flags.Parity, Is.False);
        Assert.That(_flags.Carry, Is.False);
    }
    
    [Test]
    public void ValueSetter_IgnoresReservedBits()
    {
        // Even if we set bits 1, 3, and 5 in the input,
        // it shouldn't affect anything other than the flags
        _flags.Value = 0xFF;
        
        Assert.That(_flags.Sign, Is.True);
        Assert.That(_flags.Zero, Is.True);
        Assert.That(_flags.AuxCarry, Is.True);
        Assert.That(_flags.Parity, Is.True);
        Assert.That(_flags.Carry, Is.True);
        
        // And when we read it back, reserved bits are correct
        Assert.That(_flags.Value, Is.EqualTo(0b11010111));
    }
    
    [Test]
    public void ValueSetter_OnlyCarry_SetsOnlyCarry()
    {
        _flags.Value = 0b00000001;
        
        Assert.That(_flags.Carry, Is.True);
        Assert.That(_flags.Parity, Is.False);
        Assert.That(_flags.AuxCarry, Is.False);
        Assert.That(_flags.Zero, Is.False);
        Assert.That(_flags.Sign, Is.False);
    }
    
    [Test]
    [TestCase(0b00000001, true, false, false, false, false)]
    [TestCase(0b00000100, false, true, false, false, false)]
    [TestCase(0b00010000, false, false, true, false, false)]
    [TestCase(0b01000000, false, false, false, true, false)]
    [TestCase(0b10000000, false, false, false, false, true)]
    public void ValueSetter_IndividualFlags_SetCorrectly(
        byte input, bool carry, bool parity, bool auxCarry, bool zero, bool sign)
    {
        _flags.Value = input;
        
        Assert.That(_flags.Carry, Is.EqualTo(carry));
        Assert.That(_flags.Parity, Is.EqualTo(parity));
        Assert.That(_flags.AuxCarry, Is.EqualTo(auxCarry));
        Assert.That(_flags.Zero, Is.EqualTo(zero));
        Assert.That(_flags.Sign, Is.EqualTo(sign));
    }
    
    [Test]
    public void RoundTrip_SetFlagsThenRead_ReturnsConsistentValue()
    {
        _flags.Carry = true;
        _flags.Zero = true;
        
        byte value = _flags.Value;
        _flags.Value = value;
        
        Assert.That(_flags.Carry, Is.True);
        Assert.That(_flags.Zero, Is.True);
        Assert.That(_flags.Parity, Is.False);
        Assert.That(_flags.AuxCarry, Is.False);
        Assert.That(_flags.Sign, Is.False);
    }
}
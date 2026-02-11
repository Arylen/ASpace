using ASpace.Core.Extensions;

namespace ASpace.Test;

[TestFixture]
public class BitExtensionsTest
{
    [Test]
    public void SetBit_SetSingleBit_BitIsSet()
    {
        byte b = 0b00000000;
        b = b.WithBit(3, true);
        Assert.That(b, Is.EqualTo(0b00001000));
    }
    
    [Test]
    public void SetBit_ClearSingleBit_BitIsCleared()
    {
        byte b = 0b11111111;
        b = b.WithBit(3, false);
        Assert.That(b, Is.EqualTo(0b11110111));
    }
    
    [Test]
    public void SetBit_SetAlreadySetBit_RemainsSet()
    {
        byte b = 0b00001000;
        b = b.WithBit(3, true);
        Assert.That(b, Is.EqualTo(0b00001000));
    }
    
    [Test]
    public void SetBit_ClearAlreadyClearedBit_RemainsClear()
    {
        byte b = 0b00000000;
        b = b.WithBit(3, false);
        Assert.That(b, Is.EqualTo(0b00000000));
    }
    
    [Test]
    public void SetBit_SetBit0_Works()
    {
        byte b = 0b00000000;
        b = b.WithBit(0, true);
        Assert.That(b, Is.EqualTo(0b00000001));
    }
    
    [Test]
    public void SetBit_SetBit7_Works()
    {
        byte b = 0b00000000;
        b = b.WithBit(7, true);
        Assert.That(b, Is.EqualTo(0b10000000));
    }
    
    [Test]
    public void SetBit_PreservesOtherBits_WhenSetting()
    {
        byte b = 0b10100101;
        b = b.WithBit(3, true);
        Assert.That(b, Is.EqualTo(0b10101101));
    }
    
    [Test]
    public void SetBit_PreservesOtherBits_WhenClearing()
    {
        byte b = 0b10101101;
        b = b.WithBit(3, false);
        Assert.That(b, Is.EqualTo(0b10100101));
    }
    
    [Test]
    public void SetBit_BitIndexTooHigh_ThrowsException()
    {
        byte b = 0b00000000;
        Assert.Throws<ArgumentOutOfRangeException>(() => b.WithBit(8, true));
    }
    
    [Test]
    [TestCase(0, true, 0b00000001)]
    [TestCase(1, true, 0b00000010)]
    [TestCase(2, true, 0b00000100)]
    [TestCase(3, true, 0b00001000)]
    [TestCase(4, true, 0b00010000)]
    [TestCase(5, true, 0b00100000)]
    [TestCase(6, true, 0b01000000)]
    [TestCase(7, true, 0b10000000)]
    public void SetBit_AllBitPositions_WorkCorrectly(byte bit, bool value, byte expected)
    {
        byte b = 0b00000000;
        b = b.WithBit(bit, value);
        Assert.That(b, Is.EqualTo(expected));
    }
}
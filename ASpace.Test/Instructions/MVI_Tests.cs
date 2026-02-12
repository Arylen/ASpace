using ASpace.Core.Emulation;

namespace ASpace.Test.Instructions;

[TestFixture]
public class MVI_Tests
{
    private VM _vm;
    
    [SetUp]
    public void Setup()
    {
        _vm = new();
    }

    [Test]
    public void MVI_B_D8__06()
    {
        Assert.That(_vm.CPU.Reg.B, Is.EqualTo(0x00));
        _vm.LoadRom([0x06, 0x12]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.B, Is.EqualTo(0x12));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MVI_C_D8__0E()
    {
        Assert.That(_vm.CPU.Reg.C, Is.EqualTo(0x00));
        _vm.LoadRom([0x0E, 0x34]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.C, Is.EqualTo(0x34));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MVI_D_D8__16()
    {
        Assert.That(_vm.CPU.Reg.D, Is.EqualTo(0x00));
        _vm.LoadRom([0x16, 0x56]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.D, Is.EqualTo(0x56));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MVI_E_D8__1E()
    {
        Assert.That(_vm.CPU.Reg.E, Is.EqualTo(0x00));
        _vm.LoadRom([0x1E, 0x78]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.E, Is.EqualTo(0x78));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MVI_H_D8__26()
    {
        Assert.That(_vm.CPU.Reg.H, Is.EqualTo(0x00));
        _vm.LoadRom([0x26, 0x9A]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.H, Is.EqualTo(0x9A));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MVI_L_D8__2E()
    {
        Assert.That(_vm.CPU.Reg.L, Is.EqualTo(0x00));
        _vm.LoadRom([0x2E, 0xBC]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.L, Is.EqualTo(0xBC));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MVI_A_D8__3E()
    {
        Assert.That(_vm.CPU.Reg.A, Is.EqualTo(0x00));
        _vm.LoadRom([0x3E, 0xDE]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.A, Is.EqualTo(0xDE));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MVI_M_D8__36()
    {
        _vm.CPU.Reg.HL = 0x2000;
        Assert.That(_vm.Bus.ReadByte(0x2000), Is.EqualTo(0x00));
        _vm.LoadRom([0x36, 0x42]);
        _vm.Step();
        Assert.That(_vm.Bus.ReadByte(0x2000), Is.EqualTo(0x42));
        Assert.That(_vm.CycleCount, Is.EqualTo(10));
    }
}
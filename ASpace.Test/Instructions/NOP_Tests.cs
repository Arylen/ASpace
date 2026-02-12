using ASpace.Core.Emulation;

namespace ASpace.Test.Instructions;

[TestFixture]
public class NOP_Tests
{
    private VM _vm;

    [SetUp]
    public void Setup()
    {
        _vm = new VM();
    }

    [Test]
    public void NOP__00()
    {
        _vm.LoadRom([0x00]);
        _vm.Step();
        Assert.That(_vm.CycleCount, Is.EqualTo(4));
    }
    
    [Test]
    public void NOP__10()
    {
        _vm.LoadRom([0x10]);
        _vm.Step();
        Assert.That(_vm.CycleCount, Is.EqualTo(4));
    }
    
    [Test]
    public void NOP__20()
    {
        _vm.LoadRom([0x20]);
        _vm.Step();
        Assert.That(_vm.CycleCount, Is.EqualTo(4));
    }
    
    [Test]
    public void NOP__30()
    {
        _vm.LoadRom([0x30]);
        _vm.Step();
        Assert.That(_vm.CycleCount, Is.EqualTo(4));
    }
    
    [Test]
    public void NOP__08()
    {
        _vm.LoadRom([0x08]);
        _vm.Step();
        Assert.That(_vm.CycleCount, Is.EqualTo(4));
    }
    
    [Test]
    public void NOP__18()
    {
        _vm.LoadRom([0x18]);
        _vm.Step();
        Assert.That(_vm.CycleCount, Is.EqualTo(4));
    }
    
    [Test]
    public void NOP__28()
    {
        _vm.LoadRom([0x28]);
        _vm.Step();
        Assert.That(_vm.CycleCount, Is.EqualTo(4));
    }
    
    [Test]
    public void NOP__38()
    {
        _vm.LoadRom([0x38]);
        _vm.Step();
        Assert.That(_vm.CycleCount, Is.EqualTo(4));
    }
}
using ASpace.Core.Emulation;

namespace ASpace.Test.Instructions;

[TestFixture]
public class MOV_Tests
{
    private VM _vm;
    
    [SetUp]
    public void Setup()
    {
        _vm = new();
    }

    // Reg-to-Reg MOVs (5 cycles)

    [Test]
    public void MOV_B_B__40()
    {
        _vm.CPU.Reg.B = 0x12;
        _vm.LoadRom([0x40]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.B, Is.EqualTo(0x12));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_B_C__41()
    {
        _vm.CPU.Reg.C = 0x34;
        _vm.LoadRom([0x41]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.B, Is.EqualTo(0x34));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_B_D__42()
    {
        _vm.CPU.Reg.D = 0x56;
        _vm.LoadRom([0x42]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.B, Is.EqualTo(0x56));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_B_E__43()
    {
        _vm.CPU.Reg.E = 0x78;
        _vm.LoadRom([0x43]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.B, Is.EqualTo(0x78));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_B_H__44()
    {
        _vm.CPU.Reg.H = 0x9A;
        _vm.LoadRom([0x44]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.B, Is.EqualTo(0x9A));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_B_L__45()
    {
        _vm.CPU.Reg.L = 0xBC;
        _vm.LoadRom([0x45]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.B, Is.EqualTo(0xBC));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_B_A__47()
    {
        _vm.CPU.Reg.A = 0xDE;
        _vm.LoadRom([0x47]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.B, Is.EqualTo(0xDE));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_C_B__48()
    {
        _vm.CPU.Reg.B = 0x12;
        _vm.LoadRom([0x48]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.C, Is.EqualTo(0x12));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_C_C__49()
    {
        _vm.CPU.Reg.C = 0x34;
        _vm.LoadRom([0x49]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.C, Is.EqualTo(0x34));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_C_D__4A()
    {
        _vm.CPU.Reg.D = 0x56;
        _vm.LoadRom([0x4A]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.C, Is.EqualTo(0x56));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_C_E__4B()
    {
        _vm.CPU.Reg.E = 0x78;
        _vm.LoadRom([0x4B]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.C, Is.EqualTo(0x78));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_C_H__4C()
    {
        _vm.CPU.Reg.H = 0x9A;
        _vm.LoadRom([0x4C]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.C, Is.EqualTo(0x9A));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_C_L__4D()
    {
        _vm.CPU.Reg.L = 0xBC;
        _vm.LoadRom([0x4D]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.C, Is.EqualTo(0xBC));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_C_A__4F()
    {
        _vm.CPU.Reg.A = 0xDE;
        _vm.LoadRom([0x4F]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.C, Is.EqualTo(0xDE));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_D_B__50()
    {
        _vm.CPU.Reg.B = 0x12;
        _vm.LoadRom([0x50]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.D, Is.EqualTo(0x12));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_D_C__51()
    {
        _vm.CPU.Reg.C = 0x34;
        _vm.LoadRom([0x51]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.D, Is.EqualTo(0x34));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_D_D__52()
    {
        _vm.CPU.Reg.D = 0x56;
        _vm.LoadRom([0x52]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.D, Is.EqualTo(0x56));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_D_E__53()
    {
        _vm.CPU.Reg.E = 0x78;
        _vm.LoadRom([0x53]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.D, Is.EqualTo(0x78));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_D_H__54()
    {
        _vm.CPU.Reg.H = 0x9A;
        _vm.LoadRom([0x54]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.D, Is.EqualTo(0x9A));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_D_L__55()
    {
        _vm.CPU.Reg.L = 0xBC;
        _vm.LoadRom([0x55]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.D, Is.EqualTo(0xBC));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_D_A__57()
    {
        _vm.CPU.Reg.A = 0xDE;
        _vm.LoadRom([0x57]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.D, Is.EqualTo(0xDE));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_E_B__58()
    {
        _vm.CPU.Reg.B = 0x12;
        _vm.LoadRom([0x58]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.E, Is.EqualTo(0x12));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_E_C__59()
    {
        _vm.CPU.Reg.C = 0x34;
        _vm.LoadRom([0x59]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.E, Is.EqualTo(0x34));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_E_D__5A()
    {
        _vm.CPU.Reg.D = 0x56;
        _vm.LoadRom([0x5A]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.E, Is.EqualTo(0x56));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_E_E__5B()
    {
        _vm.CPU.Reg.E = 0x78;
        _vm.LoadRom([0x5B]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.E, Is.EqualTo(0x78));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_E_H__5C()
    {
        _vm.CPU.Reg.H = 0x9A;
        _vm.LoadRom([0x5C]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.E, Is.EqualTo(0x9A));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_E_L__5D()
    {
        _vm.CPU.Reg.L = 0xBC;
        _vm.LoadRom([0x5D]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.E, Is.EqualTo(0xBC));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_E_A__5F()
    {
        _vm.CPU.Reg.A = 0xDE;
        _vm.LoadRom([0x5F]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.E, Is.EqualTo(0xDE));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_H_B__60()
    {
        _vm.CPU.Reg.B = 0x12;
        _vm.LoadRom([0x60]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.H, Is.EqualTo(0x12));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_H_C__61()
    {
        _vm.CPU.Reg.C = 0x34;
        _vm.LoadRom([0x61]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.H, Is.EqualTo(0x34));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_H_D__62()
    {
        _vm.CPU.Reg.D = 0x56;
        _vm.LoadRom([0x62]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.H, Is.EqualTo(0x56));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_H_E__63()
    {
        _vm.CPU.Reg.E = 0x78;
        _vm.LoadRom([0x63]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.H, Is.EqualTo(0x78));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_H_H__64()
    {
        _vm.CPU.Reg.H = 0x9A;
        _vm.LoadRom([0x64]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.H, Is.EqualTo(0x9A));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_H_L__65()
    {
        _vm.CPU.Reg.L = 0xBC;
        _vm.LoadRom([0x65]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.H, Is.EqualTo(0xBC));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_H_A__67()
    {
        _vm.CPU.Reg.A = 0xDE;
        _vm.LoadRom([0x67]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.H, Is.EqualTo(0xDE));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_L_B__68()
    {
        _vm.CPU.Reg.B = 0x12;
        _vm.LoadRom([0x68]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.L, Is.EqualTo(0x12));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_L_C__69()
    {
        _vm.CPU.Reg.C = 0x34;
        _vm.LoadRom([0x69]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.L, Is.EqualTo(0x34));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_L_D__6A()
    {
        _vm.CPU.Reg.D = 0x56;
        _vm.LoadRom([0x6A]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.L, Is.EqualTo(0x56));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_L_E__6B()
    {
        _vm.CPU.Reg.E = 0x78;
        _vm.LoadRom([0x6B]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.L, Is.EqualTo(0x78));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_L_H__6C()
    {
        _vm.CPU.Reg.H = 0x9A;
        _vm.LoadRom([0x6C]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.L, Is.EqualTo(0x9A));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_L_L__6D()
    {
        _vm.CPU.Reg.L = 0xBC;
        _vm.LoadRom([0x6D]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.L, Is.EqualTo(0xBC));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_L_A__6F()
    {
        _vm.CPU.Reg.A = 0xDE;
        _vm.LoadRom([0x6F]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.L, Is.EqualTo(0xDE));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_A_B__78()
    {
        _vm.CPU.Reg.B = 0x12;
        _vm.LoadRom([0x78]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.A, Is.EqualTo(0x12));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_A_C__79()
    {
        _vm.CPU.Reg.C = 0x34;
        _vm.LoadRom([0x79]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.A, Is.EqualTo(0x34));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_A_D__7A()
    {
        _vm.CPU.Reg.D = 0x56;
        _vm.LoadRom([0x7A]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.A, Is.EqualTo(0x56));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_A_E__7B()
    {
        _vm.CPU.Reg.E = 0x78;
        _vm.LoadRom([0x7B]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.A, Is.EqualTo(0x78));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_A_H__7C()
    {
        _vm.CPU.Reg.H = 0x9A;
        _vm.LoadRom([0x7C]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.A, Is.EqualTo(0x9A));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_A_L__7D()
    {
        _vm.CPU.Reg.L = 0xBC;
        _vm.LoadRom([0x7D]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.A, Is.EqualTo(0xBC));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    [Test]
    public void MOV_A_A__7F()
    {
        _vm.CPU.Reg.A = 0xDE;
        _vm.LoadRom([0x7F]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.A, Is.EqualTo(0xDE));
        Assert.That(_vm.CycleCount, Is.EqualTo(5));
    }

    // Reg-to-Mem MOVs (7 cycles)

    [Test]
    public void MOV_M_B__70()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.CPU.Reg.B = 0x12;
        _vm.LoadRom([0x70]);
        _vm.Step();
        Assert.That(_vm.Bus.ReadByte(0x2000), Is.EqualTo(0x12));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_M_C__71()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.CPU.Reg.C = 0x34;
        _vm.LoadRom([0x71]);
        _vm.Step();
        Assert.That(_vm.Bus.ReadByte(0x2000), Is.EqualTo(0x34));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_M_D__72()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.CPU.Reg.D = 0x56;
        _vm.LoadRom([0x72]);
        _vm.Step();
        Assert.That(_vm.Bus.ReadByte(0x2000), Is.EqualTo(0x56));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_M_E__73()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.CPU.Reg.E = 0x78;
        _vm.LoadRom([0x73]);
        _vm.Step();
        Assert.That(_vm.Bus.ReadByte(0x2000), Is.EqualTo(0x78));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_M_H__74()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.LoadRom([0x74]);
        _vm.Step();
        Assert.That(_vm.Bus.ReadByte(0x2000), Is.EqualTo(0x20));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_M_L__75()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.LoadRom([0x75]);
        _vm.Step();
        Assert.That(_vm.Bus.ReadByte(0x2000), Is.EqualTo(0x00));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_M_A__77()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.CPU.Reg.A = 0xDE;
        _vm.LoadRom([0x77]);
        _vm.Step();
        Assert.That(_vm.Bus.ReadByte(0x2000), Is.EqualTo(0xDE));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    // Mem-to-Reg MOVs (7 cycles)

    [Test]
    public void MOV_B_M__46()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.Bus.WriteByte(0x2000, 0x12);
        _vm.LoadRom([0x46]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.B, Is.EqualTo(0x12));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_C_M__4E()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.Bus.WriteByte(0x2000, 0x34);
        _vm.LoadRom([0x4E]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.C, Is.EqualTo(0x34));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_D_M__56()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.Bus.WriteByte(0x2000, 0x56);
        _vm.LoadRom([0x56]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.D, Is.EqualTo(0x56));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_E_M__5E()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.Bus.WriteByte(0x2000, 0x78);
        _vm.LoadRom([0x5E]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.E, Is.EqualTo(0x78));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_H_M__66()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.Bus.WriteByte(0x2000, 0x9A);
        _vm.LoadRom([0x66]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.H, Is.EqualTo(0x9A));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_L_M__6E()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.Bus.WriteByte(0x2000, 0xBC);
        _vm.LoadRom([0x6E]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.L, Is.EqualTo(0xBC));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }

    [Test]
    public void MOV_A_M__7E()
    {
        _vm.CPU.Reg.HL = 0x2000;
        _vm.Bus.WriteByte(0x2000, 0xDE);
        _vm.LoadRom([0x7E]);
        _vm.Step();
        Assert.That(_vm.CPU.Reg.A, Is.EqualTo(0xDE));
        Assert.That(_vm.CycleCount, Is.EqualTo(7));
    }
}
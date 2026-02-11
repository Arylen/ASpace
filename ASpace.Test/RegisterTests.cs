using ASpace.Core.Emulation.Components;

namespace ASpace.Test;

[TestFixture]
public class RegistersTests
{
    private Registers _registers;
    
    [SetUp]
    public void SetUp()
    {
        _registers = new Registers();
    }
    
    [Test]
    public void BC_Get_CombinesBAndC()
    {
        _registers.B = 0x12;
        _registers.C = 0x34;
        
        Assert.That(_registers.BC, Is.EqualTo(0x1234));
    }
    
    [Test]
    public void BC_Set_SplitsIntoBAndC()
    {
        _registers.BC = 0xABCD;
        
        Assert.That(_registers.B, Is.EqualTo(0xAB));
        Assert.That(_registers.C, Is.EqualTo(0xCD));
    }
    
    [Test]
    public void BC_SetZero_ClearsBothRegisters()
    {
        _registers.B = 0xFF;
        _registers.C = 0xFF;
        
        _registers.BC = 0x0000;
        
        Assert.That(_registers.B, Is.EqualTo(0x00));
        Assert.That(_registers.C, Is.EqualTo(0x00));
    }
    
    [Test]
    public void BC_SetMax_SetsBothRegistersToMax()
    {
        _registers.BC = 0xFFFF;
        
        Assert.That(_registers.B, Is.EqualTo(0xFF));
        Assert.That(_registers.C, Is.EqualTo(0xFF));
    }
    
    [Test]
    public void DE_Get_CombinesDAndE()
    {
        _registers.D = 0x56;
        _registers.E = 0x78;
        
        Assert.That(_registers.DE, Is.EqualTo(0x5678));
    }
    
    [Test]
    public void DE_Set_SplitsIntoDAndE()
    {
        _registers.DE = 0xBEEF;
        
        Assert.That(_registers.D, Is.EqualTo(0xBE));
        Assert.That(_registers.E, Is.EqualTo(0xEF));
    }
    
    [Test]
    public void HL_Get_CombinesHAndL()
    {
        _registers.H = 0x9A;
        _registers.L = 0xBC;
        
        Assert.That(_registers.HL, Is.EqualTo(0x9ABC));
    }
    
    [Test]
    public void HL_Set_SplitsIntoHAndL()
    {
        _registers.HL = 0xCAFE;
        
        Assert.That(_registers.H, Is.EqualTo(0xCA));
        Assert.That(_registers.L, Is.EqualTo(0xFE));
    }
    
    [Test]
    public void PSW_Get_CombinesAAndFlags()
    {
        _registers.A = 0x42;
        _registers.Flags.Carry = true;
        _registers.Flags.Zero = true;
        
        Assert.That(_registers.PSW, Is.EqualTo(0x4243));
    }
    
    [Test]
    public void PSW_Set_SplitsIntoAAndFlags()
    {
        _registers.PSW = 0xFF57;
        
        Assert.That(_registers.A, Is.EqualTo(0xFF));
        Assert.That(_registers.Flags.Sign, Is.False);
        Assert.That(_registers.Flags.Zero, Is.True);
        Assert.That(_registers.Flags.AuxCarry, Is.True);
        Assert.That(_registers.Flags.Parity, Is.True);
        Assert.That(_registers.Flags.Carry, Is.True);
    }
    
    [Test]
    public void RegisterPairs_AreIndependent()
    {
        _registers.BC = 0x1111;
        _registers.DE = 0x2222;
        _registers.HL = 0x3333;
        
        Assert.That(_registers.BC, Is.EqualTo(0x1111));
        Assert.That(_registers.DE, Is.EqualTo(0x2222));
        Assert.That(_registers.HL, Is.EqualTo(0x3333));
    }
    
    [Test]
    public void SettingRegisterPair_DoesNotAffectOthers()
    {
        _registers.BC = 0xAAAA;
        _registers.DE = 0xBBBB;
        _registers.HL = 0xCCCC;
        
        _registers.BC = 0x0000;
        
        Assert.That(_registers.DE, Is.EqualTo(0xBBBB));
        Assert.That(_registers.HL, Is.EqualTo(0xCCCC));
    }
    
    [Test]
    public void RegisterPair_RoundTrip_PreservesValue()
    {
        ushort[] testValues = { 0x0000, 0xFFFF, 0x00FF, 0xFF00, 0x1234, 0xABCD };
        
        foreach (var value in testValues)
        {
            _registers.BC = value;
            Assert.That(_registers.BC, Is.EqualTo(value));
            
            _registers.DE = value;
            Assert.That(_registers.DE, Is.EqualTo(value));
            
            _registers.HL = value;
            Assert.That(_registers.HL, Is.EqualTo(value));
        }
    }
    
    [Test]
    public void IndividualRegister_HighByte_DoesNotAffectLowByte()
    {
        _registers.B = 0x12;
        _registers.C = 0x34;
        
        _registers.B = 0xFF;
        
        Assert.That(_registers.C, Is.EqualTo(0x34));
    }
    
    [Test]
    public void IndividualRegister_LowByte_DoesNotAffectHighByte()
    {
        _registers.B = 0x12;
        _registers.C = 0x34;
        
        _registers.C = 0xFF;
        
        Assert.That(_registers.B, Is.EqualTo(0x12));
    }
    
    [Test]
    [TestCase(Registers.Name.A, 0x12)]
    [TestCase(Registers.Name.B, 0x34)]
    [TestCase(Registers.Name.C, 0x56)]
    [TestCase(Registers.Name.D, 0x78)]
    [TestCase(Registers.Name.E, 0x9A)]
    [TestCase(Registers.Name.H, 0xBC)]
    [TestCase(Registers.Name.L, 0xDE)]
    public void GetByName_ReturnsCorrectRegister(Registers.Name name, byte expected)
    {
        _registers.A = 0x12;
        _registers.B = 0x34;
        _registers.C = 0x56;
        _registers.D = 0x78;
        _registers.E = 0x9A;
        _registers.H = 0xBC;
        _registers.L = 0xDE;
        
        Assert.That(_registers.GetByName(name), Is.EqualTo(expected));
    }

    [Test]
    public void GetByName_M_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _registers.GetByName(Registers.Name.M));
    }

    [Test]
    public void SetByName_A_SetsCorrectly()
    {
        _registers.SetByName(Registers.Name.A, 0x42);
        Assert.That(_registers.A, Is.EqualTo(0x42));
    }

    [Test]
    public void SetByName_B_SetsCorrectly()
    {
        _registers.SetByName(Registers.Name.B, 0x42);
        Assert.That(_registers.B, Is.EqualTo(0x42));
    }

    [Test]
    public void SetByName_C_SetsCorrectly()
    {
        _registers.SetByName(Registers.Name.C, 0x42);
        Assert.That(_registers.C, Is.EqualTo(0x42));
    }

    [Test]
    public void SetByName_D_SetsCorrectly()
    {
        _registers.SetByName(Registers.Name.D, 0x42);
        Assert.That(_registers.D, Is.EqualTo(0x42));
    }

    [Test]
    public void SetByName_E_SetsCorrectly()
    {
        _registers.SetByName(Registers.Name.E, 0x42);
        Assert.That(_registers.E, Is.EqualTo(0x42));
    }

    [Test]
    public void SetByName_H_SetsCorrectly()
    {
        _registers.SetByName(Registers.Name.H, 0x42);
        Assert.That(_registers.H, Is.EqualTo(0x42));
    }

    [Test]
    public void SetByName_L_SetsCorrectly()
    {
        _registers.SetByName(Registers.Name.L, 0x42);
        Assert.That(_registers.L, Is.EqualTo(0x42));
    }

    [Test]
    public void SetByName_M_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _registers.SetByName(Registers.Name.M, 0x42));
    }

    [Test]
    public void SetByName_DoesNotAffectOtherRegisters()
    {
        _registers.A = 0x11;
        _registers.B = 0x22;
        _registers.C = 0x33;
        
        _registers.SetByName(Registers.Name.B, 0xFF);
        
        Assert.That(_registers.A, Is.EqualTo(0x11));
        Assert.That(_registers.C, Is.EqualTo(0x33));
    }

    [Test]
    public void GetEncodedDataTransferRegisters_MOV_B_C_DecodesCorrectly()
    {
        // MOV B, C = 0x41 = 01 000 001
        var result = Registers.GetEncodedRegs(0x41);
        
        Assert.That(result.Destination, Is.EqualTo(Registers.Name.B));
        Assert.That(result.Source, Is.EqualTo(Registers.Name.C));
    }

    [Test]
    public void GetEncodedDataTransferRegisters_MOV_A_B_DecodesCorrectly()
    {
        // MOV A, B = 0x78 = 01 111 000
        var result = Registers.GetEncodedRegs(0x78);
        
        Assert.That(result.Destination, Is.EqualTo(Registers.Name.A));
        Assert.That(result.Source, Is.EqualTo(Registers.Name.B));
    }

    [Test]
    public void GetEncodedDataTransferRegisters_MOV_H_L_DecodesCorrectly()
    {
        // MOV H, L = 0x65 = 01 100 101
        var result = Registers.GetEncodedRegs(0x65);
        
        Assert.That(result.Destination, Is.EqualTo(Registers.Name.H));
        Assert.That(result.Source, Is.EqualTo(Registers.Name.L));
    }

    [Test]
    public void GetEncodedDataTransferRegisters_MOV_M_A_DecodesCorrectly()
    {
        // MOV M, A = 0x77 = 01 110 111
        var result = Registers.GetEncodedRegs(0x77);
        
        Assert.That(result.Destination, Is.EqualTo(Registers.Name.M));
        Assert.That(result.Source, Is.EqualTo(Registers.Name.A));
    }

    [Test]
    public void GetEncodedDataTransferRegisters_MOV_A_M_DecodesCorrectly()
    {
        // MOV A, M = 0x7E = 01 111 110
        var result = Registers.GetEncodedRegs(0x7E);
        
        Assert.That(result.Destination, Is.EqualTo(Registers.Name.A));
        Assert.That(result.Source, Is.EqualTo(Registers.Name.M));
    }

    [Test]
    [TestCase(0x40, Registers.Name.B, Registers.Name.B)] // MOV B, B
    [TestCase(0x49, Registers.Name.C, Registers.Name.C)] // MOV C, C
    [TestCase(0x52, Registers.Name.D, Registers.Name.D)] // MOV D, D
    [TestCase(0x5B, Registers.Name.E, Registers.Name.E)] // MOV E, E
    [TestCase(0x64, Registers.Name.H, Registers.Name.H)] // MOV H, H
    [TestCase(0x6D, Registers.Name.L, Registers.Name.L)] // MOV L, L
    [TestCase(0x7F, Registers.Name.A, Registers.Name.A)] // MOV A, A
    public void GetEncodedDataTransferRegisters_SameRegister_DecodesCorrectly(
        byte opcode, Registers.Name expectedDest, Registers.Name expectedSrc)
    {
        var result = Registers.GetEncodedRegs(opcode);
        
        Assert.That(result.Destination, Is.EqualTo(expectedDest));
        Assert.That(result.Source, Is.EqualTo(expectedSrc));
    }

    [Test]
    public void PC_DefaultsToZero()
    {
        Assert.That(_registers.PC, Is.EqualTo(0));
    }

    [Test]
    public void SP_DefaultsToZero()
    {
        Assert.That(_registers.SP, Is.EqualTo(0));
    }

    [Test]
    public void PC_CanSetFullRange()
    {
        _registers.PC = 0xFFFF;
        Assert.That(_registers.PC, Is.EqualTo(0xFFFF));
    }

    [Test]
    public void SP_CanSetFullRange()
    {
        _registers.SP = 0xFFFF;
        Assert.That(_registers.SP, Is.EqualTo(0xFFFF));
    }

    [Test]
    public void NameEnum_HasCorrectBinaryValues()
    {
        Assert.That((int)Registers.Name.B, Is.EqualTo(0b000));
        Assert.That((int)Registers.Name.C, Is.EqualTo(0b001));
        Assert.That((int)Registers.Name.D, Is.EqualTo(0b010));
        Assert.That((int)Registers.Name.E, Is.EqualTo(0b011));
        Assert.That((int)Registers.Name.H, Is.EqualTo(0b100));
        Assert.That((int)Registers.Name.L, Is.EqualTo(0b101));
        Assert.That((int)Registers.Name.M, Is.EqualTo(0b110));
        Assert.That((int)Registers.Name.A, Is.EqualTo(0b111));
    }
}
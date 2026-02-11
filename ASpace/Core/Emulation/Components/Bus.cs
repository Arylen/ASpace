namespace ASpace.Core.Emulation.Components;

public class Bus
{
    private byte[] RAM = new byte[0x10000];
    
    public byte ReadByte(ushort addr) => RAM[addr];
    public void WriteByte(ushort addr, byte value) => RAM[addr] = value;
}
namespace ASpace.Core.Emulation.Components;

public class CPU(Bus bus)
{
    public Bus Bus { get; set; } = bus;
    public Registers Reg { get; set; } = new();

    public bool Halted { get; set; }

    public void Reset()
    {
        Reg = new();
        Bus = new();
    }

    public byte FetchByte() => Bus.ReadByte(Reg.PC++);

    public int ExecuteNext()
    {
        if (Halted)
            return 4;
        
        var nextOpcode = FetchByte();
        var decodedOp = OpTable.Get(nextOpcode);
        return decodedOp.Handler(this);
    }
}
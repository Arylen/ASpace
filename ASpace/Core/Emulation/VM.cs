using ASpace.Core.Emulation.Components;

namespace ASpace.Core.Emulation;

public class VM
{
    public CPU CPU { get; set; }
    public Bus Bus { get; set; }

    public ulong CycleCount;
    
    public VM()
    {
        Bus = new Bus();
        CPU = new CPU(Bus);
    }

    public void LoadRom(byte[] data, ushort addressStart = 0)
    {
        for (var i = 0; i < data.Length; i++)
            Bus.WriteByte((ushort)(addressStart + i), data[i]);
    }

    public void Step()
    {
        var cycles = CPU.ExecuteNext();
        
        CycleCount += (ulong)cycles;
    }
}
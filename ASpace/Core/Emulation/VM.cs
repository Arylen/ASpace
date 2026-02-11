using ASpace.Core.Emulation.Components;

namespace ASpace.Core.Emulation;

public class VM
{
    public CPU CPU { get; set; }
    public Bus Bus { get; set; }
    
    public VM()
    {
        Bus = new Bus();
        CPU = new CPU(Bus);
    }
}
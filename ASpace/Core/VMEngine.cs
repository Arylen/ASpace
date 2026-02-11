using System;
using ASpace.Core.Emulation;

namespace ASpace.Core;

public class VMEngine
{
    public VM? VM { get; private set; }
    
    public VMEngine()
    {
        Reset();
    }

    public void Reset()
    {
        VM = new VM();
    }
}
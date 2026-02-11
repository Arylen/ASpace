using System;

namespace ASpace.Core.Extensions;

public static class BitExtensions
{
    extension(byte b)
    {
        public byte WithBit(int bit, bool value)
        {
            if (bit >= 8)
                throw new ArgumentOutOfRangeException(nameof(bit), "Index too high.");
            var mask = 1 << bit;
            return value ? (byte)(b | mask) : (byte)(b & ~mask);
        }

        public bool GetBit(int bit)
        {
            if (bit >= 8)
                throw new ArgumentOutOfRangeException(nameof(bit), "Index too high.");
            return (b & (1 << bit)) > 0;
        }
    }

    extension(bool b)
    {
        public byte AsByte() => (byte)(b ? 1 : 0);
    }
}
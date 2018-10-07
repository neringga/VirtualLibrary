using System;

namespace VirtualLibrary.Enums
{
    [Flags]
    public enum BookGenre
    {
        Romance = 1,
        Drama = 2,
        Comedy = 4,
        Educational = 8,
        Poetry = 16
    }
}
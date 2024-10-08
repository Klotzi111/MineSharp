﻿namespace MineSharp.Data.Internal;

internal class EnumNameLookup<TEnum> where TEnum : struct, Enum
{
    private readonly Dictionary<string, TEnum> lookupTable;

    public EnumNameLookup()
    {
        lookupTable = Enum.GetNames<TEnum>()
                          .ToDictionary(x => x, Enum.Parse<TEnum>);
    }

    public TEnum FromName(string name)
    {
        return lookupTable[name];
    }
}

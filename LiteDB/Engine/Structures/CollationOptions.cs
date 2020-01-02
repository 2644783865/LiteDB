using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static LiteDB.Constants;

namespace LiteDB.Engine
{
    /// <summary>
    /// Represent how database will compare Strings
    /// </summary>
    public enum CollationOptions : byte
    {
        CaseSensitive = 0,
        IgnoreCase = 1,
        Ordinal = 2
    }
}
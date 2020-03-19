﻿using System;

namespace Microsoft.Build.Logging.StructuredLogger
{
    [Flags]
    internal enum NodeFlags : byte
    {
        None = 0,
        Hidden = 1 << 0,
        Expanded = 1 << 1,
        SearchResult = 1 << 2,
        ContainsSearchResult = 1 << 3,
        SearchResultFlagsOutOfDate = 1 << 4,
        LowRelevance = 1 << 5
    }
}

// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)

using System.Linq;
using StringCompare.Structures.Interfaces;

namespace StringCompare.Algorithms.Hamming
{
    /// <summary>
    /// Only for equals length string.
    /// Hamming distance between two strings of equal length is the number of positions at which the corresponding symbols are different.
    /// 
    /// About https://en.wikipedia.org/wiki/Hamming_distance
    /// </summary>
    public class HammingAlgorithm : ICompareAlgorithm
    {
        /// <summary>
        /// Measure the difference
        /// </summary>
        /// <param name="source">source string</param>
        /// <param name="target">target string</param>
        /// <returns>-1 if not equal lengths, 0 is different, 1 is equals</returns>
        public double GetCompareResult(string source, string target)
        {
            source = source ?? string.Empty;
            target = target ?? string.Empty;

            if (source.Length != target.Length)
                return -1;

            var diffs = source.Where((sourceSymbol, i) => !sourceSymbol.Equals(target[i])).Count();

            if (diffs == 0) return 1;
            return 1.0 - 1.0/((double) source.Length/diffs);
        }
    }
}
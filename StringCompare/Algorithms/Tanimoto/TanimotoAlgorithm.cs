// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)

using StringCompare.Structures.Interfaces;
using System;
using System.Linq;

namespace StringCompare.Algorithms.Tanimoto
{
    /// <summary>
    /// Tanimoto Coefficient uses the ratio of the intersecting set to the union set as the measure of similarity. 
    /// 
    /// About http://mines.humanoriented.com/classes/2010/fall/csci568/portfolio_exports/sphilip/tani.html
    /// </summary>
    public class TanimotoAlgorithm: ICompareAlgorithm
    {
        /// <summary>
        /// Measure the difference
        /// </summary>
        /// <param name="source">source string</param>
        /// <param name="target">target string</param>
        /// <returns>0 is different, 1 is equals, >1 if target string has more matches</returns>
        public double GetCompareResult(string source, string target)
        {
            source = source ?? string.Empty;
            target = target ?? string.Empty;

            if (IsNullOrWhiteSpace(source) && IsNullOrWhiteSpace(target)) return 1;

            double sourceLength = source.Length;
            double targetLength = target.Length;

            double commonsCount = 0;
            foreach (var sourceSymbol in source.ToLowerInvariant().Trim())
            {
                if (target.ToLowerInvariant().Trim().IndexOf(sourceSymbol) != -1) commonsCount += 1;
            }

            return commonsCount / (sourceLength + targetLength - commonsCount);
        }

        /// <summary>
        /// Provided here for backward compatibility with older .NET versions.
        /// See: http://referencesource.microsoft.com/#mscorlib/system/string.cs,55e241b6143365ef
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsNullOrWhiteSpace(string value)
        {
            return value == null || value.All(Char.IsWhiteSpace);
        }
    }
}
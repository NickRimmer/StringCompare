// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)

using StringCompare.Structures.Interfaces;

namespace StringCompare.Algorithms.Tanimoto
{
    public class TanimotoAlgorithm: ICompareAlgorithm
    {
        public double GetCompareResult(string source, string target)
        {
            double sourceLength = source.Length;
            double targetLength = target.Length;

            double commonsCount = 0;
            foreach (var sourceSymbol in source.ToLowerInvariant().Trim())
            {
                if (target.ToLowerInvariant().Trim().IndexOf(sourceSymbol) != -1) commonsCount += 1;
            }

            return commonsCount / (sourceLength + targetLength - commonsCount);
        }
    }
}
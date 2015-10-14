// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)

namespace StringCompare.Algorithms.Levenshtein
{
    public static class LevenshteinAlgorithmExtension
    {
        public static double CompareLevenshtein(this string source, string target)
        {
            return new LevenshteinAlgorithm().GetCompareResult(source, target);
        }
    }
}
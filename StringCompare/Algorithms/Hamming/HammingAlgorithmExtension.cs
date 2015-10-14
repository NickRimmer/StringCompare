// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)
namespace StringCompare.Algorithms.Hamming
{
    public static class HammingAlgorithmExtension
    {
        /// <summary>
        /// Measure the difference
        /// </summary>
        /// <param name="source">source string</param>
        /// <param name="target">target string</param>
        /// <returns>0 is different, 1 is equals</returns>
        public static double CompareHamming(this string source, string target)
        {
            return new HammingAlgorithm().GetCompareResult(source, target);
        }
    }
}
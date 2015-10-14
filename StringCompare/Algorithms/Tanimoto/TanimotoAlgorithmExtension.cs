// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)

namespace StringCompare.Algorithms.Tanimoto
{
    public static class TanimotoAlgorithmExtension
    {
        public static double CompareTanimoto(this string source, string target)
        {
            return new TanimotoAlgorithm().GetCompareResult(source, target);
        }
    }
}
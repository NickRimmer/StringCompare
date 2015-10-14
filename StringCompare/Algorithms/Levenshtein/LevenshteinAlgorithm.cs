// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)

using System;
using StringCompare.Structures.Interfaces;

namespace StringCompare.Algorithms.Levenshtein
{
    public class LevenshteinAlgorithm:ICompareAlgorithm
    {
        public double GetCompareResult(string source, string target)
        {
            
            if (string.IsNullOrEmpty(source))
                return string.IsNullOrEmpty(target) ? 0 : target.Length;

            if (string.IsNullOrEmpty(target))
                return string.IsNullOrEmpty(source) ? 0 : source.Length;

            var sourceLength = source.Length;
            var targetLength = target.Length;

            var distance = new int[sourceLength + 1, targetLength + 1];

            source = source.ToLowerInvariant().Trim();
            target = target.ToLowerInvariant().Trim();

            for (var i = 0; i <= sourceLength; distance[i, 0] = i++) ;
            for (var j = 0; j <= targetLength; distance[0, j] = j++) ;

            for (var i = 1; i <= sourceLength; i++)
            {
                for (var j = 1; j <= targetLength; j++)
                {
                    var cost = (target[j - 1] == source[i - 1]) ? 0 : 1;
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            //return distance[sourceLength, targetLength];

            double stepsToSame = distance[sourceLength, targetLength];
            return (1.0 - (stepsToSame / (double)Math.Max(source.Length, target.Length)));

        }
    }
}
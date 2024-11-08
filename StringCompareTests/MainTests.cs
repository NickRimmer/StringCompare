// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCompare.Algorithms.Hamming;
using StringCompare.Algorithms.Levenshtein;
using StringCompare.Algorithms.Tanimoto;
using StringCompare.Structures.Interfaces;
using StringCompareTests.Models;

namespace StringCompareTests
{
    [TestClass]
    public class MainTests
    {
        /// <summary>
        /// Test sets
        /// </summary>
        private readonly List<DataModel> _data = [
            new DataModel("Incorrects", "White House")
                .AddTarget("whate mouze")
                .AddTarget("white mouze")
                .AddTarget("white mouse")
                .AddTarget("white house")
                .AddTarget("some text"),

            new DataModel("Differents words", "Blue sea")
                .AddTarget("deep blue sea")
                .AddTarget("very deep blue sea")
                .AddTarget("sea is blue")
                .AddTarget("blue sea"),

            new DataModel("Test with repeats", "again")
                .AddTarget("again again")
                .AddTarget("again and again")
                .AddTarget("again"),

            new DataModel("Test with repeats in source", "fast fast")
                .AddTarget("fast")
                .AddTarget("fast fast fast")
                .AddTarget("fast fast fast fasr")
                .AddTarget("fast fast"),

            new DataModel("Position test", "word")
                .AddTarget("it is word")
                .AddTarget("is it word")
                .AddTarget("wor is it")
                .AddTarget("word")
                .AddTarget("wor")
                .AddTarget(" w "),
        ];

        private readonly List<ICompareAlgorithm> _algorithms = [
            new TanimotoAlgorithm(),
            new LevenshteinAlgorithm(),
            new HammingAlgorithm(),
        ];

        [TestMethod]
        public void Main_Test1()
        {
            foreach (var algorithm in _algorithms)
            {
                Console.WriteLine("\n\nAlgorithm - {0}", algorithm.GetType().Name);
                foreach (var data in _data)
                {
                    Console.WriteLine("\nTest \"{0}\" ({1}):", data.DataName, data.Source);

                    var results = data
                        .Targets
                        .Select(x => new ResultModel
                        {
                            Target = x,
                            CompareValue = algorithm.GetCompareResult(data.Source.ToLower(), x)
                        })
                        .OrderByDescending(x => x.CompareValue);

                    foreach (var result in results)
                        Console.WriteLine(result);
                }
            }
        }
    }
}
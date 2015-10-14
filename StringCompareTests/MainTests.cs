// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        /// Наборы данных для тестов
        /// </summary>
        private List<DataModel> _datas = new List<DataModel>
        {
            new DataModel("Проверка опечатков", "Этот белый шарик")
            .AddTarget("Это белий шарек") // 3 опечатки
            .AddTarget("Этот белий шарек") // 2 опечатки
            .AddTarget("Этот белий шарик") // 1 опечатка
            .AddTarget("Этот белый шарик") // такой же
            .AddTarget("левый текст") // левый текст
            ,
            new DataModel("Проверка лишних слов", "крутой спуск")
            .AddTarget("слишком крутой спуск")
            .AddTarget("не слишком крутой спуск")
            .AddTarget("крутой спуск спереди")
            .AddTarget("левый текст")
            .AddTarget("крутой спуск")
            ,
            new DataModel("Проверка с повтором", "солнцестояние")
            .AddTarget("солнцестояние солнцестояние")
            .AddTarget("солнцестояние солнцестояние солнцестояние")
            .AddTarget("левый текст")
            .AddTarget("солнцестояние")

            ,
            new DataModel("Проверка с обратным повтором", "солнцестояние солнцестояние")
            .AddTarget("солнцестояние солнцестояние")
            .AddTarget("солнцестояние солнцестояние солнцестояние")
            .AddTarget("левый текст")
            .AddTarget("солнцестояние")

            ,
            new DataModel("Проверка в разных местах", "слово")
            .AddTarget("первым было слово")
            .AddTarget("первым слово было")
            .AddTarget("слово первым было")
            .AddTarget("слово")
        };

        private List<ICompareAlgorithm> _algorithms = new List<ICompareAlgorithm>
        {
            new TanimotoAlgorithm(),
            new LevenshteinAlgorithm()
        };

        [TestMethod]
        public void Main_Test1()
        {
            foreach (var algorithm in _algorithms)
            {
                Console.WriteLine("\n\nАлгоритм - {0}", algorithm.GetType().Name);
                foreach (var data in _datas)
                {
                    Console.WriteLine("\nТест \"{0}\" ({1}):", data.DataName, data.Source);

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
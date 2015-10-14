// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)

using System.Collections.Generic;

namespace StringCompareTests.Models
{
    public class DataModel
    {
        public string Source { get; set; }
        public List<string> Targets { get; set; }

        public string DataName { get; set; }

        public DataModel(string dataName, string source)
        {
            DataName = dataName;
            Source = source;
            Targets = new List<string>();
        }


        public DataModel SetSource(string source)
        {
            Source = source;
            return this;
        }

        public DataModel AddTarget(string target)
        {
            Targets.Add(target);
            return this;
        }
    }
}
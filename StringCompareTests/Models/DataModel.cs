// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)

using System.Collections.Generic;

namespace StringCompareTests.Models
{
    public record DataModel
    {
        public string Source { get; }
        public IReadOnlyCollection<string> Targets => _targets;

        private readonly List<string> _targets = new ();

        public string DataName { get; }

        public DataModel(string dataName, string source)
        {
            DataName = dataName;
            Source = source;
        }

        public DataModel AddTarget(string target)
        {
            _targets.Add(target);
            return this;
        }
    }
}

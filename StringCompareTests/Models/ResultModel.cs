// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)
namespace StringCompareTests.Models
{
    public class ResultModel
    {
        public double CompareValue { get; set; }

        public string Target { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - \"{1}\"",  CompareValue, Target);
        }
    }
}
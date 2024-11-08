// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)
namespace StringCompareTests.Models
{
    public record ResultModel
    {
        public double CompareValue { get; init; }

        public string Target { get; init; }

        public override string ToString() => $"{CompareValue} - \"{Target}\"";
    }
}
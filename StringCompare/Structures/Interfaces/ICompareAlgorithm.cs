// Library for compare strings
// Copyright (C) 2015 Nick Rimmer. Contacts: <xan@dipteam.com>
// 
// This file is part of StringCompare library.
// Licensed under the MIT License (MIT)
namespace StringCompare.Structures.Interfaces
{
    public interface ICompareAlgorithm
    {
        double GetCompareResult(string source, string target);
    }
}
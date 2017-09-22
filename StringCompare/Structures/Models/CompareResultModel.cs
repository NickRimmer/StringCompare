using System;
using System.Collections.Generic;
using System.Text;

namespace StringCompare.Structures.Models
{
    public class CompareResultModel<TSource>
    {
        public double Equality { get; set; }

        public TSource Value { get; set; }
    }
}

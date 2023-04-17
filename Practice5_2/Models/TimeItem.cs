using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice5_2.Models
{
    [Serializable]
    public struct TimeItem
    {
        public int MatrixOrder;
        public int RepeatCount;
        public double CSharpTime;
        public double CppTime;
        public double Coefficient;
    }
}

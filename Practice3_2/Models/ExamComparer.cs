using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3_2.Models
{
    public class ExamComparer : IComparer<Exam>
    {
        public int Compare(Exam? x, Exam? y)
        {
            if (x is null || y is null)
                throw new Exception("Объект равен null");

            if (x.Date > y.Date)
            {
                return 1;
            }
            else if (x.Date < y.Date)
                return -1;
            else
                return 0;
        }
    }
}

using Practice.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3.Models
{
    public class StudentComparer : IComparer<Student>
    {

        public int Compare(Student? x, Student? y)
        {
            if (x is null || y is null)
                throw new Exception("Объект равен null");

            if (x.AvgGrade > y.AvgGrade)
            {
                return 1;
            }
            else if (x.AvgGrade < y.AvgGrade)
                return -1;
            else
                return 0;
        }

    }
}

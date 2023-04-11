using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4.Models
{
    public class StudentListHandlerEventArgs : EventArgs
    {
        public string Name { get; set; }

        public string OperationName { get; set; }

        public Student Student { get; set; }

        public StudentListHandlerEventArgs(Student student, string name)
        {
            Student = student;
            Name = name;
        }

        public StudentListHandlerEventArgs() { }

        public override string ToString()
        {
            return $"Название коллекции: {Name}\nНазвание операции: {OperationName}";
        }
    } 
}

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
        /// <summary>
        /// Название теста
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Название операции проводимой над коллекций
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// Объект студента
        /// </summary>
        public Student Student { get; set; }

        public StudentListHandlerEventArgs(Student student, string name)
        {
            Student = student;
            Name = name;
        }

        public StudentListHandlerEventArgs() { }

        /// <summary>
        /// Получение строки с объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Название коллекции: {Name}\nНазвание операции: {OperationName}";
        }
    } 
}

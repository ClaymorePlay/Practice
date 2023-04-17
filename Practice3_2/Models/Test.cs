using Practice.Extensions;
using Practice2.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.Models
{
    public class Test : IDateAndCopy
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сдан ли
        /// </summary>
        public bool IsPassed { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Date { get; set; }

        public Test(string name, bool isPassed)
        {
            Name = name;
            IsPassed = isPassed;
        }

        public Test()
        {
            Name = StringExtension.GetRandom(10);
            IsPassed = false;
        }

        /// <summary>
        /// Получение строки объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Имя: {Name}, Зачет: {IsPassed}";
        }

        /// <summary>
        /// Полная копия объекта
        /// </summary>
        /// <returns></returns>
        public object DeepCopy()
        {
            return new Test(Name, IsPassed);
        }
    }
}

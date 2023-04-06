using Practice.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice.Models
{
    public class Exam
    {
        /// <summary>
        /// Предмет
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Оценка
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Начало экзамена
        /// </summary>
        public DateTime DateStart { get; set; }
    
        public Exam()
        {
            Subject = StringExtension.GetRandom(7);
            Grade = new Random().Next(1, 6);
            DateStart = DateTime.UtcNow;
        }


        public Exam(string subject, int grade, DateTime date)
        {
            Subject = subject;
            Grade = grade;
            DateStart = date;
        }

        /// <summary>
        /// Получение строки со всеми полями
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Предмет: {Subject}, Оценка: {Grade}, Дата начала: {DateStart}";
        }
    }
}

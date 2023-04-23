using Practice.Extensions;
using Practice2.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice.Models
{
    /// <summary>
    /// Экзамен
    /// </summary>
    public class Exam : IDateAndCopy, IComparable<Exam>, IComparer<Exam>
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
        /// Дата экзамена
        /// </summary>
        public DateTime Date { get; set; }

        public Exam()
        {
            Subject = StringExtension.GetRandom(7);
            Grade = new Random().Next(1, 6);
            Date = DateTime.UtcNow;
        }


        public Exam(string subject, int grade, DateTime date)
        {
            Subject = subject;
            Grade = grade;
            Date = date;
        }

        /// <summary>
        /// Получение строки со всеми полями
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Предмет: {Subject}, Оценка: {Grade}, Дата начала: {Date}";
        }

        /// <summary>
        /// Полуение полнй копии
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object DeepCopy()
        {
            return new Exam(Subject, Grade, Date);
        }

        /// <summary>
        /// Реализация метода compareto для сортировки по оценке
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Exam? other)
        {
            return Grade.CompareTo(other?.Grade);

        }

        /// <summary>
        /// Реализация метода compare для сортировки по названию предмета
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int Compare(Exam? x, Exam? y)
        {
            if (x is null || y is null)
                throw new Exception("Объект равен null");
            return String.Compare(x.Subject, y.Subject);
        }
    }
}

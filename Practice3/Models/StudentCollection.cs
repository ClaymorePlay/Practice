using Practice.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3.Models
{
    /// <summary>
    /// Коллекция студентов
    /// </summary>
    public class StudentCollection : IEnumerable<Student>
    {
        /// <summary>
        /// Студенты
        /// </summary>
        private List<Student> _students = new List<Student>();

        /// <summary>
        /// Максимальная оценка
        /// </summary>
        public double MaxGrade 
        { 
            get
            {
                if (_students == null || _students.Count == 0)
                    return 0;
                return _students.Max(c=> c.AvgGrade);
            } 
        }

        /// <summary>
        /// Получение специалистов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> StudentsWithSpecialist
        {
            get
            {
                foreach (var student in _students.Where(c => c.Education == Practice.Models.Enums.EducationEnum.Specialist))
                {
                    yield return student;
                }
            }
        }

        /// <summary>
        /// Получение студентов со средним баллом 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<Student> AverageMarkGroup(double value)
        {
            return _students.GroupBy(c => c.AvgGrade).FirstOrDefault(c => c.Key == value)?.ToList() ?? new List<Student>();
        }


        /// <summary>
        /// Добавление студентов
        /// </summary>
        public void AddStudents(params Student[] students)
        {
            _students.AddRange(students);
        }

        /// <summary>
        /// Добавление дефолтных значений
        /// </summary>
        public void AddDefaults(int count)
        {
            for(int i = 0; i < count; i++)
            {
                var stud = new Student();
                stud.Exams = new List<Exam>();
                for(int j = 0; j < 5; j++)
                {
                    stud.Exams.Add(new Exam());
                }
                _students.Add(stud);
            }
        }

        /// <summary>
        /// Получение строки объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Join("", _students.Select(c => c.ToString()));
        }

        /// <summary>
        /// Возвращает короткую версию строки элемента
        /// </summary>
        /// <returns></returns>
        public string ToShortString()
        {
            return String.Join("\n\n", _students.Select(c => c.ToShortString()));
        }


        /// <summary>
        /// Сортировка по фамилии
        /// </summary>
        public void SortByLastName()
        {
            _students.Sort();
        }

        /// <summary>
        /// Сортировка по дате
        /// </summary>
        public void SortByDate()
        {
            _students.Sort(new Person());
        }

        /// <summary>
        /// Сортировка по оценкам
        /// </summary>
        public void SortByGrage()
        {
            _students.Sort(new StudentComparer());
        }

        /// <summary>
        /// Полученре перечисления
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Student> GetEnumerator()
        {
            return _students.GetEnumerator();
        }

        /// <summary>
        /// Получение перечисления
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _students.GetEnumerator();
        }
    }
}

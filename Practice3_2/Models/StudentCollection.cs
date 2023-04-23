using Practice.Models;
using Practice.Models.Enums;
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
    public class StudentCollection<TKey> : IEnumerable<Student>
    {
        /// <summary>
        /// Делегат селектора ключа
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="st"></param>
        /// <returns></returns>
        public delegate TKey KeySelector<TKey>(Student st);

        /// <summary>
        /// Селектор
        /// </summary>
        private readonly KeySelector<TKey> _keySelector;

        /// <summary>
        /// Студенты
        /// </summary>
        private Dictionary<TKey,Student> _students = new Dictionary<TKey,Student>();

        public StudentCollection(KeySelector<TKey> selector)
        {
            _students = new Dictionary<TKey, Student>();
            _keySelector = selector;
        }


     

        /// <summary>
        /// Максимальная оценка
        /// </summary>
        public double MaxGrade 
        { 
            get
            {
                if (_students == null || _students.Count == 0)
                    return 0;
                return _students.Max(c=> c.Value.AvgGrade);
            } 
        }

        /// <summary>
        /// Получение студентов с определенным типом образования
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<Student> EducationForm(EducationEnum value)
        {
            return _students.Where(c => c.Value.Education == value).Select(c => c.Value).ToList();
        }

        /// <summary>
        /// Группировка по образованию
        /// </summary>
        public IEnumerable<IGrouping<EducationEnum, KeyValuePair<TKey, Student>>> GetEducationGroup
        {
            get
            {
                return _students.GroupBy(c => c.Value.Education);
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
                foreach (var student in _students.Where(c => c.Value.Education == Practice.Models.Enums.EducationEnum.Specialist))
                {
                    yield return student.Value;
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
            return _students.GroupBy(c => c.Value.AvgGrade).FirstOrDefault(c => c.Key == value)?.Select(c => c.Value).ToList() ?? new List<Student>();
        }


        /// <summary>
        /// Добавление студентов
        /// </summary>
        public void AddStudents(params Student[] students)
        {
            foreach(var item in students)
            {
                _students.Add(_keySelector(item), item);

            }
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
                _students.Add(_keySelector(stud),stud);
            }
        }

        /// <summary>
        /// Получение строки объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Join("", _students.Select(c => c.Value.ToString()));
        }

        /// <summary>
        /// Возвращает короткую версию строки элемента
        /// </summary>
        /// <returns></returns>
        public string ToShortString()
        {
            return String.Join("\n\n", _students.Select(c => c.Value.ToShortString()));
        }



        /// <summary>
        /// Полученре перечисления
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Student> GetEnumerator()
        {
            return _students.Values.GetEnumerator();
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

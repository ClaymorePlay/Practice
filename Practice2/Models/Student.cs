﻿using Practice.Models.Enums;
using Practice2.Models;
using Practice2.Models.Interfaces;
using System.Collections;

namespace Practice.Models
{
    public class Student : Person, IDateAndCopy
    {

        /// <summary>
        /// Образование
        /// </summary>
        private EducationEnum _education;

        /// <summary>
        /// Номер группы
        /// </summary>
        private int _groupNumber;

        /// <summary>
        /// Экзамены
        /// </summary>
        private ArrayList _exams;

        /// <summary>
        /// Зачеты
        /// </summary>
        private ArrayList _tests;

        /// <summary>
        /// Образование
        /// </summary>
        public EducationEnum Education
        {
            get => _education;
            set => _education = value;
        }

        /// <summary>
        /// Номер группы
        /// </summary>
        public int GroupNumber
        {
            get
            {
                return _groupNumber;
            }
            set
            {
                if (value <= 100 || value > 599)
                    throw new Exception("Значение не соответствует условию > 100 и <= 599");
                _groupNumber = value;
            }
        }

        /// <summary>
        /// Экзамены
        /// </summary>
        public ArrayList Exams
        {
            get => _exams;
            set => _exams = value;
        }

        /// <summary>
        /// Тесты
        /// </summary>
        public ArrayList Tests
        {
            get => _tests;
            set => _tests = value;
        }

        /// <summary>
        /// Средняя оценка
        /// </summary>
        public double AvgGrade { get => _exams == null ? 0 : _exams.ToArray().Average(c => ((Exam)c).Grade); }

        public DateTime Date { get; set; }

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool this[EducationEnum education]
        {
            get => _education == education ? true : false;
        }

        public Person Person
        {
            get
            {
                return (Person)base.MemberwiseClone();
            }
            set
            {
                this.Name = value.Name;
                this.LastName = value.LastName;
                this.DateOfBirth = value.DateOfBirth;
                
            }
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="personInfo"></param>
        /// <param name="education"></param>
        /// <param name="groupNumber"></param>
        public Student(Person person, EducationEnum education, int groupNumber) : base(person.Name, person.LastName, person.DateOfBirth)
        {
            _education = education;
            _groupNumber = groupNumber;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Student() : base()
        {
            _groupNumber = new Random().Next(100, 401);
            _education = EducationEnum.Вachelor;
        }

        /// <summary>
        /// Добавление экзаменов
        /// </summary>
        /// <param name="exams"></param>
        public void AddExams(ArrayList exams)
        {
            _exams = exams;
        }

        /// <summary>
        /// Добавление тестов
        /// </summary>
        /// <param name="tests"></param>
        public void AddTests(ArrayList tests)
        {
            _tests = tests;
        }


        /// <summary>
        /// Получение строки со всеми полями класса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var str = $"{base.ToString()}\nОбразование: {_education}, Группа: {_groupNumber}\n";
            if (_exams != null && _exams.Count > 0)
                str += string.Join(",\n", _exams.ToArray().Select(c => c.ToString()).ToList());
            if(_tests != null && _tests.Count > 0)
                str += "\n" + string.Join(",\n", _tests.ToArray().Select(c => c.ToString()).ToList());

            return str;
        }

        /// <summary>
        /// Получение строки с именем и фамилией
        /// </summary>
        /// <returns></returns>
        public virtual string ToShortString()
        {
            return $"{base.ToString()}\nОбразование: {_education}, Группа: {_groupNumber}, Средний балл: {AvgGrade}\n";
        }

        /// <summary>
        /// Получение полной копии
        /// </summary>
        /// <returns></returns>
        public override object DeepCopy()
        {
            var newStudent = new Student((Person)base.DeepCopy(), Education, GroupNumber);
            var newExams = new ArrayList();
            var newTests = new ArrayList();
            foreach(var item in Exams)
            {
                newExams.Add(((Exam)item).DeepCopy());
            }
            foreach(var item in Tests)
            {
                newTests.Add(((Test)item).DeepCopy());
            }
            newStudent.AddExams(newExams);
            newStudent.AddTests(newTests);
            return newStudent;
        }

        /// <summary>
        /// Итератор
        /// </summary>
        /// <returns></returns>
        public IEnumerable GetEnumerator(double? minGrade)
        {
            if (minGrade == null)
            {
                foreach (var item in Exams)
                {
                    yield return item;
                }
                foreach(var item in Tests)
                {
                    yield return item;
                }
            }
            else
                foreach (var item in Exams)
                {
                    if (((Exam)item).Grade > minGrade)
                        yield return (Exam)item;
                }
        }

  
    }
}
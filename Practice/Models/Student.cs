using Practice.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practice.Models
{
    public class Student
    {
        /// <summary>
        /// Информация о студенте
        /// </summary>
        private Person _personInfo;

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
        private Exam[] _exams;

        /// <summary>
        /// Информация о студенте
        /// </summary>
        public Person PersonInfo
        {
            get => _personInfo;
            set => _personInfo = value;
        }

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
            get => _groupNumber;
            set => _groupNumber = value;
        }

        /// <summary>
        /// Экзамены
        /// </summary>
        public Exam[] Exams
        {
            get => _exams;
            set => _exams = value;
        }

        /// <summary>
        /// Средняя оценка
        /// </summary>
        public double AvgGrade { get => _exams == null ? 0 : _exams.Average(c => c.Grade); }

        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool this[EducationEnum education]
        {
            get => _education == education ? true : false;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="personInfo"></param>
        /// <param name="education"></param>
        /// <param name="groupNumber"></param>
        public Student(Person personInfo, EducationEnum education, int groupNumber)
        {
            _personInfo = personInfo;
            _education = education;
            _groupNumber = groupNumber;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Student()
        {
            _personInfo = new Person();
            _groupNumber = new Random().Next(100, 401);
            _education = EducationEnum.Вachelor;
        }

        /// <summary>
        /// Добавление экзаменов
        /// </summary>
        /// <param name="exams"></param>
        public void AddExams(params Exam[] exams)
        {
            _exams = exams;
        }


        /// <summary>
        /// Получение строки со всеми полями класса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var str = $"{_personInfo.ToString()}\nОбразование: {_education}, Группа: {_groupNumber}\n";
            if (_exams != null && _exams.Count() > 0)
                str += string.Join(",\n", _exams.Select(c => c.ToString()).ToList());
            return str;
        }

        /// <summary>
        /// Получение строки с именем и фамилией
        /// </summary>
        /// <returns></returns>
        public virtual string ToShortString()
        {
            return $"{_personInfo.ToString()}\nОбразование: {_education}, Группа: {_groupNumber}, Средний балл: {AvgGrade}\n";
        }
    }
}

using Practice.Extensions;
using Practice.Models.Enums;
using Practice2.Models;
using Practice2.Models.Interfaces;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;

namespace Practice.Models
{
    [Serializable]
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
        private List<Exam> _exams;

        /// <summary>
        /// Зачеты
        /// </summary>
        private List<Test> _tests;

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
        public List<Exam> Exams
        {
            get => _exams;
            set => _exams = value;
        }

        /// <summary>
        /// Тесты
        /// </summary>
        public List<Test> Tests
        {
            get => _tests;
            set => _tests = value;
        }

        /// <summary>
        /// Средняя оценка
        /// </summary>
        public double AvgGrade { get => _exams == null ? 0 : _exams.ToArray().Average(c => ((Exam)c).Grade); }

        /// <summary>
        /// Дата
        /// </summary>
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
            _education = (EducationEnum)new Random().Next(0, 3);
        }

        /// <summary>
        /// Добавление экзаменов
        /// </summary>
        /// <param name="exams"></param>
        public void AddExams(List<Exam> exams)
        {
            if (_exams == null)
                _exams = exams;
            else
                _exams.AddRange(exams);
        }

        /// <summary>
        /// Добавление тестов
        /// </summary>
        /// <param name="tests"></param>
        public void AddTests(List<Test> tests)
        {
            if (_tests == null)
                _tests = tests;
            else
                _tests.AddRange(tests);
        }


        /// <summary>
        /// Получение строки со всеми полями класса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var str = $"\n{base.ToString()}\nОбразование: {_education}, Группа: {_groupNumber} Средний балл: {AvgGrade} \n";
            if (_exams != null && _exams.Count > 0)
                str += string.Join(",\n", _exams.ToArray().Select(c => c.ToString()).ToList());
            if (_tests != null && _tests.Count > 0)
                str += "\n" + string.Join(",\n", _tests.ToArray().Select(c => c.ToString()).ToList());

            return str;
        }

        /// <summary>
        /// Получение строки с именем и фамилией
        /// </summary>
        /// <returns></returns>
        public virtual string ToShortString()
        {
            return $"{base.ToString()}\nОбразование: {_education}, Группа: {_groupNumber}, Средний балл: {AvgGrade}, Кол-во экзаменов: {_exams.Count}, Кол-во зачетов: {_tests.Count}\n";
        }

        /// <summary>
        /// Получение полной копии
        /// </summary>
        /// <returns></returns>
        public override Student DeepCopy()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);

                stream.Seek(0, SeekOrigin.Begin);
                var copiedObj = (Student)formatter.Deserialize(stream);
                return copiedObj;
            }
        }

        /// <summary>
        /// Сохранение объекта
        /// </summary>
        /// <param name="filename"></param>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool Save(string filename, Student student)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, student); 
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Сохранение
        /// </summary>
        /// <returns></returns>
        public bool Save(string filename)
        {
            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, this);
                    return true; 
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Выгрузка объекта
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public static bool Load(string filename, Student student)
        {
            try
            {
                if (File.Exists(filename))
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        var deserilizeStudent = (Student)formatter.Deserialize(fs);
                        student = deserilizeStudent;

                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Выгрузка объекта
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool Load(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        var deserilizeStudent = (Student)formatter.Deserialize(fs);
                        this.Name = deserilizeStudent.Name;
                        this.Person = deserilizeStudent.Person;
                        this.CustomizeDateOfBirthYear = deserilizeStudent.CustomizeDateOfBirthYear;
                        this.Education = deserilizeStudent.Education;
                        this.Tests = deserilizeStudent.Tests;
                        this.Exams = deserilizeStudent.Exams;
                        this.GroupNumber = deserilizeStudent.GroupNumber;
                        this.LastName = deserilizeStudent.LastName;

                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
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


        /// <summary>
        /// Консольное добавление
        /// </summary>
        /// <returns></returns>
        public bool AddFromConsole()
        {
            Console.WriteLine($"Введите данные в виде одной строки для добавления элемента. Разделителями служат запятые. Все данные указываются в определенном проядке(Название предмета, Оценка, Дата)\n");
            var insert = Console.ReadLine();

            try
            {
                var data = insert.Split(',');
                var subject = String.IsNullOrWhiteSpace(data[0]) ? StringExtension.GetRandom(7) : data[0];
                var grade = Int32.TryParse(data[1], out var groupResult) ? groupResult : 0;
                var date = DateTime.TryParse(data[2], out var dataResult) ? dataResult : DateTime.MinValue;

                var student = new Exam(subject, grade, date);
                this.Exams.Add(student);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

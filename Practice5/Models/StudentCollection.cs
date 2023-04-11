using Practice.Extensions;
using Practice.Models;
using Practice.Models.Enums;
using Practice4.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3.Models
{
    public class StudentCollection : IEnumerable<Student>
    {
        /// <summary>
        /// Студенты
        /// </summary>
        private List<Student> _students = new List<Student>();

        /// <summary>
        /// Название коллекции 
        /// </summary>
        public string CollectionName { get; set; } = "ListCollection";


        public delegate void StudentListHandler(object sourse, StudentListHandlerEventArgs args);

        /// <summary>
        /// Событие вызываеморе при изменении размера коллекции
        /// </summary>
        public event StudentListHandler StudentsCountChanged;

        /// <summary>
        /// Вызываемое при изменении ссылки объекта
        /// </summary>
        public event StudentListHandler StudentReferenceChanged;

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
            if(StudentsCountChanged != null)
                foreach(var item in students)
                {
                    StudentsCountChanged.Invoke(null, new StudentListHandlerEventArgs
                    {
                        Name = CollectionName,
                        Student = item,
                        OperationName = "Add"
                    });
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
                _students.Add(stud);
                StudentsCountChanged.Invoke(null, new StudentListHandlerEventArgs
                {
                    Name = CollectionName,
                    Student = stud,
                    OperationName = "Add"
                });
            }
        }


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

        public IEnumerator<Student> GetEnumerator()
        {
            return _students.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _students.GetEnumerator();
        }


        /// <summary>
        /// Метод удаления элемента
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool Remove(int j)
        {
            try
            {
                var stud = _students[j];
                _students.RemoveAt(j);

                if(StudentsCountChanged != null)
                    StudentsCountChanged.Invoke(null, new StudentListHandlerEventArgs
                    {
                        Name = CollectionName,
                        Student = stud,
                        OperationName = "Remove"
                    });
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// индексатор
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Student this[int index]
        {
            get => _students[index];
            set
            {
                _students[index] = value;
                StudentReferenceChanged.Invoke(null, new StudentListHandlerEventArgs
                {
                    Student = value,
                    Name = CollectionName,
                    OperationName = "Update"
                });
            }
        }



    }
}

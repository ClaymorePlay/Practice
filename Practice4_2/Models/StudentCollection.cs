using Practice.Models;
using Practice4.Models;
using Practice4_2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3.Models
{
    public class StudentCollection<TKey> : IEnumerable<Student>
    {
        /// <summary>
        /// Студенты
        /// </summary>
        private Dictionary<TKey, Student> _students = new Dictionary<TKey, Student>();

        /// <summary>
        /// Делегат для изменения коллекции
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="sourse"></param>
        /// <param name="args"></param>
        public delegate void StudentsChangedHandler<TKey>(object sourse, StudentsChangedEventArgs<TKey> args);

        /// <summary>
        /// Событие для изменений коллекции
        /// </summary>
        public event StudentsChangedHandler<TKey> StudentsChanged;

        /// <summary>
        /// Делегат для селектора
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="st"></param>
        /// <returns></returns>
        public delegate TKey KeySelector<TKey>(Student st);

        /// <summary>
        /// Селектор ключа
        /// </summary>
        private readonly KeySelector<TKey> _keySelector;

        public StudentCollection(KeySelector<TKey> selector)
        {
            _keySelector = selector;
        }


        /// <summary>
        /// Название коллекции 
        /// </summary>
        public string CollectionName { get; set; } = "ListCollection";

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
                item.PropertyChanged += Item_PropertyChanged;

                if (_students.ContainsKey(_keySelector(item)))
                    _students[_keySelector(item)] = item;
                else
                    _students.Add(_keySelector(item), item);

                if (StudentsChanged != null)
                    StudentsChanged.Invoke(this, new StudentsChangedEventArgs<TKey>(CollectionName, Practice4_2.Models.Enums.ActionEnum.Add, nameof(_students), _keySelector(item)));
            }
        }

        /// <summary>
        /// Обработчик события изменения свойств студента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            StudentsChanged.Invoke(sender, new StudentsChangedEventArgs<TKey>(CollectionName, Practice4_2.Models.Enums.ActionEnum.Property, e.PropertyName, _keySelector((Student)sender)));
        }


        /// <summary>
        /// Добавление дефолтных значений
        /// </summary>
        public void AddDefaults(int count)
        {
            for(int i = 0; i < count; i++)
            {
                var stud = new Student();
                stud.PropertyChanged += Item_PropertyChanged;

                stud.Exams = new List<Exam>();
                for(int j = 0; j < 5; j++)
                {
                    stud.Exams.Add(new Exam());
                }
                _students.Add(_keySelector(stud), stud);
                if (StudentsChanged != null)
                    StudentsChanged.Invoke(this, new StudentsChangedEventArgs<TKey>(CollectionName, Practice4_2.Models.Enums.ActionEnum.Add, nameof(_students), _keySelector(stud)));

            }
        }


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
        /// Получение перечисления
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


        /// <summary>
        /// Метод удаления элемента
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        public bool Remove(Student st)
        {
            try
            {
                var key = _students.FirstOrDefault(c => c.Value == st);
                if (key.Key != null)
                {
                    if (StudentsChanged != null)
                    {
                        StudentsChanged.Invoke(this, new StudentsChangedEventArgs<TKey>(CollectionName, Practice4_2.Models.Enums.ActionEnum.Remove, nameof(_students), key.Key));
                        key.Value.PropertyChanged -= Item_PropertyChanged;
                    }
                    _students.Remove(key.Key);
                }
                else
                    return false;

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
        public KeyValuePair<TKey, Student> this[int index]
        {
            get => _students.ElementAt(index);
            set
            {
                if (_students.ContainsKey(value.Key))
                    _students[value.Key] = value.Value;
                else
                    _students.Add(value.Key, value.Value);

                if(StudentsChanged != null)
                    StudentsChanged.Invoke(this, new StudentsChangedEventArgs<TKey>(CollectionName, Practice4_2.Models.Enums.ActionEnum.Add, nameof(_students), value.Key));
            }
        }


    }
}

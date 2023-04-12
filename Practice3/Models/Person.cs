using Practice.Extensions;
using Practice.Models.Consts;
using Practice2.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Models
{
    /// <summary>
    /// Класс человека
    /// </summary>
    public class Person : IDateAndCopy, IComparer<Person>, IComparable
    {
        /// <summary>
        /// Имя
        /// </summary>
        protected string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        protected string _lastName;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth
        {
            get => Date;
            set => Date = value;
        }

        /// <summary>
        /// Год рождения
        /// </summary>
        public int CustomizeDateOfBirthYear
        {
            get
            {
                return Date.Year;
            }
            set
            {
                Date = Date.AddYears(-Date.Year).AddYears(value);
            }
        }

        public DateTime Date { get; set; }

        /// <summary>
        /// Конструктор заполняющий дефолтными значениями
        /// </summary>
        public Person()
        {
            _name = ProgramConsts.DefaultName;
            _lastName = StringExtension.GetRandom(10);
            Date = DateTime.Now.AddYears(-(new Random().Next(1, 20)));
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public Person(string name, string lastName, DateTime datetime)
        {
            _name = name;
            _lastName = lastName;
            Date = datetime;
        }

        /// <summary>
        /// Получение строки со всеми полями класса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Имя: {_name}, Фамилия: {_lastName}, Дата рождения {Date}";
        }

        /// <summary>
        /// Получение строки с именем и фамилией
        /// </summary>
        /// <returns></returns>
        public virtual string ToShortString()
        {
            return $"Имя: {_name}, Фамилия: {_lastName}";
        }

        /// <summary>
        /// Сравнение оьъектов
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            var person = (Person?)obj;
            return this.Name == person.Name && LastName == person.LastName && DateOfBirth == person.DateOfBirth;
        }


        /// <summary>
        /// Проверка на равенство
        /// </summary>
        /// <param name="person1"></param>
        /// <param name="person2"></param>
        /// <returns></returns>
        public static bool operator == (Person person1, Person person2)
        {
            if(person1 is null)
            {
                if(person2 is null)
                {
                    return true;
                }
                return false;
            }

            return person1.Equals(person2);
        }

        /// <summary>
        /// Проверка на неравенство
        /// </summary>
        /// <param name="person1"></param>
        /// <param name="person2"></param>
        /// <returns></returns>
        public static bool operator != (Person person1, Person person2)
        {
            return !(person1 == person2);
        }


        /// <summary>
        /// Получение хэш кода
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (Name, LastName, DateOfBirth).GetHashCode();
        }

        /// <summary>
        /// Создание полной копии
        /// </summary>
        /// <returns></returns>
        public virtual object DeepCopy()
        {
            return new Person(this.Name, this.LastName, this.DateOfBirth);
        }

        /// <summary>
        /// Сравнение даты
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int Compare(Person? x, Person? y)
        {
            if(x is null || y is null)
                throw new Exception("Объект равен null");

            if (x.DateOfBirth > y.DateOfBirth)
            {
                return 1;
            }
            else if (x.DateOfBirth < y.DateOfBirth)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение объекта по фамилии
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int CompareTo(object? obj)
        {
            if (obj is Person person)
                return LastName.CompareTo(person.LastName);

            throw new Exception("Объект не является типом " + nameof(Person));
        }
    }
}

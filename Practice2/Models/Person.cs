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
    public class Person : IDateAndCopy
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

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Конструктор заполняющий дефолтными значениями
        /// </summary>
        public Person()
        {
            _name = ProgramConsts.DefaultName;
            _lastName = ProgramConsts.DefaultLastName;
            Date = DateTime.Now.AddYears(-20);
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
            return this.Name == person.Name && LastName == person.LastName && Date == person.Date;
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
            return (Name, LastName, Date).GetHashCode();
        }

        /// <summary>
        /// Создание полной копии
        /// </summary>
        /// <returns></returns>
        public virtual object DeepCopy()
        {
            return new Person(this.Name, this.LastName, this.Date);
        }
    }
}

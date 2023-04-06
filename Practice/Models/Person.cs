using Practice.Models.Consts;
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
    public class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Дата рождения
        /// </summary>
        private DateTime _dateOfBirth;

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
            get => _dateOfBirth;
            set => _dateOfBirth = value;
        }

        /// <summary>
        /// Год рождения
        /// </summary>
        public int CustomizeDateOfBirthYear
        {
            get
            {
                return _dateOfBirth.Year;
            }
            set
            {
                _dateOfBirth = _dateOfBirth.AddYears(-_dateOfBirth.Year).AddYears(value);
            }
        }

        /// <summary>
        /// Конструктор заполняющий дефолтными значениями
        /// </summary>
        public Person()
        {
            _name = ProgramConsts.DefaultName;
            _lastName = ProgramConsts.DefaultLastName;
            _dateOfBirth = DateTime.Now.AddYears(-20);
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        public Person(string name, string lastName, DateTime datetime)
        {
            _name = name;
            _lastName = lastName;
            _dateOfBirth = datetime;
        }

        /// <summary>
        /// Получение строки со всеми полями класса
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Имя: {_name}, Фамилия: {_lastName}, Дата рождения {_dateOfBirth}";
        }

        /// <summary>
        /// Получение строки с именем и фамилией
        /// </summary>
        /// <returns></returns>
        public virtual string ToShortString()
        {
            return $"Имя: {_name}, Фамилия: {_lastName}";
        }
    }
}

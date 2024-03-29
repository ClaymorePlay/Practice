﻿using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3.Models
{
    /// <summary>
    /// Тест коллекций
    /// </summary>
    public class TestCollections
    {
        /// <summary>
        /// Список для теста
        /// </summary>
        public List<Person> TestTKeys;

        /// <summary>
        /// Список для теста
        /// </summary>
        public List<string> TestTString;

        /// <summary>
        /// Словарь для теста где ключом выступает класс пользователя
        /// </summary>
        public Dictionary<Person, Student> TestDictionaryTKey;

        /// <summary>
        /// Словарь для теста где ключом выступает строка класса
        /// </summary>
        public Dictionary<string, Student> TestDictionaryString;

        /// <summary>
        /// Тестовый студент
        /// </summary>
        private static Student _setedStudent;

        /// <summary>
        /// Генерация случайных чисел
        /// </summary>
        private static Random _random = new Random(DateTime.Now.Millisecond);

        public TestCollections(int count)
        {
            TestTKeys = new List<Person>();
            TestTString = new List<string>();
            TestDictionaryTKey = new Dictionary<Person, Student>();
            TestDictionaryString = new Dictionary<string, Student>();

            for (int i = 0; i < count; i++)
            {
                TestTKeys.Add(new Person(i.ToString(), i.ToString(), DateTime.UtcNow));
                TestTString.Add(new Person(i.ToString(), i.ToString(), DateTime.UtcNow).ToString());

                var newPerson = new Person(i.ToString(), i.ToString(), DateTime.UtcNow);
                TestDictionaryString.Add(newPerson.ToString(), new Student(newPerson, Practice.Models.Enums.EducationEnum.SecondEducation, _random.Next(1, 200)));

                var newPerson2 = new Person(i.ToString(), i.ToString(), DateTime.UtcNow);
                TestDictionaryTKey.Add(newPerson2, new Student(newPerson2, Practice.Models.Enums.EducationEnum.SecondEducation, _random.Next(1, 200)));
            }
        }

        public static Student SetStudentForTestCollection(int count)
        {
            _setedStudent = new Student();
            return _setedStudent;
        }


         /// <summary>
        /// Получение времени на поиск элемента в коллекциях
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetTimeForFindItem(int index)
        {
            var response = "";

            var item_1 = TestTKeys.ElementAtOrDefault(index) ?? new Person();
            var startTest1 = Environment.TickCount64;
            var firstItem = TestTKeys.Contains(item_1);
            var endTest1 = Environment.TickCount64;
            response += "\nЭлемент типа List<Person> был найден за " + (endTest1 - startTest1) + "ms";

            var item_2 = TestTString.ElementAtOrDefault(index) ?? "NotContainsItem";
            var startTest2 = Environment.TickCount64;
            var firstItem2 = TestTString.Contains(item_2);
            var endTest2 = Environment.TickCount64;
            response += "\nЭлемент типа List<string> был найден за " + (endTest2 - startTest2) + "ms";

            var testItem3 = TestDictionaryTKey.Keys.ElementAtOrDefault(index) ?? new Person();
            var startTest3 = Environment.TickCount64;
            var firstItem3 = TestDictionaryTKey.ContainsKey(testItem3);
            var endTest3 = Environment.TickCount64;
            response += "\nЭлемент типа Dictionary<Person, Student> был найден по ключу за " + (endTest3 - startTest3) + "ms";

            var testItem4 = TestDictionaryString.Keys.ElementAtOrDefault(index) ?? "NotContainsItem";
            var startTest4 = Environment.TickCount64;
            var firstItem4 = TestDictionaryString.ContainsKey(testItem4);
            var endTest4 = Environment.TickCount64;
            response += "\nЭлемент типа Dictionary<string, Student> был найден по клюу за " + (endTest4 - startTest4) + "ms";

            var testItem5 = TestDictionaryTKey.Values.ElementAtOrDefault(index) ?? new Student();
            var startTest5 = Environment.TickCount64;
            var firstItem5 = TestDictionaryTKey.ContainsValue(testItem5);
            var endTest5 = Environment.TickCount64;
            response += "\nЭлемент типа Dictionary<Person, Student> был найден по значению за " + (endTest5 - startTest5) + "ms";

            var testItem6 = TestDictionaryString.Values.ElementAtOrDefault(index) ?? new Student();
            var startTest6 = Environment.TickCount64;
            var firstItem6 = TestDictionaryString.ContainsValue(testItem6);
            var endTest6 = Environment.TickCount64;
            response += "\nЭлемент типа Dictionary<string, Student> был найден по значению за " + (endTest6 - startTest6) + "ms";


            return response;
        }
    }
}

using Practice.Models;
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

            var startTest1 = Environment.TickCount64;
            var firstItem = TestTKeys[index];
            var endTest1 = Environment.TickCount64;
            response += "\nЭлемент типа List<Person> был найден за " + (endTest1 - startTest1) + "ms";

            var startTest2 = Environment.TickCount64;
            var firstItem2 = TestTString[index];
            var endTest2 = Environment.TickCount64;
            response += "\nПервый элемент типа List<string> был найден за " + (endTest2 - startTest2) + "ms";

            var startTest3 = Environment.TickCount64;
            var firstItem3 = TestDictionaryTKey.ElementAt(index);
            var endTest3 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<Person, Student> был найден по ключу за " + (endTest3 - startTest3) + "ms";

            var startTest4 = Environment.TickCount64;
            var firstItem4 = TestDictionaryString.ElementAt(index);
            var endTest4 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<string, Student> был найден по клюу за " + (endTest4 - startTest4) + "ms";

            var startTest5 = Environment.TickCount64;
            var firstItem5 = TestDictionaryTKey.First(c => c.Value == TestDictionaryTKey.ElementAt(index).Value);
            var endTest5 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<Person, Student> был найден по значению за " + (endTest5 - startTest5) + "ms";

            var startTest6 = Environment.TickCount64;
            var firstItem6 = TestDictionaryString.First(c => c.Value == TestDictionaryTKey.ElementAt(index).Value);
            var endTest6 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<string, Student> был найден по значению за " + (endTest6 - startTest6) + "ms";

            return response;
        }

        /// <summary>
        /// Получение времени нахождения не содержащегося значения 
        /// </summary>
        /// <returns></returns>
        public string GetTimeForNotFindItem()
        {
            var response = "";

            var startTest1 = Environment.TickCount64;
            var firstItem = TestTKeys.FirstOrDefault(c => c.Name == "-1");
            var endTest1 = Environment.TickCount64;
            response += "\nЭлемент типа List<Person> был найден за " + (endTest1 - startTest1) + "ms";

            var startTest2 = Environment.TickCount64;
            var firstItem2 = TestTString.FirstOrDefault(c => c == "-1");
            var endTest2 = Environment.TickCount64;
            response += "\nПервый элемент типа List<string> был найден за " + (endTest2 - startTest2) + "ms";

            var startTest3 = Environment.TickCount64;
            var firstItem3 = TestDictionaryTKey.FirstOrDefault(c => c.Key.Name == "-1");
            var endTest3 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<Person, Student> был найден по ключу за " + (endTest3 - startTest3) + "ms";

            var startTest4 = Environment.TickCount64;
            var firstItem4 = TestDictionaryString.FirstOrDefault(c => c.Key == "-1");
            var endTest4 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<string, Student> был найден по клюу за " + (endTest4 - startTest4) + "ms";

            var startTest5 = Environment.TickCount64;
            var firstItem5 = TestDictionaryTKey.First(c => c.Value.Name == "-1");
            var endTest5 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<Person, Student> был найден по значению за " + (endTest5 - startTest5) + "ms";

            var startTest6 = Environment.TickCount64;
            var firstItem6 = TestDictionaryString.First(c => c.Value.Name == "-1");
            var endTest6 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<string, Student> был найден по значению за " + (endTest6 - startTest6) + "ms";

            return response;
        }
    }
}

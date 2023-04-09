using Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice3.Models
{
    public class TestCollections
    {
        public List<Person> TestTKeys;

        public List<string> TestTString;

        public Dictionary<Person, Student> TestDictionaryTKey;

        public Dictionary<string, Student> TestDictionaryString;

        private static Student _setedStudent;

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

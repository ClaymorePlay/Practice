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

        public TestCollections(int count)
        {
            TestTKeys = new List<Person>();
            TestTString = new List<string>();
            TestDictionaryTKey = new Dictionary<Person, Student>();
            TestDictionaryString = new Dictionary<string, Student>();

            for (int i = 0; i < count; i++)
            {
                TestTKeys.Add(new Person());
                TestTString.Add(new Person().ToString());
                TestDictionaryString.Add(new Person().ToString(), new Student());
                TestDictionaryTKey.Add(new Person(), new Student());
            }
        }

        public static Student SetStudentForTestCollection(int count)
        {
            _setedStudent = new Student();
            return _setedStudent;
        }


        public string GetTimeForFirstItem()
        {
            var response = "";

            var startTest1 = Environment.TickCount64;
            var firstItem = TestTKeys.First();
            var endTest1 = Environment.TickCount64;
            response += "Первый элемент типа List<Person> был найден за " + (endTest1 - startTest1) + "ms";


            return response;
        }
    }
}

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
    public class TestCollections<TKey, TValue>
    {
        public delegate KeyValuePair<TKey, TValue> GenerateElement(int j);


        /// <summary>
        /// Список для теста
        /// </summary>
        public List<TKey> TestTKeys;

        /// <summary>
        /// Список для теста
        /// </summary>
        public List<string> TestTString;

        /// <summary>
        /// Словарь для теста где ключом выступает класс пользователя
        /// </summary>
        public Dictionary<TKey, TValue> TestDictionaryTKey;

        /// <summary>
        /// Словарь для теста где ключом выступает строка класса
        /// </summary>
        public Dictionary<string, TValue> TestDictionaryString;

        /// <summary>
        /// Клю-значение для теста
        /// </summary>
        private GenerateElement _testGenerateElement;

        /// <summary>
        /// Генерация случайных чисел
        /// </summary>
        private static Random _random = new Random(DateTime.Now.Millisecond);

        public TestCollections(int count, GenerateElement gen)
        {
            _testGenerateElement = gen;
            TestTKeys = new List<TKey>();
            TestTString = new List<string>();
            TestDictionaryTKey = new Dictionary<TKey, TValue>();
            TestDictionaryString = new Dictionary<string, TValue>();

            for (int i = 0; i < count; i++)
            {
                TestTKeys.Add(_testGenerateElement(i).Key);
                TestTString.Add(new Person(i.ToString(), i.ToString(), DateTime.UtcNow).ToString());

                var newPerson = _testGenerateElement(i);
                TestDictionaryString.Add(newPerson.Key.ToString(), newPerson.Value);

                var newPerson2 = _testGenerateElement(i);
                TestDictionaryTKey.Add(newPerson2.Key, newPerson2.Value);
                //TestGenerateElement.Add();
            }
        }




        /// <summary>
        /// Получение времени на поиск элемента в коллекциях
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetTimeForFindItem(int index)
        {
            var response = "";

            var item_1 = TestTKeys.ElementAtOrDefault(index) ?? _testGenerateElement(1).Key;
            var startTest1 = Environment.TickCount64;
            var firstItem = TestTKeys.Contains(item_1);
            var endTest1 = Environment.TickCount64;
            response += "\nЭлемент типа List<Person> был найден за " + (endTest1 - startTest1) + "ms";

            var item_2 = TestTString.ElementAtOrDefault(index) ?? "NotContainsItem";
            var startTest2 = Environment.TickCount64;
            var firstItem2 = TestTString.Contains(item_2);
            var endTest2 = Environment.TickCount64;
            response += "\nПервый элемент типа List<string> был найден за " + (endTest2 - startTest2) + "ms";

            var testItem3 = TestDictionaryTKey.Keys.ElementAtOrDefault(index) ?? _testGenerateElement(1).Key;
            var startTest3 = Environment.TickCount64;
            var firstItem3 = TestDictionaryTKey.ContainsKey(testItem3);
            var endTest3 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<Person, Student> был найден по ключу за " + (endTest3 - startTest3) + "ms";

            var testItem4 = TestDictionaryString.Keys.ElementAtOrDefault(index) ?? "NotContainsItem";
            var startTest4 = Environment.TickCount64;
            var firstItem4 = TestDictionaryString.ContainsKey(testItem4);
            var endTest4 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<string, Student> был найден по клюу за " + (endTest4 - startTest4) + "ms";

            var testItem5 = TestDictionaryTKey.Values.ElementAtOrDefault(index) ?? _testGenerateElement(1).Value;
            var startTest5 = Environment.TickCount64;
            var firstItem5 = TestDictionaryTKey.ContainsValue(testItem5);
            var endTest5 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<Person, Student> был найден по значению за " + (endTest5 - startTest5) + "ms";

            var testItem6 = TestDictionaryString.Values.ElementAtOrDefault(index) ?? _testGenerateElement(1).Value;
            var startTest6 = Environment.TickCount64;
            var firstItem6 = TestDictionaryString.ContainsValue(testItem6);
            var endTest6 = Environment.TickCount64;
            response += "\nПервый элемент типа Dictionary<string, Student> был найден по значению за " + (endTest6 - startTest6) + "ms";


            return response;
        }

      
    }
}

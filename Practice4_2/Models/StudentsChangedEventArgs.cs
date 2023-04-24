using Practice.Models;
using Practice4_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4_2.Models
{
    public class StudentsChangedEventArgs<TKey>  : EventArgs
    {
        /// <summary>
        /// Название теста
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>
        /// Название операции проводимой над коллекций
        /// </summary>
        public ActionEnum OperationName { get; set; }

        /// <summary>
        /// Объект студента
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Ключ
        /// </summary>
        public TKey Key { get; set; }

        public StudentsChangedEventArgs(string collectionName, ActionEnum action, string prop, TKey key)
        {
            Property = prop;
            CollectionName = collectionName;
            OperationName = action;
            Key = key;
        }

        public StudentsChangedEventArgs() { }

        /// <summary>
        /// Получение строки с объекта
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Название коллекции: {CollectionName}\nТип операции: {OperationName}\nСвойство: {Property}\nКлюч: {Key}";
        }
    }
}

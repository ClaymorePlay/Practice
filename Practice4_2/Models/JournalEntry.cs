using Practice4_2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4.Models
{
    /// <summary>
    /// Журнал операций
    /// </summary>
    public class JournalEntry
    {
        /// <summary>
        /// Название коллекции запись которой создана
        /// </summary>
        public string CollectionName { get; set; }

        /// <summary>
        /// Название операции
        /// </summary>
        public ActionEnum OperationName { get; set; }

        /// <summary>
        /// Информация о студенте
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Ключ
        /// </summary>
        public string Key { get; set; }

        public JournalEntry(string collectionName, ActionEnum operationName, string student)
        {
            CollectionName = collectionName;
            OperationName = operationName;
            Property = student;
        }

        public JournalEntry() { }

        /// <summary>
        /// Преобразование к строке
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Название коллекции: {CollectionName}\nНазвание операции: {OperationName}\n:Свойство: {Property}\nКлюч: {Key} ";
        }
    }
}

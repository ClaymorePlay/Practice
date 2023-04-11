using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4.Models
{
    public class JournalEntry
    {
        public string CollectionName { get; set; }

        public string OperationName { get; set; }

        public string Student { get; set; }

        public JournalEntry(string collectionName, string operationName, string student)
        {
            CollectionName = collectionName;
            OperationName = operationName;
            Student = student;
        }

        public JournalEntry() { }

        public override string ToString()
        {
            return $"Название коллекции: {CollectionName}\nНазвание операции: {OperationName}\nСтудент:{Student}";
        }
    }
}

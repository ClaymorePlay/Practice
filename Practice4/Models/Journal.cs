using Practice3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice4.Models
{
    public class Journal
    {
        /// <summary>
        /// Список записей журнала
        /// </summary>
        private List<JournalEntry> _journalsEntry;

        public Journal()
        {
            _journalsEntry = new List<JournalEntry>();
        }

        /// <summary>
        /// Обработчик обновления студента
        /// </summary>
        /// <param name="sourse"></param>
        /// <param name="args"></param>
        public void StudentReferenceChanged(object sourse, StudentListHandlerEventArgs args)
        {
            _journalsEntry.Add(new JournalEntry
            {
                CollectionName = args.Name,
                OperationName = args.OperationName,
                Student = args.Student.ToString()
            });
        }

        /// <summary>
        /// Обработчик обновления списка студентов
        /// </summary>
        /// <param name="sourse"></param>
        /// <param name="args"></param>
        public void StudentsCountChanged(object sourse, StudentListHandlerEventArgs args)
        {
            _journalsEntry.Add(new JournalEntry
            {
                CollectionName = args.Name,
                OperationName = args.OperationName,
                Student = args.Student.ToString()
            });
        }

        /// <summary>
        /// Конверт к строке
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Join("\n___________________\n", _journalsEntry.Select(c => c.ToString()));
        }
    }
}

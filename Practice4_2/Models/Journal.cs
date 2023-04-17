using Practice3.Models;
using Practice4_2.Models;
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
        /// Обработчик обновления списка студентов
        /// </summary>
        /// <param name="sourse"></param>
        /// <param name="args"></param>
        public void StudentsCountChanged(object sourse, StudentsChangedEventArgs<string> args)
        {
            _journalsEntry.Add(new JournalEntry
            {
                CollectionName = args.CollectionName,
                OperationName = args.OperationName,
                Property = args.Property,
                Key = args.Key,
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

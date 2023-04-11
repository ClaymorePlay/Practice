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
        private List<JournalEntry> _journalsEntry;

        public Journal()
        {
            _journalsEntry = new List<JournalEntry>();
        }

        public void StudentReferenceChanged(object sourse, StudentListHandlerEventArgs args)
        {
            _journalsEntry.Add(new JournalEntry
            {
                CollectionName = args.Name,
                OperationName = args.OperationName,
                Student = args.Student.ToString()
            });
        }

        public void StudentsCountChanged(object sourse, StudentListHandlerEventArgs args)
        {
            _journalsEntry.Add(new JournalEntry
            {
                CollectionName = args.Name,
                OperationName = args.OperationName,
                Student = args.Student.ToString()
            });
        }


        public override string ToString()
        {
            return String.Join("\n___________________\n", _journalsEntry.Select(c => c.ToString()));
        }
    }
}

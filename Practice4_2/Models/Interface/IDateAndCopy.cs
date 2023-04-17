using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2.Models.Interfaces
{
    public interface IDateAndCopy 
    {
        /// <summary>
        /// Копирование
        /// </summary>
        /// <returns></returns>
        object DeepCopy();

        /// <summary>
        /// Дата
        /// </summary>
        DateTime Date { get; set; }
    }
}

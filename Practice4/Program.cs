
using Practice.Models;
using Practice3.Models;
using Practice4.Models;
using System.Collections;

public class Program
{
    static void Main(string[] args)
    {
        //Создание двух коллекций студентов
        var collection1 = new StudentCollection();
        var collection2 = new StudentCollection();

        //Присваивание имен коллекциям
        collection1.CollectionName = "TestListCollection1";
        collection2.CollectionName = "TestListCollection2";

        //Создание двух журналов
        var journal1 = new Journal();
        var journal2 = new Journal();

        //Подписки на события обновления списков
        collection1.StudentsCountChanged += journal1.StudentsCountChanged;
        collection1.StudentReferenceChanged += journal1.StudentReferenceChanged;
        collection2.StudentReferenceChanged += journal2.StudentReferenceChanged;
        collection1.StudentReferenceChanged += journal2.StudentReferenceChanged;

        //Добавление студентов
        collection1.AddStudents(new Practice.Models.Student(), new Student());
        collection2.AddStudents(new Practice.Models.Student(), new Student());

        //Удаленпие
        collection1.Remove(0);
        collection2.Remove(0);

        //Обновление существующего
        collection1[0] = new Student();
        collection2[0] = new Student();

        ///Вывод на экран
        Console.WriteLine(journal1.ToString());
        Console.WriteLine(journal2.ToString());
    }
}


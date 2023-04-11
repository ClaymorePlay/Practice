
using Practice.Models;
using Practice3.Models;
using Practice4.Models;
using System.Collections;

public class Program
{
    static void Main(string[] args)
    {
        var collection1 = new StudentCollection();
        var collection2 = new StudentCollection();

        collection1.CollectionName = "TestListCollection1";
        collection2.CollectionName = "TestListCollection2";

        var journal1 = new Journal();
        var journal2 = new Journal();

        collection1.StudentsCountChanged += journal1.StudentsCountChanged;
        collection1.StudentReferenceChanged += journal1.StudentReferenceChanged;
        collection2.StudentReferenceChanged += journal2.StudentReferenceChanged;
        collection1.StudentReferenceChanged += journal2.StudentReferenceChanged;


        collection1.AddStudents(new Practice.Models.Student(), new Student());
        collection2.AddStudents(new Practice.Models.Student(), new Student());

        collection1.Remove(0);
        collection2.Remove(0);

        collection1[0] = new Student();
        collection2[0] = new Student();

        Console.WriteLine(journal1.ToString());
        Console.WriteLine(journal2.ToString());
    }
}


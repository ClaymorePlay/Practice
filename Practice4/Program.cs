
using Practice3.Models;
using System.Collections;

public class Program
{
    static void Main(string[] args)
    {
        var studentCollection = new StudentCollection();
        studentCollection.AddDefaults(10);
        Console.WriteLine(studentCollection.ToString() + "\n");

        Console.ResetColor();
        studentCollection.SortByLastName();
        Console.WriteLine("Сортировка по фамилии:" + studentCollection.ToString());

        studentCollection.SortByDate();
        Console.WriteLine("Сортировка по дате: " + studentCollection.ToString());

        studentCollection.SortByGrage();
        Console.WriteLine("Сортировка по оценке:" + studentCollection.ToString());

        Console.WriteLine();
        Console.WriteLine("Максимальный средний балл: " + studentCollection.MaxGrade);
        Console.WriteLine("Специалисты: \n" + String.Join("\n", studentCollection.StudentsWithSpecialist.Select(c => c.ToString())));
        Console.WriteLine("Группировка по сред баллу: \n" + String.Join("\n", studentCollection.AverageMarkGroup(3).Select(c => c.ToString())));

        var count = 1000000;
        var test = new TestCollections(count);
        Console.WriteLine("\n\n" + test.GetTimeForFindItem(count - 1));
        Console.WriteLine("\n\n" + test.GetTimeForFindItem(0));
        Console.WriteLine("\n\n" + test.GetTimeForFindItem(count / 2));
        Console.WriteLine("\n\n" + test.GetTimeForNotFindItem());
    }
}


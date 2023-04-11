
using Practice.Models;
using Practice3.Models;
using Practice4.Models;
using System.Collections;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;

public class Program
{
    static void Main(string[] args)
    {
        var student = new Student();
        student.AddExams(new List<Exam>
        {
            new Exam(),
            new Exam()
        });

        student.AddFromConsole();
        Console.WriteLine();

        var copy = student.DeepCopy();

        Console.WriteLine("Оригинал:");
        Console.WriteLine(student.ToString());
        Console.WriteLine("\nКопия:");
        Console.WriteLine(copy.ToString());
        Console.WriteLine();

        Console.Write("\nВведите имя файла: ");
        var filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            Console.WriteLine("Файла не существует");
            File.Create(filename);

        }
        else
        {
            student.Load(filename);
        }

        Console.WriteLine();
        Console.WriteLine(student.ToString());

        student.AddFromConsole();
        student.Save(filename);

        Console.WriteLine();
        Console.WriteLine(student.ToString());

        Student.Load(filename, student);
        student.AddFromConsole();
        Student.Save(filename, student);

        Console.WriteLine();
        Console.WriteLine(student.ToString());
    }
}


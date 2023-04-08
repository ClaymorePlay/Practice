
using Practice.Models;
using Practice.Models.Consts;
using Practice2.Models;
using System.Collections;

public class Program
{
    static void Main(string[] args)
    {
        var person1 = new Person(ProgramConsts.DefaultName, ProgramConsts.DefaultLastName, new DateTime(2022, 1, 1));
        var person2 = new Person(ProgramConsts.DefaultName, ProgramConsts.DefaultLastName, new DateTime(2022,1,1));

        Console.WriteLine($"Равенство объектов: {person1.Equals(person2)}");
        Console.WriteLine($"Равенство ссылок: {Object.ReferenceEquals(person1, person2)}");
        Console.WriteLine($"Хэш коды: \n{person1.GetHashCode()}\n{person2.GetHashCode()}");


        var newSudent = new Student();
        ArrayList exams = new ArrayList();
        ArrayList tests = new ArrayList();

        for(int i = 0; i < 10; i++)
        {
            exams.Add(new Exam());
            tests.Add(new Test());
        }

        newSudent.AddExams(exams);
        newSudent.AddTests(tests);

        Console.WriteLine(newSudent.ToString());

        Console.WriteLine("\nЗначения person из student: " + ((Person)newSudent).ToString());

        var copyStudent = newSudent.DeepCopy();

        newSudent.Name = "UpdatedName";
        newSudent.LastName = "UpdatedLastName";
        newSudent.GroupNumber = 200;
        newSudent.Education = Practice.Models.Enums.EducationEnum.SecondEducation;
        newSudent.DateOfBirth = new DateTime(2023,1,1);
        newSudent.Exams[0] = new Exam("TestExam", 1, DateTime.Now);
        newSudent.Tests[0] = new Test("TestTest", true);

        Console.WriteLine($"Оригинал: \n{newSudent.ToString()}");
        Console.WriteLine($"Копия: \n{copyStudent.ToString()}");

        try
        {
            newSudent.GroupNumber = 1;
        }
        catch(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }

        Console.WriteLine($"\nВывод с использованием итератора:");
        foreach(var value in newSudent.GetEnumerator(null))
        {
            Console.WriteLine(value.ToString());
        }
        Console.WriteLine($"\nВывод с использованием итератора с параметром:");
        foreach (var value in newSudent.GetEnumerator(3))
        {
            Console.WriteLine(value.ToString());
        }
    }
}


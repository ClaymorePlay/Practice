
using Practice.Models;
using Practice.Models.Consts;
using Practice2.Models;
using System.Collections;

public class Program
{
    static void Main(string[] args)
    {
        //Добавление двух человвек
        var person1 = new Person(ProgramConsts.DefaultName, ProgramConsts.DefaultLastName, new DateTime(2022, 1, 1));
        var person2 = new Person(ProgramConsts.DefaultName, ProgramConsts.DefaultLastName, new DateTime(2022,1,1));

        //Вывод информации
        Console.WriteLine($"Равенство объектов: {person1.Equals(person2)}");
        Console.WriteLine($"Равенство ссылок: {Object.ReferenceEquals(person1, person2)}");
        Console.WriteLine($"Хэш коды: \n{person1.GetHashCode()}\n{person2.GetHashCode()}");

        //Добавление нового студента и двух списков
        var newSudent = new Student();
        ArrayList exams = new ArrayList();
        ArrayList tests = new ArrayList();

        //Заполнение списков
        for(int i = 0; i < 10; i++)
        {
            exams.Add(new Exam());
            tests.Add(new Test());
        }

        //Добавление экзаменов и зачетов
        newSudent.AddExams(exams);
        newSudent.AddTests(tests);
        //Вывод ифнормации
        Console.WriteLine(newSudent.ToString());
        
        Console.WriteLine("\nЗначения person из student: " + ((Person)newSudent).ToString());
        try
        {
            //Копирование студента
            var copyStudent = newSudent.DeepCopy();

            //Изменение оригинала
            newSudent.Name = "UpdatedName";
            newSudent.LastName = "UpdatedLastName";
            newSudent.GroupNumber = 200;
            newSudent.Education = Practice.Models.Enums.EducationEnum.SecondEducation;
            newSudent.Date = new DateTime(2023,1,1);
            newSudent.Exams[0] = new Exam("TestExam", 1, DateTime.Now);
            newSudent.Tests[0] = new Test("TestTest", true);

            Console.WriteLine($"Оригинал: \n{newSudent.ToString()}");
            Console.WriteLine($"Копия: \n{copyStudent.ToString()}");

        
            newSudent.GroupNumber = 1;
        }
        catch(Exception ex)
        {
            //Вывод ошибки
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }

        //Перечисление экзаменов и зачетов
        Console.WriteLine($"\nВывод с использованием итератора:");
        foreach(var value in newSudent.GetEnumerator(null))
        {
            Console.WriteLine(value.ToString());
        }
        //Вывод экзаменов у которых оценка выше 3-х
        Console.WriteLine($"\nВывод с использованием итератора с параметром:");
        foreach (var value in newSudent.GetEnumerator(3))
        {
            Console.WriteLine(value.ToString());
        }
    }
}


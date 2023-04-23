
using Practice.Extensions;
using Practice.Models;
using Practice.Models.Enums;
using Practice3.Models;
using System.Collections;
using System.Net.Http.Headers;

public class Program
{

    static void Main(string[] args)
    {
        //Создание коллекции студентов
        var student = new Student();
        //Добавление стуентов по умолчанию
        student.AddExams(new List<Exam> { new Exam(), new Exam(), new Exam()}) ;
        //Вывод
        WriteInfo("Получение первоначальных данных студента:", ConsoleColor.Green);
        Console.WriteLine(student.ToString() + "\n");

        //Сортировка по названию
        student.SortByNameSubject();
        WriteInfo("Сортировка по названию: ", ConsoleColor.Green);
        Console.WriteLine(student.ToString());

        //Сортировка по дате
        student.SortByDate();
        WriteInfo("Сортировка по дате: ", ConsoleColor.Green);
        Console.WriteLine(student.ToString());

        //Сортировка по оценке
        student.SortByGrade();
        WriteInfo("Сортировка по оценке: ", ConsoleColor.Green);
        Console.WriteLine(student.ToString());

        var collection = new StudentCollection<string>(GetRandomValue);
        collection.AddDefaults(10);

        WriteInfo("Вывод списка студентов: ", ConsoleColor.Green);
        Console.WriteLine(collection.ToString());

        WriteInfo("Максимальный балл: ", ConsoleColor.Green);
        Console.WriteLine(collection.MaxGrade);

        WriteInfo("Получение студентов по образованию: ", ConsoleColor.Green);
        Console.Write("Введите номер образования для вывода студентов с таким же номером: ");
        EducationEnum education = (EducationEnum)Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(String.Join('\n', collection.EducationForm(education).Select(c => c.ToString() + "\n")));

        WriteInfo("Получение студентов сгруппированных по образованиям: ", ConsoleColor.Green);
        foreach(var item in collection.GetEducationGroup)
        {
            Console.WriteLine($"Группа {item.Key}\n" + String.Join('\n', item.Select(h => h.Value.ToString())));
        }


        //Тестирование коллекций элементов
        WriteInfo("Тестирование коллекция элементов: ", ConsoleColor.Green);
        Console.Write("Введите число для определения размера коллекций: ");
        var count = Convert.ToInt32(Console.ReadLine());
        var test = new TestCollections<Person, Student>(count, GetRandomPerson);

        WriteInfo("\n\nПоиск последнего: ", ConsoleColor.Green);
        Console.WriteLine(test.GetTimeForFindItem(count - 1));
        WriteInfo("\n\nПоиск первого: ", ConsoleColor.Green);
        Console.WriteLine( test.GetTimeForFindItem(0));
        WriteInfo("\n\nПоиск Центрального: ", ConsoleColor.Green);
        Console.WriteLine(test.GetTimeForFindItem(count / 2));
        WriteInfo("\n\nПоиск не существующего: ", ConsoleColor.Green);
        Console.WriteLine(test.GetTimeForFindItem(count));
    }

    /// <summary>
    /// Создание ключа
    /// </summary>
    /// <param name="student"></param>
    /// <returns></returns>
    private static string GetRandomValue(Student student)
    {
        return $"{student.Name} {student.LastName}";
    }

    /// <summary>
    /// Получение клю-значение
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private static KeyValuePair<Person, Student> GetRandomPerson(int i)
    {
        return new KeyValuePair<Person, Student>(new Person($"{i}", $":{i}", DateTime.Now), new Student());
    }

    /// <summary>
    /// Оформленный вывод информации на экран
    /// </summary>
    /// <param name="str"></param>
    /// <param name="color"></param>
    private static void WriteInfo(string str, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(str);
        Console.ResetColor();
    }
}



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
        //Создание студента
        var student = new Student();

        //Добавление эезаменов
        student.AddExams(new List<Exam>
        {
            new Exam(),
            new Exam()
        });

        //Добавление экзаменов через консоль
        student.AddFromConsole();
        Console.WriteLine();

        //Создание полной копии
        var copy = student.DeepCopy();

        //Вывод информации
        Console.WriteLine("Оригинал:");
        Console.WriteLine(student.ToString());
        Console.WriteLine("\nКопия:");
        Console.WriteLine(copy.ToString());
        Console.WriteLine();

        //Запрос на ввод пути к файлу
        Console.Write("\nВведите имя файла: ");
        var filename = Console.ReadLine();

        //Проверка на существование
        if (File.Exists(filename))
        {
            //Создание файла
            Console.WriteLine("Файла не существует");
            File.Create(filename);

        }
        else
        {
            //Загрузка объекта из файла
            student.Load(filename);
        }

        //Вывод информации
        Console.WriteLine();
        Console.WriteLine(student.ToString());

        //Добавление экзаменов через консоль
        student.AddFromConsole();
        student.Save(filename);

        //Вывод на экран
        Console.WriteLine();
        Console.WriteLine(student.ToString());

        //Загрузка объекта из файла
        Student.Load(filename, student);
        //Добавление экзаменов
        student.AddFromConsole();
        //Сохранение в файл
        Student.Save(filename, student);

        //Вывод информации
        Console.WriteLine();
        Console.WriteLine(student.ToString());
    }
}


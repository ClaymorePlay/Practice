﻿
using Practice3.Models;
using System.Collections;

public class Program
{
    static void Main(string[] args)
    {
        //Создание коллекции студентов
        var studentCollection = new StudentCollection();
        //Добавление стуентов по умолчанию
        studentCollection.AddDefaults(10);
        //Вывод
        Console.WriteLine(studentCollection.ToString() + "\n");

        Console.ResetColor();
        //Сортировка по фамилии
        studentCollection.SortByLastName();
        Console.WriteLine("Сортировка по фамилии:" + studentCollection.ToString());

        //Сортировка по дате
        studentCollection.SortByDate();
        Console.WriteLine("Сортировка по дате: " + studentCollection.ToString());

        //Сортировка по оценке
        studentCollection.SortByGrage();
        Console.WriteLine("Сортировка по оценке:" + studentCollection.ToString());

        //Получение результатов
        Console.WriteLine();
        Console.WriteLine("\nМаксимальный средний балл: " + studentCollection.MaxGrade);
        Console.WriteLine("\nСпециалисты: \n" + String.Join("\n", studentCollection.StudentsWithSpecialist.Select(c => c.ToString())));
        Console.WriteLine("\nГруппировка по сред баллу: \n" + String.Join("\n", studentCollection.AverageMarkGroup(3).Select(c => c.ToString())));

        //Тестирование коллекций элементов
        var count = 1000000;
        var test = new TestCollections(count);
        Console.WriteLine("\n\nПоследний\n" + test.GetTimeForFindItem(count - 1));
        Console.WriteLine("\n\nПервый\n" + test.GetTimeForFindItem(0));
        Console.WriteLine("\n\nЦентральный\n" + test.GetTimeForFindItem(count / 2));
        Console.WriteLine("\n\nНесуществующий\n" + test.GetTimeForFindItem(count));
    }
}


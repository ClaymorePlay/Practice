
using Practice.Models;
using Practice3.Models;
using Practice4.Models;
using System.Collections;

public class Program
{
    static void Main(string[] args)
    {
        //Создание двух коллекций студентов
        var collection1 = new StudentCollection<string>(KeySelect);
        var collection2 = new StudentCollection<string>(KeySelect);

        //Присваивание имен коллекциям
        collection1.CollectionName = "TestListCollection1";
        collection2.CollectionName = "TestListCollection2";

        //Создание журнала
        var journal1 = new Journal();

        //Подписки на события обновления списков
        collection1.StudentsChanged += journal1.StudentsCountChanged;
        collection2.StudentsChanged += journal1.StudentsCountChanged;

        //Добавление студентов
        collection1.AddStudents(new Student(), new Student());
        collection2.AddStudents(new Student(), new Student());

        //Обновление существующего
        collection1[0].Value.GroupNumber = 200;
        collection2[0].Value.Education = Practice.Models.Enums.EducationEnum.SecondEducation;

        //Удаленпие
        collection1.Remove(collection1.First());
        collection2.Remove(collection2.First());


        ///Вывод на экран
        Console.WriteLine(journal1.ToString());
    }

    /// <summary>
    /// Создание ключа для студента
    /// </summary>
    /// <param name="student"></param>
    /// <returns></returns>
    public static string KeySelect(Student student)
    {
        return $"{student.Name} {student.LastName}";
    } 
}


using Practice.Models;
using Practice.Models.Consts;
using Practice.Models.Enums;

public class Program
{
    static void Main(string[] args)
    {
        //Пункт 5
        var student = new Student();
        Console.WriteLine("Студент: " + student.ToShortString());

        //Пункт 6
        var isSpecialist = student[EducationEnum.Specialist];
        var isВachelor = student[EducationEnum.Вachelor];
        var isSecondEducation = student[EducationEnum.SecondEducation];
        Console.WriteLine
        (@$"
        {EducationEnum.Specialist} = {isSpecialist}
        {EducationEnum.Вachelor} = {isВachelor}
        {EducationEnum.SecondEducation} = {isSecondEducation}
        ");

        //Пункт 7
        Console.WriteLine("Заполните объект студента:");

        Console.Write($"{nameof(student.PersonInfo.Name)} = ") ;
        student.PersonInfo.Name = Console.ReadLine() ?? student.PersonInfo.Name;

        Console.Write($"{nameof(student.PersonInfo.LastName)} = ");
        student.PersonInfo.LastName = Console.ReadLine() ?? student.PersonInfo.LastName;
        
        Console.Write($"{nameof(student.PersonInfo.DateOfBirth)} = ");
        student.PersonInfo.DateOfBirth = DateTime.Parse(Console.ReadLine() ?? student.PersonInfo.DateOfBirth.ToShortDateString());
        
        Console.Write($"{nameof(student.GroupNumber)} = ");
        var validGroup = Int32.TryParse(Console.ReadLine(), out var group);
        student.GroupNumber = validGroup ? group : 0;
        
        Console.Write($"{nameof(student.Education)} = ");
        student.Education = (EducationEnum)(Convert.ToInt16(Console.ReadLine()));

        Console.WriteLine(student.ToString());

        //Пункт 8
        Console.Write("Введите количество экзаменов для последующего их автоматического заполнения: ");
        var count = Convert.ToInt32(Console.ReadLine());

        var exams = new Exam[count];
        for(int i = 0; i < count; i++)
        {
            exams[i] = new Exam();
        }
        student.AddExams(exams);

        Console.WriteLine(student.ToString());

        //Пункт 9
        Console.Write("Введите кол-во строк и столбцов через запятую или пробел: ");
        var data = Console.ReadLine().Split(new char[] { ',', ' ' });

        var nrow = Convert.ToInt32(data[0]);
        var ncolumn = Convert.ToInt32(data[1]);

        var rectangleArray = new Exam[nrow, ncolumn];
        var defaultArray = new Exam[nrow * ncolumn];
        var escaleraArray = new Exam[nrow * ncolumn][];

        //Инициализация первоначальных данных
        for(int i = 0; i < nrow*ncolumn; i++)
        {
            defaultArray[i] = new Exam();
        }
        for(int i = 0; i < nrow; i++)
        {
            for(int j = 0; j < ncolumn; j++)
            {
                rectangleArray[i, j] = new Exam();
            }
        }
        for(int i = 0; i < nrow*ncolumn; i++)
        {
            escaleraArray[i] = new Exam[1];
            for (int j = 0; j < 1; j++)
                escaleraArray[i][j] = new Exam();
        }


        //Подсчет времени
        var startRectangleArrayMs = Environment.TickCount64;
        for (int i = 0; i < nrow; i++)
        {
            for (int j = 0; j < ncolumn; j++)
            {
                rectangleArray[i, j].Subject = ProgramConsts.TestSubjectName;
            }
        }

        var endRectangleArrayMs = Environment.TickCount64;
        Console.WriteLine($"Двумерный прямоугольный массив выполнил операцию за {endRectangleArrayMs - startRectangleArrayMs} ms");

        var startDefaultArrayMs = Environment.TickCount64;
        for (int i = 0; i < nrow * ncolumn; i++)
        {
            defaultArray[i].Subject = ProgramConsts.TestSubjectName;
        }
        var endDefaultArrayMs = Environment.TickCount64;
        Console.WriteLine($"Одномерный массив выполнил операцию за {endDefaultArrayMs - startDefaultArrayMs} ms");

        var startEscaleraArrayMs = Environment.TickCount64;
        for (int i = 0; i < nrow * ncolumn; i++)
        {
            for (int j = 0; j < 1; j++)
                escaleraArray[i][j].Subject = ProgramConsts.TestSubjectName;
        }
        var endEscaleraArrayMs = Environment.TickCount64;
        Console.WriteLine($"Двумерный ступенчатый массив выполнил операцию за {endEscaleraArrayMs - startEscaleraArrayMs} ms");

        Console.ReadKey();
    }
}


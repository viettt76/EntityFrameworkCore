using HoangQuocViet.Models;

public class Program
{
    static FPTContext context = new FPTContext();
    public static void Main(string[] args)
    {
        string firstName;
        string lastName;
        int Id;
        Console.WriteLine(" ------------------List of Students---------------------");
        DisplayAllStudents(GetAllStudents());
        Console.WriteLine(" ------------------List of Grades---------------------");
        DisplayAllGrades(GetAllGrade());

        //create a student
        Console.WriteLine(" ------------------Create a student---------------------");
        Console.WriteLine("Enter first name: ");
        firstName = Console.ReadLine();
        Console.WriteLine("Enter last name: ");
        lastName = Console.ReadLine();

        AddStudent(firstName, lastName);
        Console.WriteLine(" ------------------List of Students after Update---------------------");
        DisplayAllStudents(GetAllStudents());


        //update student by ID
        Console.WriteLine("Enter Id Student: ");
        Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter first name: ");
        firstName = Console.ReadLine();
        Console.WriteLine("Enter last name: ");
        lastName = Console.ReadLine();
        UpdateStudent(Id, firstName, lastName);
        Console.WriteLine(" ------------------List of Students after Update---------------------");
        DisplayAllStudents(GetAllStudents());

        //Delete student by Id
        Console.WriteLine("Enter Id Student: ");
        Id = Convert.ToInt32(Console.ReadLine());
        DeleteStudent(Id);
        Console.WriteLine(" ------------------List of Students after Delete---------------------");
        DisplayAllStudents(GetAllStudents());
    }
    public static void DisplayAllStudents(List<Student> listStudents)
    {
        foreach (var student in listStudents)
        {
            Console.WriteLine(student.FirstName + " " + student.LastName);
        }
    }
    public static void DisplayAllGrades(List<Grade> listGrades)
    {
        foreach (var grade in listGrades)
        {
            Console.WriteLine(grade.GradeName);
        }
    }
    public static List<Student> GetAllStudents()
    {
        return context.Students.ToList();
    }
    public static List<Grade> GetAllGrade()
    {
        return context.Grades.ToList();
    }

    public static void AddStudent(string firstName, string lastName)
    {
        var student = new Student
        {
            StudentId = GetAllStudents().Count + 1,
            FirstName = firstName,
            LastName = lastName,
            GradeId = 1
        };
        context.Students.Add(student);
        context.SaveChanges();
    }

    public static void UpdateStudent(int id, string firstName, string lastName)
    {
        var student = context.Students.Find(id);
        student.FirstName = firstName;
        student.LastName = lastName;
        context.SaveChanges();
    }

    public static void DeleteStudent(int id)
    {
        var student = context.Students.Find(id);
        context.Students.Remove(student);
        context.SaveChanges();
    }
}
using Application.Services.Concrete;
using Core.Messages;
namespace NtierArch;
using Core.Operations;


public static class Program
{
    private static readonly GroupService _groupService;
    private static readonly StudentService _studentService;
    static Program()
    {
        _groupService = new GroupService();
        _studentService = new StudentService();
    }
    static void Main()
    {
        while (true)
        {
            ShowMenu();

            Messages.InputMessages("Choice");

            string choiceInput = (Console.ReadLine());
            int choice;
            bool isSucceeded = int.TryParse(choiceInput, out choice);
            if (isSucceeded)
            {
                switch ((Operations)choice)
                {
                    case Operations.AllGroups: 
                        GroupService.
                            break;
                    case Operations.CreateGroup:
                        GroupService.AddGroup();
                        break;
                    case Operations.UpdateGroup:
                        GroupService.UpdateGroup();
                        break;
                    case Operations.DeleteGroup:
                        break;
                    case Operations.DetailsGroup:
                        GroupService.GetDetailsofGroup();
                        break;
                    case Operations.AllStudents:
                        StudentService.GetAllStudents();
                        break;
                    case Operations.CreateStudent:
                        StudentService.AddStudent();
                        break;
                    case Operations.UpdateStudent:
                        StudentService.UpdateStudent();
                        break;
                    case Operations.DeleteStudent:
                        StudentService.DeleteStudent();
                        break;
                    case Operations.DetailsStudent:
                        StudentService.GetDetailsofStudent();
                        break;
                    case Operations.Exit:
                        return;
                    default:
                        Messages.InvalidInputMeesages("Choice");
                        break;
                }
            }
            else
            {
                Messages.InvalidInputMeesages("Choice");
            }
        }
    }
    public static void ShowMenu()
    {
        Console.WriteLine("---MENU----");
        Console.WriteLine("1. All groups");
        Console.WriteLine("2. Add group");
        Console.WriteLine("3. Update group");
        Console.WriteLine("4. Delete group");
        Console.WriteLine("5. Details of group");
        Console.WriteLine("6. All students");
        Console.WriteLine("7. Add student");
        Console.WriteLine("8. Update student");
        Console.WriteLine("9. Delete student");
        Console.WriteLine("10. Details of student");
        Console.WriteLine("0. Exit");
    }
}
    }
}

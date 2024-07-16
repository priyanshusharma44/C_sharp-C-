using ConsoleCRUD.Models;
using ConsoleCRUD.Repository;
using System;

namespace ConsoleCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Select Your Choice:\n");
                Console.WriteLine("1. Register New Student");
                Console.WriteLine("2. Remove Student ");
                Console.WriteLine("3. Update Student ");
                Console.WriteLine("4. List Students");
                Console.WriteLine("5. Exit Program");
                char choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1': Register(); break;
                    case '2': Remove(); break;
                    case '3': Update(); break;
                    case '4': List(); break;
                    case '5': return;
                }
                Console.ReadKey();
            } while (true);
        }

        public static void Register()
        {
            Student newStd = new Student();
            Console.WriteLine("\n\nStudent Registration");

            Console.Write("Name: ");
            newStd.Name = Console.ReadLine();

            Console.Write("Address: ");
            newStd.Address = Console.ReadLine();

            Console.Write("Phone: ");
            newStd.Phone = Console.ReadLine();

            if (StudentRepo.GetStudentList().Count > 0)
            {
                newStd.Id = StudentRepo.GetStudentList().Max(s => s.Id) + 1;
            }
            else
            {
                newStd.Id = 101;
            }

            if (StudentRepo.AddStudent(newStd))
                Console.WriteLine("Registration Successful.");
            else
                Console.WriteLine("Registration Failed.");
        }

        public static void Remove()
        {
            Console.WriteLine("\n\nRemove Student");
            Console.Write("Name: ");
            string? name = Console.ReadLine() ?? string.Empty;
            if (StudentRepo.DeleteStudent(name))
            {
                Console.WriteLine("Student Removed.");
            }
            else
            {
                Console.WriteLine("Removal Failed. Try again!");
            }
        }

        public static void Update()
        {
            Console.WriteLine("\n\nUpdate Student");

            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());

            Student student = new Student();

            Console.Write("Enter New Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter New Address: ");
            student.Address = Console.ReadLine(); ; ; ; ; ;;

            Console.Write("Enter New Phone: ");
            student.Phone = Console.ReadLine();

            if (StudentRepo.UpdateStudent(id, student))
            {
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update student.");
            }
        }

        public static void List()
        {
            Console.WriteLine("\n\nList of Students:");
            Console.WriteLine("Id\tName\t\tAddress\t\tPhone");
            foreach (Student student in StudentRepo.GetStudentList())
            {
                Console.WriteLine($"{student.Id}\t{student.Name}\t{student.Address}\t{student.Phone}");
            }
        }
    }
}

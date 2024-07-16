using System.Collections.Generic;
using System.Linq;
using ConsoleCRUD.Models;

namespace ConsoleCRUD.Repository
{
    public class StudentRepo
    {
        private static List<Student> stdList = new List<Student>();

        // Method to get the list of students
        public static List<Student> GetStudentList()
        {
            return stdList;
        }

        // Method to add a student to the list
        public static bool AddStudent(Student s)
        {
            stdList.Add(s);
            return true;
        }

        // Method to delete a student from the list by name
        public static bool DeleteStudent(string name)
        {
            Student? student = stdList.FirstOrDefault(s => s.Name.Equals(name));
            if (student != null)
            {
                stdList.Remove(student);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to update a student's details by ID
        public static bool UpdateStudent(int id, Student s)
        {
            Student? student = stdList.FirstOrDefault(st => st.Id == id);
            if (student != null)
            {
                student.Name = s.Name;
                student.Address = s.Address;
                student.Phone = s.Phone;
                return true;
            }
            return false;
        }
    }
}

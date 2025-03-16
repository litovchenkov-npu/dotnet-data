using System;
using System.Collections;
using System.Collections.Generic;

namespace students
{
    public class StudentCollection
    {
        class Student
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int StudentGroup { get; set; }
            public string StudentMajor { get; set; }
            public string StudentFaculty { get; set; }
            public Student()
            {
                StudentID = 0;
                StudentName = string.Empty;
                StudentGroup = 0;
                StudentMajor = string.Empty;
                StudentFaculty = string.Empty;
            }
        }

        private List<Student> Students = new List<Student>();

        public void AddStudent()
        {
            int InputID = default,
                InputGroup = default;
            string InputName = string.Empty,
                   InputMajor = string.Empty,
                   InputFaculty = string.Empty;
            Console.WriteLine("Enter student's ID: ");
            while (!int.TryParse(Console.ReadLine(), out InputID))
            {
                Console.WriteLine("Wrong input! Try again");
            }
            Console.WriteLine("Enter student's name: ");
            InputName = Console.ReadLine();
            Console.WriteLine("Enter student's group number: ");
            while (!int.TryParse(Console.ReadLine(), out InputGroup))
            {
                Console.WriteLine("Wrong input! Try again");
            }
            Console.WriteLine("Enter student's major study: ");
            InputMajor = Console.ReadLine();
            Console.WriteLine("Enter student's faculty: ");
            InputFaculty = Console.ReadLine();

            Students.Add(new Student()
            {
                StudentID = InputID,
                StudentName = InputName,
                StudentGroup = InputGroup,
                StudentMajor = InputMajor,
                StudentFaculty = InputFaculty
            });
            Console.WriteLine("The student was successfully added!");
        }
        public void RemoveStudent()
        {
            int SearchIndex;
            GetStudentList();
            Console.WriteLine("Enter the index of the student you want to remove: ");
            while (!int.TryParse(Console.ReadLine(), out SearchIndex))
            {
                Console.WriteLine("Wrong input! Try again");
            }
            if (SearchIndex > Students.Count)
                Console.WriteLine("The index doesn't exist");
            else if (SearchIndex < Students.Count && SearchIndex >= 0)
            {
                Students.RemoveAt(SearchIndex);
                Console.WriteLine("The student was successfully removed!");
            }
        }
        public void UpdateStudent()
        {
            int SearchIndex,
                InputID = default,
                InputGroup = default;
            string InputName = string.Empty,
                   InputMajor = string.Empty,
                   InputFaculty = string.Empty;

            GetStudentList();
            Console.WriteLine("Enter the index of the student you want to update: ");
            while (!int.TryParse(Console.ReadLine(), out SearchIndex))
            {
                Console.WriteLine("Wrong input! Try again");
            }
            if (SearchIndex > Students.Count)
                Console.WriteLine("The index doesn't exist");
            else if (SearchIndex < Students.Count && SearchIndex >= 0)
            {
                int MenuOption;
                Console.WriteLine("Select an item to change:");
                Console.WriteLine("1. Student's ID");
                Console.WriteLine("2. Student's name");
                Console.WriteLine("3. Student's group");
                Console.WriteLine("4. Student's major study");
                Console.WriteLine("5. Student's group");
                Console.WriteLine("6. Return to main menu");
                while (!int.TryParse(Console.ReadLine(), out MenuOption))
                {
                    Console.WriteLine("Wrong input!");
                }
                switch (MenuOption)
                {
                    case 1:
                        Console.WriteLine("Enter student's ID: ");
                        while (!int.TryParse(Console.ReadLine(), out InputID))
                        {
                            Console.WriteLine("Wrong input! Try again");
                        }
                        Students[SearchIndex].StudentID = InputID;
                        Console.WriteLine("The student's data was successfully updated!");
                        break;
                    case 2:
                        Console.WriteLine("Enter student's name: ");
                        InputName = Console.ReadLine();
                        Students[SearchIndex].StudentName = InputName;
                        Console.WriteLine("The student's data was successfully updated!");
                        break;
                    case 3:
                        Console.WriteLine("Enter student's group number: ");
                        while (!int.TryParse(Console.ReadLine(), out InputGroup))
                        {
                            Console.WriteLine("Wrong input! Try again");
                        }
                        Students[SearchIndex].StudentGroup = InputGroup;
                        Console.WriteLine("The student's data was successfully updated!");
                        break;
                    case 4:
                        Console.WriteLine("Enter student's major study: ");
                        InputMajor = Console.ReadLine();
                        Students[SearchIndex].StudentMajor = InputMajor;
                        Console.WriteLine("The student's data was successfully updated!");
                        break;
                    case 5:
                        Console.WriteLine("Enter student's faculty: ");
                        InputFaculty = Console.ReadLine();
                        Students[SearchIndex].StudentFaculty = InputFaculty;
                        Console.WriteLine("The student's data was successfully updated!");
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
        }
        public void GetStudentData()
        {
            int SearchIndex;
            GetStudentList();
            Console.WriteLine("Enter the index of the student you want to see: ");
            while (!int.TryParse(Console.ReadLine(), out SearchIndex))
            {
                Console.WriteLine("Wrong input! Try again");
            }
            if (SearchIndex > Students.Count)
                Console.WriteLine("The index doesn't exist");
            else if (SearchIndex < Students.Count && SearchIndex >= 0)
            {
                Console.WriteLine($"ID: {Students[SearchIndex].StudentID}");
                Console.WriteLine($"Name: {Students[SearchIndex].StudentName}");
                Console.WriteLine($"Group: {Students[SearchIndex].StudentGroup}");
                Console.WriteLine($"Major: {Students[SearchIndex].StudentMajor}");
                Console.WriteLine($"Faculty: {Students[SearchIndex].StudentFaculty}");
            }
        }
        public void GetStudentList()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine("The list is empty");
            }
            else
            {
                Console.WriteLine("Index\tID\tName");
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine($"{i}\t{Students[i].StudentID}\t{Students[i].StudentName}");
                }
            }
        }
    }

    internal class Program
    {
        enum MenuOptions : byte
        {
            View = 1,
            ViewOne,
            Add,
            Remove,
            Edit,
            Exit,
        }

        static StudentCollection StudentList = new StudentCollection();

        static void Menu()
        {
            Console.WriteLine("_________________________________");
            Console.WriteLine("|                               |");
            Console.WriteLine("| Select an operation:          |");
            Console.WriteLine("| 1. View the student list      |");
            Console.WriteLine("| 2. View student info          |");
            Console.WriteLine("| 3. Add a student              |");
            Console.WriteLine("| 4. Remove a student           |");
            Console.WriteLine("| 5. Update an existing student |");
            Console.WriteLine("| 6. Exit                       |");
            Console.WriteLine("|_______________________________|");

            Byte MenuOption;
            while (!Byte.TryParse(Console.ReadLine(), out MenuOption))
            {
                Console.WriteLine("Wrong input!");
            }
            MenuOptions SelectedOption = (MenuOptions)MenuOption;
            switch (SelectedOption)
            {
                case MenuOptions.View:
                    StudentList.GetStudentList();
                    break;
                case MenuOptions.ViewOne:
                    StudentList.GetStudentData();
                    break;
                case MenuOptions.Add:
                    StudentList.AddStudent();
                    break;
                case MenuOptions.Remove:
                    StudentList.RemoveStudent();
                    break;
                case MenuOptions.Edit:
                    StudentList.UpdateStudent();
                    break;
                case MenuOptions.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }
    }
}
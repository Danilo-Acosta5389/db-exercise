using System.Globalization;
using System.Net.NetworkInformation;

namespace db_exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool appRunning = true;
            while (appRunning)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\nVälkommen till Databasen! Vänligen välj ett av nedanstående alternativ:");
                    Console.WriteLine("\n1. Lista studenter" +
                        "\n2. Lista kurser" +
                        "\n3. Skapa student" +
                        "\n4. Skapa kurs" +
                        "\n5. Byt lösenord" +
                        "\n6. Redigera kurs" +
                        "\n7. Radera kurs" +
                        "\nA. Avsluta");

                    Console.Write("--> ");

                    string userChoice = Console.ReadLine();

                    switch (userChoice.ToLower())
                    {
                        case "1":
                            GetAllStudents();
                            break;
                        case "2":
                            GetAllCourses();
                            break;
                        case "3":
                            AddStudent();
                            break;
                        case "4":
                            AddCourse();
                            break;
                        case "5":
                            ChangeStudentPW();
                            break;
                        case "6":
                            RunEditCourse();
                            break;
                        case "7":
                            RunDeleteCourse();
                            break;
                        case "a":
                            Console.WriteLine("\nTack för att du använde Databasen och välkommen åter.\n");
                            PleasePressEnter();
                            appRunning = false;
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Var god försök igen.");
                }
            }
            
        }

        static void PleasePressEnter()
        {
            Console.WriteLine("Var god tryck ENTER för att fortsätta");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }

        static bool Leave()
        {
            Console.Write("\nVill du lämna? J/N: ");
            string input = Console.ReadLine();
            if(input.ToLower() == "j")
            {
                //trueOrFalse = false;
                return false;
            }
            else if (input.ToLower() == "n")
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }



        static void GetAllStudents()
        {
            Console.Clear();
            Console.WriteLine("\nLista över alla studenter\n");

            var students = PostgresDataAccess.GetAllStudents();
            for (int i = 0; i < students.Count; i++)
            {
                var get = students[i];
                Console.WriteLine($"Student ID: {get.id}" +
                    $"\nFörnamn: {get.first_name}" +
                    $"\nEfternamn: {get.last_name}" +
                    $"\nÅlder: {get.age}" +
                    $"\nEmail: {get.email}" +
                    $"\nLösenord: {get.password}");
                Console.WriteLine();
            }
            PleasePressEnter();
        }

        static void GetAllCourses()
        {
            Console.Clear();
            Console.WriteLine("\nLista över alla kurser\n");

            var courses = PostgresDataAccess.GetAllCourses();
            for (int i = 0; i < courses.Count; i++)
            {
                var get = courses[i];
                Console.WriteLine($"Kurs ID: {get.id}" +
                    $"\nkursnamn: {get.name}" +
                    $"\nPoäng: {get.points}" +
                    $"\nStartdatum: {get.start_date.ToString("yyyy-mm-dd")}" +
                    $"\nSlutdatum: {get.end_date.ToString("yyyy-mm-dd")}");
                Console.WriteLine();
            }
            PleasePressEnter();
        }

        static void AddStudent()
        {
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    Console.WriteLine("\nLägg till ny student\n");
                    Console.WriteLine("1. Skapa nytt studentkonto\n2. Avbryt");
                    Console.Write("--> ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("\nVar god och ange");
                            Console.Write("Förnamn: ");
                            string _fistName = Console.ReadLine();
                            Console.Write("Efternamn: ");
                            string _lastName = Console.ReadLine();
                            Console.Write("Ålder: ");
                            int _age = int.Parse(Console.ReadLine());
                            Console.Write("Email: ");
                            string _email = Console.ReadLine();
                            Console.Write("Lösenord: ");
                            string _password = Console.ReadLine();

                            Console.Write("\nStämmer det angivna? J/N: ");
                            string yesNo = Console.ReadLine();

                            if (yesNo.ToLower() == "j")
                            {
                                StudentModel student = new StudentModel
                                {
                                    first_name = _fistName,
                                    last_name = _lastName,
                                    age = _age,
                                    email = _email,
                                    password = _password
                                };
                                bool success = PostgresDataAccess.CreateNewStudent(student);
                                if (success)
                                {
                                    Console.WriteLine("\nStudentkonto har skapats!");
                                }
                                isRunning = Leave();
                            }
                            else if (yesNo.ToLower() == "n")
                            {
                                isRunning = Leave();
                            }
                            break;
                        case "2":
                            isRunning = Leave();
                            break;
                        default:
                            Console.WriteLine("\nVar god och välj 1 eller 2.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ett fel inträffade, var god försök igen.");
                    isRunning = Leave();
                }
                
            }
            

            
        }

        static void AddCourse()
        {
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    Console.WriteLine("\nLägg till ny kurs\n");
                    Console.WriteLine("1. Skapa ny kurs \n2. Avbryt");
                    Console.Write("--> ");
                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("Var god och ange");
                            Console.Write("Kursnamn: ");
                            string _name = Console.ReadLine();
                            Console.Write("Antal poäng: ");
                            int _points = int.Parse(Console.ReadLine());
                            Console.Write("Start datum ( åååå-mm-dd ): ");
                            DateTime _startDate = DateTime.Parse(Console.ReadLine());
                            Console.Write("Slut datum ( åååå-mm-dd ): ");
                            DateTime _endDate = DateTime.Parse(Console.ReadLine());

                            //Console.WriteLine(_startDate.ToString("yyyy-mm-dd"));
                            //Console.WriteLine(_endDate.ToString());
                            CourseModel course = new CourseModel
                            {
                                name = _name,
                                points = _points,
                                start_date = _startDate,
                                end_date = _endDate
                            };
                            bool success = PostgresDataAccess.CreateNewCourse(course);
                            if (success)
                            {
                                Console.WriteLine("\nKurs har skapats!");
                            }
                            isRunning = Leave();
                            break;
                        case "2":
                            isRunning = Leave();
                            break;
                        default:
                            Console.WriteLine("\nVar god välj 1 eller 2.");
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\nEtt fel inträffade. Var god försök igen.");
                    isRunning = Leave();
                }
            }
            
        }

        static void ChangeStudentPW()
        {
            Console.Clear();
            bool isRunning = true;
            while(isRunning)
            {
                try
                {
                    Console.WriteLine("\nÄndra students lösenord\n");
                    Console.WriteLine("1. Lista studenter" +
                        "\n2. Ändra lösenord" +
                        "\n3. Avsluta");
                    Console.Write("--> ");
                    int userChoice = int.Parse(Console.ReadLine());
                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine();
                            var students = PostgresDataAccess.GetAllStudents();
                            for (int i = 0; i < students.Count; i++)
                            {
                                var get = students[i];
                                Console.WriteLine($"Student ID: {get.id}" +
                                    $"\nFörnamn: {get.first_name}" +
                                    $"\nEfternamn: {get.last_name}" +
                                    $"\nÅlder: {get.age}" +
                                    $"\nEmail: {get.email}" +
                                    $"\nLösenord: {get.password}");
                                Console.WriteLine();
                            }
                            break;
                        case 2:
                            Console.Write("\nVar god ange student ID: ");
                            int studentId = int.Parse(Console.ReadLine());
                            Console.Write("\nVar god ange nytt lösenord: ");
                            string passwd = Console.ReadLine();
                            bool success = PostgresDataAccess.ChangeStudentPasswd(studentId, passwd);
                            if(success)
                            {
                                Console.WriteLine("\nLösenord har ändrats.");
                            }
                            break;
                        case 3:
                            isRunning = Leave();
                            break;
                        default:
                            Console.WriteLine("\nVar god ange 1, 2 eller 3.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ett fel inträffade. Var god försök igen.");
                    isRunning = Leave();
                }
            }
        }


        static void RunEditCourse()
        {
            Console.Clear();
            bool isRunning = true;
            while(isRunning)
            {
                try
                {
                    Console.WriteLine("\nRedigera kurs\n");
                    Console.WriteLine("1. Lista alla kurser och info" +
                        "\n2. Välj kurs" +
                        "\n3. Avsluta");
                    Console.Write("--> ");
                    int userChoice = int.Parse(Console.ReadLine());
                    switch (userChoice)
                    {
                        case 1:
                            Console.WriteLine();
                            var courses = PostgresDataAccess.GetAllCourses();
                            for (int i = 0; i < courses.Count; i++)
                            {
                                var get = courses[i];
                                Console.WriteLine($"Kurs ID: {get.id}" +
                                    $"\nkursnamn: {get.name}" +
                                    $"\nPoäng: {get.points}" +
                                    $"\nStartdatum: {get.start_date.ToString("yyyy-mm-dd")}" +
                                    $"\nSlutdatum: {get.end_date.ToString("yyyy-mm-dd")}");
                                Console.WriteLine();
                            }
                            break;
                        case 2:
                            Console.WriteLine("\nVar god välj rätt kurs ID för att ändra");
                            Console.Write("--> ");
                            int id = int.Parse(Console.ReadLine());
                            var course = PostgresDataAccess.GetCourseById(id);
                            Console.WriteLine($"Du har valt kurs id: {course.id}. {course.name}, {course.points} poäng, startdatum {course.start_date.ToString("yyyy-mm-dd")} och slutdatum {course.end_date.ToString("yyyy-mm-dd")}");
                            Console.WriteLine("\nVill du redigera all kursinfo eller bara en del?");
                            Console.WriteLine("\n1. Allt" +
                                "\n2. En del" +
                                "\n3. Avbryt");
                            Console.Write("--> ");
                            string choice = Console.ReadLine();
                            switch (choice)
                            {
                                case "1":
                                    Console.WriteLine("\nÄndra all kursinfo\n");
                                    Console.Write("Ange nytt kursnamn: ");
                                    string newName = Console.ReadLine();
                                    Console.Write("Ange ny poäng: ");
                                    int newPoints = int.Parse(Console.ReadLine());
                                    Console.Write("Ange ny startdatum ( åååå-mm-dd ): ");
                                    DateTime newStartDate = DateTime.Parse(Console.ReadLine());
                                    Console.Write("Ange ny slutdatum ( åååå-mm-dd ): ");
                                    DateTime newEndDate = DateTime.Parse(Console.ReadLine());
                                    Console.Write("\nStämmer allt som ovanför? J/N: ");
                                    string yesNo = Console.ReadLine();
                                    if (yesNo.ToLower() == "j")
                                    {
                                        CourseModel newInfo = new CourseModel
                                        {
                                            id = id,
                                            name = newName,
                                            points = newPoints,
                                            start_date = newStartDate,
                                            end_date = newEndDate
                                        };
                                        bool success = PostgresDataAccess.EditAllCourseInfo(newInfo);
                                        if(success)
                                        {
                                            Console.WriteLine("Kursinfo är updaterad!");
                                        }
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("\nRedigera en del av kursinfo\n");
                                    Console.WriteLine("1. Ändra kursnamn" +
                                        "\n2. Ändra poäng" +
                                        "\n3. Ändra startdatum" +
                                        "\n4. Ändra slutdatum" +
                                        "\n5. Avbryt");
                                    Console.Write("--> ");
                                    choice = Console.ReadLine();
                                    switch (choice)
                                    {
                                        case "1":
                                            Console.Write("\nAnge nytt kursnamn: ");
                                            newName = Console.ReadLine();
                                            bool success = PostgresDataAccess.EditCourseName(id, newName);
                                            if(success)
                                            {
                                                Console.WriteLine("\nKursnamn ändrades!");
                                            }
                                            break;
                                        case "2":
                                            Console.Write("Ange ny poäng: ");
                                            newPoints = int.Parse(Console.ReadLine());
                                            success = PostgresDataAccess.EditCoursePoints(id, newPoints);
                                            if(success)
                                            {
                                                Console.WriteLine("\nPoäng ändrades!");
                                            }
                                            break;
                                        case "3":
                                            Console.Write("Ange ny startdatum ( åååå-mm-dd ): ");
                                            newStartDate = DateTime.Parse(Console.ReadLine());
                                            //Console.WriteLine(newStartDate);
                                            success = PostgresDataAccess.EditCourseStartDate(id, newStartDate);
                                            
                                            if(success)
                                            {
                                                Console.WriteLine("\nStartdatum ändrades!");
                                            }
                                            break;
                                        case "4":
                                            Console.Write("Ange ny slutdatum ( åååå-mm-dd ): ");
                                            newEndDate = DateTime.Parse(Console.ReadLine());
                                            success = PostgresDataAccess.EditCourseEndDate(id, newEndDate);
                                            if(success)
                                            {
                                                Console.WriteLine("Slutdatum ändrades!");
                                            }
                                            break;
                                        case "5":
                                            Console.WriteLine("Avbryter");
                                            break;
                                        default:
                                            Console.WriteLine("\nVar god välj 1, 2, 3, 4 eller 5.");
                                            break;
                                    }
                                    
                                    break;
                                case "3":
                                    Console.WriteLine("Avbryter");
                                    break;
                                default:
                                    Console.WriteLine("Var god välj 1, 2 eller 3.");
                                    break;
                            }
                            break;
                        case 3:
                            isRunning = Leave();
                            break;
                        default:
                            Console.WriteLine("\nVar god välj 1, 2 eller 3.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ett fel inträffade, var god försök igen.");
                }
            }

        }


        static void RunDeleteCourse()
        {
            Console.Clear();
            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    Console.WriteLine("\nRadera kurs\n");
                    Console.WriteLine("1. Lista alla kurser" +
                        "\n2. Radera kurs" +
                        "\n3. Avsluta");
                    Console.Write("--> ");
                    string userChoice = Console.ReadLine();
                    switch (userChoice)
                    {
                        case "1":
                            Console.WriteLine();
                            var courses = PostgresDataAccess.GetAllCourses();
                            for (int i = 0; i < courses.Count; i++)
                            {
                                var get = courses[i];
                                Console.WriteLine($"Kurs ID: {get.id}" +
                                    $"\nkursnamn: {get.name}" +
                                    $"\nPoäng: {get.points}" +
                                    $"\nStartdatum: {get.start_date.ToString("yyyy-mm-dd")}" +
                                    $"\nSlutdatum: {get.end_date.ToString("yyyy-mm-dd")}");
                                Console.WriteLine();
                            }
                            break;
                        case "2":
                            Console.WriteLine("\nVar god ange rätt kurs ID för att radera\n");
                            Console.Write("--> ");
                            int id = int.Parse( Console.ReadLine() );
                            Console.Write("Är du säker? J/N: ");
                            string yesNo = Console.ReadLine();
                            if (yesNo.ToLower() == "j")
                            {
                                bool success = PostgresDataAccess.DeleteCourse(id);
                                if (success == true)
                                {
                                    Console.WriteLine("\nKursen är nu borttagen.");
                                }
                                else
                                {
                                    Console.WriteLine("\nKursen kunde inte tas bort.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nKursen togs inte bort.");
                                break;
                            }
                            break;
                        case "3":
                            isRunning = Leave();
                            break;
                        default:
                            Console.WriteLine("Var god ange 1, 2 eller 3");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ett fel inträffade. Var god försök igen.");
                    isRunning = Leave();
                }
                
            }
            
        }
    }
}
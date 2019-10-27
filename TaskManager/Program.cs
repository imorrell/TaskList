using System;
using System.Text.RegularExpressions;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize variables
            bool ok = true;
            int userChoice;

            //Prompt the user to the program
            Console.WriteLine("Welcome to the assassins database. \n");

            while (ok)
            {
                //Display the menu
                DisplayMenu();

                Console.WriteLine();

                //prompt user 
                userChoice = ValidateRange("What would you like to do? \n", 1, 7);

                //use a switch statement to process user selection
                switch (userChoice)
                {
                    //user selects displays tasks
                    case 1:
                        {
                            Task.DisplayTasks();
                            break;
                        }
                    //user selects add task
                    case 2:
                        {
                            //call the create task method
                            CreateTask();

                            //tell user that task has been created
                            Console.WriteLine("Task has been added. \n");
                            break;
                        }
                        //user selects to modify task
                    case 3:
                        {
                            //Display task list
                            DisplayTasks();

                            Console.WriteLine();

                            //ask user what task they would like to modify
                            userChoice = ValidateRange("What task would you like to modify? (enter number) \n", 1, Task._tasks.Count);

                            Console.WriteLine();

                            //call the modify taks method passing userChoice variable
                            Task.ModifyTask(userChoice);

                            break;
                        }
                    //user selects to delete task
                    case 4:
                        {
                            //Display task list
                            DisplayTasks();

                            Console.WriteLine();

                            //ask user what task they would like to delete
                            userChoice = ValidateRange("What task would you like to delete? (enter number) \n", 1, Task._tasks.Count);

                            Console.WriteLine();

                            //call the modify taks method passing userChoice variable
                            Task.DeleteTask(userChoice);

                            break;
                        }
                    //user selects to update task completion
                    case 5:
                        {
                            //Display task list
                            DisplayTasks();

                            Console.WriteLine();

                            //ask user what task they would like to update completion
                            userChoice = ValidateRange("What task would you like to update mark complete? (enter number) \n", 1, Task._tasks.Count);

                            Console.WriteLine();

                            //call the modify taks method passing userChoice variable
                            Task.MarkComplete(userChoice);

                            break;
                        }
                        //user chooses quit
                    case 6:
                        {
                            //change bool ok to false
                            ok = false;
                            //goodbye messae
                            Console.WriteLine("Goodbye! \n");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("No user input");
                            break;
                        }
                }
            }
        }

        public static void CreateTask()
        {
            Task task = new Task();
            task.MemberName = UserInput("Enter assasins name: \n");
            task.BriefDescription = UserInput("Enter assignment: \n");
            task.Date = ValidDate("Enter date: \n");

            //add the task to the list
            Task.AddTask(task);
        }

        public static DateTime ValidDate(string message)
        {
            try
            {
                return DateTime.Parse(GetUserInput(message));
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This is not a valid date. Try again. \n");
                Console.ResetColor();

                //use recursion to recall the method
                return ValidDate(message);  
            }
        }

        public static string UserInput(string message)
        {
            string input;

            Console.WriteLine(message);

            input = Console.ReadLine();

            Console.WriteLine();

            //check to see if input is alphabet only

            if (Regex.IsMatch(input, @"^[a-zA-Z0-9\s]+$"))
            {
                return input;
            }
            else
            {
                //input is not all alphabet. Return message and recall method
                Console.WriteLine("Wrong input! must contain letters only. \n");
                return UserInput(message);
            }
        }

        public static int ValidateRange(string message, int min, int max)
        {
            int number = ParseString(message);

            Console.WriteLine();

            if (number >= min && number < max)
            {
                return number;
            }
            else
            {
                //This student does not exist
                Console.WriteLine("This category does not exist.\n");
                return ValidateRange(message, min, max);
            }
        }

        public static int ParseString(string message)
        {
            try
            {
                string input = GetUserInput(message);
                int number = int.Parse(input);
                return number;
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad input. We need a number \n");
                return ParseString(message);
            }

        }

        public static string GetUserInput(string message)
        {
            string input;

            Console.WriteLine(message);

            input = Console.ReadLine();

            return input;
        }

        //Display menu options
        public static void DisplayMenu()
        {
            Console.WriteLine("1. List Tasks");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Modify Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Mark Task Complete");
            Console.WriteLine("6. Quit");
        }

        //this method displays tasks only for adding, modifiying, 
        //deleting, and checking as complete
        public static void DisplayTasks()
        {
            for (int i = 0; i < Task._tasks.Count; i++)
            {
                Console.Write((i + 1) + ". " + Task._tasks[i].MemberName);
                Console.Write("  " + Task._tasks[i].BriefDescription);
                Console.Write("  " + Task._tasks[i].Date);
                Console.Write("  " + Task._tasks[i].Completed);
                Console.WriteLine();
            }

            Console.WriteLine();



        }

    }
}

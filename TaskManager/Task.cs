using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TaskManager
{
    public class Task
    {
        //intialize class fields
        #region fields
        public static List<Task> _tasks = new List<Task>
        {
            new Task("James Bond", "Assasinate Target 675", DateTime.Parse("09/11/2019")),
            new Task("John Wick", "Assasinate Target 987", DateTime.Parse("07/01/2019")),
            new Task("Jason Borne", "Assasinate Target 322", DateTime.Parse("04/22/2019")),
            new Task("Leon The Professional", "Assasinate Target 90 ", DateTime.Parse("01/15/2019")),
            new Task("Robert McCall", "Assasinate Target 007", DateTime.Parse("04/19/2019")),
            new Task("Anton Chigurh", "Assasinate Target 22", DateTime.Parse("11/6/2019")),
            new Task("Beatrix Kiddo ", "Assasinate Target 3", DateTime.Parse("12/10/2019")),
            new Task("Vincent", "Assasinate Target 9000", DateTime.Parse("02/22/2019")),
            new Task("John Wick", "Assasinate Target 78", DateTime.Parse("01/29/2019")),
            new Task("Jason Borne", "Assasinate Target 322", DateTime.Parse("04/22/2019"))
        };
        private string memberName;
        private string briefDescription;
        private DateTime date;
        private bool completed = false;

        #endregion 

        //initalizes properties
        #region properties
        public string MemberName
        {
            get { return memberName; }
            set { memberName = value; }
        }

        public string BriefDescription
        {
            get { return briefDescription; }
            set { briefDescription = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public bool Completed
        {
            get { return completed; }
            set { completed = value; }
        }

        #endregion


        //initialize methods
        #region methods
        public Task()
        {

        }

        public Task(string name, string description, DateTime _date, bool complete = false)
        {
            memberName = name;
            briefDescription = description;
            date = _date;
        }

        
        private static List<string> DisplayAssassin(List<Task> list)
        {
            List<String> assAssins = new List<string>();

            foreach (Task task in list)
            {
                if (!assAssins.Contains(task.MemberName))
                {
                    assAssins.Add(task.MemberName);
                }
            }

            return assAssins;
        }

        public static void PrintAssassin(List<Task> tasks)
        {
            List<string> taskList = Task.DisplayAssassin(tasks);

            for (int i = 0; i < taskList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {taskList[i]}");
            }

        }
        //Display tasks
        public static void DisplayTasks()
        {
            int choice;
            string assassin;

            //ask the user if they would like to display the tasks for one assassins
            //of for all assassins
            Console.WriteLine("Would you like to display all tasks of tasks for specific assassin or all? (Enter '1' for specific or '2' for all) \n");

            choice = int.Parse(Console.ReadLine());

            Console.WriteLine();

            //Process user choice

            if (choice == 1)
            {
                //display the names of all the assassins
                PrintAssassin(Task._tasks);
                Console.WriteLine();

                assassin = GetAssassinInput("What assassin tasks would you like to see? (enter assassin name) \n");

                //Determine if assassin is in the list
                for (int i = 0; i < _tasks.Count; i++)
                {
                    if (assassin == _tasks[i].MemberName)
                    {
                        //Print out that assassins task
                        Console.Write(_tasks[i].BriefDescription);
                        Console.Write("\t" + _tasks[i].Date);
                        Console.Write("\t" + _tasks[i].Completed);
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
            else if (choice == 2)
            {
                for (int i = 0; i < _tasks.Count; i++)
                {
                    Console.Write((i+1) + ". " + _tasks[i].MemberName);
                    Console.Write("  " + _tasks[i].BriefDescription);
                    Console.Write("  " + _tasks[i].Date);
                    Console.Write("  " + _tasks[i].Completed);
                    Console.WriteLine();
                }

                Console.WriteLine();
            }

            else
            {
                //user entered wrong input! Use recursion to recall method
                Console.WriteLine("Wrong input! Please try again \n");
                DisplayTasks();
            }
        }

        //add task
        public static void AddTask(Task task)
        {
            //add the task
            _tasks.Add(task);

        }

        public static void ModifyTask(int number)
        {
            string modifyAssassin;
            int index = number - 1;

            //display the task that the user selected
            Console.Write(_tasks[index].MemberName);
            Console.Write("  " + _tasks[index].BriefDescription);
            Console.Write("  " + _tasks[index].Date);
            Console.Write("  " + _tasks[index].Completed);
            Console.WriteLine();

            //ask the user are they sure if they want to modify the user
            Console.WriteLine("Are you sure you want to modify this task (y/n)? \n");

            modifyAssassin = Console.ReadLine();

            Console.WriteLine();

            //check the user choice
            if (modifyAssassin.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                //call the ModifyAttributes method
                ModifyTaskAttributes(index);
                Console.WriteLine("Task modified \n");
            }
            else if (modifyAssassin.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                //display message 
                Console.WriteLine("Task not modified \n");

            }
            else
            {
                //user did not enter (y/n) prompt the user to reenter choice
                Console.WriteLine("Wrong input! Please enter right input. \n");
                ModifyTask(number);
            }

        }

        //delete task
        public static void DeleteTask(int number)
        {
            string choiceDelete;
            int index = number - 1;

            //display the task that the user selected
            Console.Write(_tasks[index].MemberName);
            Console.Write("  " + _tasks[index].BriefDescription);
            Console.Write("  " + _tasks[index].Date);
            Console.Write("  " + _tasks[index].Completed);
            Console.WriteLine();

            //ask the user are they sure if they want to delete user
            Console.WriteLine("Are you sure you want to delete this task (y/n)? \n");

            choiceDelete = Console.ReadLine();

            Console.WriteLine();

            //check the user choice
            if (choiceDelete.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                _tasks.RemoveAt(index);
                Console.WriteLine("Task deleted \n");
            }
            else if (choiceDelete.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                //display message 
                Console.WriteLine("Task not deleted \n");

            }
            else
            {
                //user did not enter (y/n) prompt the user to reenter choice
                Console.WriteLine("Wrong input! Please enter right input. \n");
                DeleteTask(number);
                Console.WriteLine();
            }
        }

        public static void MarkComplete(int number)
        {
            string complete;
            int index = number - 1;

            //display the task that the user selected
            Console.Write(_tasks[index].MemberName);
            Console.Write("  " + _tasks[index].BriefDescription);
            Console.Write("  " + _tasks[index].Date);
            Console.Write("  " + _tasks[index].Completed);
            Console.WriteLine();

            //Ask the user if the are sure they want to mark the tak complete
            Console.WriteLine("Are you sure you would like to mark task complete? \n");

            complete = Console.ReadLine();
            Console.WriteLine();

            //check the user choice
            if (complete.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                _tasks[index].Completed = true;
                Console.WriteLine("Task marked as complete \n");
            }
            else if (complete.Equals("n", StringComparison.OrdinalIgnoreCase))
            {
                //display message 
                Console.WriteLine("The task is still incomplete. \n");

            }
            else
            {
                //user did not enter (y/n) prompt the user to reenter choice
                Console.WriteLine("Wrong input! Please enter right input. \n");
                MarkComplete(number);
                Console.WriteLine();
            }
        }

        //The ModifyTaskAttributes method change the task based off what needs to be modifed
        public static void ModifyTaskAttributes(int number)
        {
            int userChoice;
            string userName;
            string description;
            DateTime date;
            string completionStatus;

            //display options for modification
            Console.WriteLine("1. Assassin name");
            Console.WriteLine("2. Target Description");
            Console.WriteLine("3. Task date");
            Console.WriteLine("4. Task completion");
            Console.WriteLine("5. All");

            Console.WriteLine();

            //Prompt the user selection
            Console.WriteLine("What field would you like to modify? \n");

            userChoice = int.Parse(Console.ReadLine());

            //use switch statement to process userchoice
            switch (userChoice)
            {
                //user choose assassins name
                case 1:
                {
                        //Prompt user to Assassin name
                        Console.WriteLine("Enter assassin name\n");

                        userName = Console.ReadLine();

                        Console.WriteLine();

                        //change username based off user entered index 
                        //selection passed to the method
                        _tasks[number].MemberName = userName;

                        Console.WriteLine();
                     break;
                }
                //user choose to update assassin assingment
                case 2:
                {
                        //Prompt user to Assassin name
                        Console.WriteLine("Update task description\n");

                        description = Console.ReadLine();

                        Console.WriteLine();

                        //change username based off user entered index 
                        //selection passed to the method
                        _tasks[number].BriefDescription = description;

                        Console.WriteLine();
                        break;
                }
                //user wants to update the date
                case 3:
                {
                        //Prompt user to Assassin name
                        Console.WriteLine("Enter new date\n");

                        date = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine();

                        //change username based off user entered index 
                        //selection passed to the method
                        _tasks[number].Date = date;

                        Console.WriteLine();
                        break;
                }
                    //user wants to change the task completion
                case 4:
                {
                        //ask the user if they want to change the task to complete or incomplete
                        Console.WriteLine("Would you like to change task to complete or incomplete \n");

                        completionStatus = Console.ReadLine();

                        Console.WriteLine();

                        if (completionStatus.Equals("complete", StringComparison.OrdinalIgnoreCase))
                        {
                            //change completion bool to true

                            //update Task object
                            _tasks[number].Completed = true; 
                        }
                        else if (completionStatus.Equals("incomplete", StringComparison.OrdinalIgnoreCase))
                        {
                            //change completion bool to false
                            _tasks[number].Completed = false;
                        }
                        else
                        {
                            //Wrong input
                            Console.WriteLine("Wrong input. Task completion unchanged. \n");
                        }
                        break;
                }
                 //modify all fields
                case 5:
                {
                        //Prompt user to Assassin name
                        Console.WriteLine("Enter assassin name\n");

                        userName = Console.ReadLine();

                        Console.WriteLine();

                        //change username based off user entered index 
                        //selection passed to the method
                        _tasks[number].MemberName = userName;

                        Console.WriteLine();

                        //Prompt user to Assassin name
                        Console.WriteLine("Update task description\n");

                        description = Console.ReadLine();

                        Console.WriteLine();

                        //change username based off user entered index 
                        //selection passed to the method
                        _tasks[number].BriefDescription = description;

                        Console.WriteLine();

                        //Prompt user to Assassin name
                        Console.WriteLine("Enter new date\n");

                        date = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine();

                        //change username based off user entered index 
                        //selection passed to the method
                        _tasks[number].Date = date;

                        Console.WriteLine();

                        //ask the user if they want to change the task to complete or incomplete
                        Console.WriteLine("Would you like to change task to complete or incomplete \n");

                        completionStatus = Console.ReadLine();

                        Console.WriteLine();

                        if (completionStatus.Equals("complete", StringComparison.OrdinalIgnoreCase))
                        {
                            //change completion bool to true

                            //update Task object
                            _tasks[number].Completed = true;
                        }
                        else if (completionStatus.Equals("incomplete", StringComparison.OrdinalIgnoreCase))
                        {
                            //change completion bool to false
                            _tasks[number].Completed = false;
                        }
                        else
                        {
                            //Wrong input
                            Console.WriteLine("Wrong input. Task completion unchanged. \n");
                        }

                        break;
                }
                default:
                {
                        //user enter wrong input
                        Console.WriteLine("Wrong input! Please try again. \n");
                        ModifyTaskAttributes(number);
                        break;
                     
                }
            }
        }

        public static string GetAssassinInput(string message)
        {
            string input;

            Console.WriteLine(message);

            input = Console.ReadLine();

            Console.WriteLine();

            //check user input for empty or digits only
            if (input == "")
            {
                Console.WriteLine("Entry blank! Please enter a name! \n");
                return GetAssassinInput(message);
            }
            else if (Regex.IsMatch(input, @"^[0-9]*$"))
            {
                Console.WriteLine("Wrong input! Input characters only \n");
                return GetAssassinInput(message);
            }
            else
            {
                return input;
            }
            
        }

        #endregion

        

    }
}

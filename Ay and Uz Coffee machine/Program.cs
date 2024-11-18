using Microsoft.VisualBasic.FileIO;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace AyandUz
{
    class Program
    {
        //Declaring variables
        public static string ansSize;
        public static string ansS;
        public static int order;
        public static string orderSum;
        public static double money;
        public static double moneySum;
        public static System.Text.StringBuilder builder = new System.Text.StringBuilder(); //this will be used to build a string of orders
        static void Main(string[] args)
        {
            Authentication();
            Restart();
            Console.ReadKey();


        }
        static void Authentication()
        {
            string uName = "Sprinter";
            string uPassword = "P@ssword123";
            Console.WriteLine("Hello enter your username");
            string uNameU = Console.ReadLine();

            Console.WriteLine("Enter Password");
            string uPasswordU = Console.ReadLine();
            if (uNameU == uName && uPasswordU == uPassword)
            {
                Console.Clear();
                Menu();
            }
            else
            {
                Console.WriteLine("Credentials are not correct,You have 2 attempts left.");
                Console.WriteLine("Hello enter your username");
                uNameU = Console.ReadLine();

                Console.WriteLine("Enter Password");
                uPasswordU = Console.ReadLine();
                if (uNameU == uName && uPasswordU == uPassword)
                {
                    Console.Clear();
                  
                    Menu();

                }
                else
                {

                    Console.WriteLine("Credentials are not correct, You have 1 attempt left.");
                    Console.WriteLine("Hello enter your username");
                    uNameU = Console.ReadLine();

                    Console.WriteLine("Enter Password");
                    uPasswordU = Console.ReadLine();
                    if (uNameU == uName && uPasswordU == uPassword)
                    {
                        Console.Clear();
                       
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Credentials are not correct,Exiting now!");
                        System.Environment.Exit(0);


                    }




                }



            }

        }

        static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            Console.WriteLine($"*********************************************************************************\n*                                                                               *" +
                $"\n* WELCOME TO AY AND UZ'S COFFEE MACHINE!                                        *\n*                                                                               *\n*********************************************************************************");
            Console.WriteLine($"Good Day Sprinter!");
            string menuChoice;
            Console.WriteLine("How can we help you today " + "\n1. Order Coffee\n2. View Previous Orders\n3. Logout");
            menuChoice = Console.ReadLine();
          

            if (menuChoice == "1")
            {
                Console.Clear ();
                OrderCoffee();
            }
            else if (menuChoice == "2")
            {
                Console.Clear();
                PreviousOrders();
                ReturnToMenu();

            }
            else if(menuChoice == "3") 
            {
                Console.WriteLine("Thank you for visiting Ay and Uz's Coffee Machine.");
                System.Environment.Exit(0);
            }
            else
            {
               Console.Clear();
                Console.WriteLine("Please Enter Valid Choice!");
                Menu();
            }


        }
        public static void OrderCoffee() //This method contains the main process of making the coffee
        {
            Console.WriteLine("What will you be having today?:) (Only enter number)\n1.Latte....................R35,00\n2.Cappuccino................R40,00\n3.Espresso....................R25,00");
            string ans = Console.ReadLine();
            ansS = ans.ToString();

            if (ans == "1")
            {
                ansS = "Latte";
                money = 35.00;
                Console.Clear();
                Size();

            }
            else if (ans == "2")
            {
                ansS = "Cappuccino";
                money = 40.00;
                Console.Clear();
                Size();

            }
            else if (ans == "3")
            {
                ansS = "Espresso";
                money = 25.00;
                Console.Clear();
                Size();

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please Enter Valid Choice!");
                OrderCoffee();
            }

           


            orderSum = $"{ansSize} {ansS}"; // Joining the variables to make it a string
        }
        public static void Size()// This method allows user to pick size
        {
            
            Console.WriteLine("What size do you want?(Only enter number)\n1.Small\n2.Medium...........+R5\n3.Large.............+R10");
            string ans2 =Console.ReadLine();
            ansSize = ans2.ToString();
      
            if (ans2 == "1")
            {
                ansSize = "Small";

            }
            else if (ans2 == "2")
            {
                ansSize = "Medium";
                money = money + 5;
            }
            else if (ans2 == "3")
            {
                ansSize = "Large";
                money = money + 10;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please Enter Valid Choice!");
                Size();
            }
           

        }

        public static void Restart() // this method allows you to restart the process
        {

            // allowing the user to order again
            while (true)
            {

                order = order + 1; //order number increases after every order
                moneySum = moneySum + money;
                builder.Append(orderSum + " at " + DateTime.Now + "\n"); //this line will add all the orders to a string so that it can be displayed
                Console.WriteLine("Thank you! ,Do you want another order?(Y/N)");
                string input = Console.ReadLine().ToLower();
                
                while (input != "y" && input != "n") 
                {
                    Console.WriteLine("Please enter valid option!");
                    input = Console.ReadLine();
                }
                

                if (input == "n") //if user enters no this code will execute and break the loop
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for ordering at Ay and Uz's Coffee Machine!");
                    Console.WriteLine($"Order Details: {order} order(s)\n");
                    Console.WriteLine(builder);//displays the orders
                    Console.WriteLine($"Your final total will be R{Math.Round(moneySum, 3)}");
                    ReturnToMenu();
                   

                }
                else if(input == "y")
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome back!");
                    OrderCoffee();

                }
            }
        } 

        public static void PreviousOrders()// allows users to view previous orders
        {
                Console.WriteLine("Previous Orders:");
                Console.WriteLine($"Order Details: {order} order(s)\n");
                Console.WriteLine(builder);
                
            } 
        public static void ReturnToMenu()
        {
            Console.WriteLine("Do you want to return to menu?(Y/N)");
            string answer1 = Console.ReadLine().ToLower();


            if (answer1 == "y")
            {
                Console.Clear();
                Console.WriteLine($"Welcome back!");
                Menu();

            }
            else if (answer1 == "n")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter valid choice");
                ReturnToMenu();
                

            }
        }

    }
} 



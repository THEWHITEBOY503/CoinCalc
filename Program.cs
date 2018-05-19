//PLEASE READ:
//IT IS VERY IMPORTANT YOU EDIT THIS FILE TO INCLUDE THE PROPER FILE PATHS, CURRENCY EXCHANGE RATES, AND VARIABLES.

//Define the system libraries needed for compiling.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//Makes a namespace for our program and gives it a name.
namespace CurrencyCalc

{
    //The class for the main program script.
    public class Program

    {
        //Define all the variables we will need.
        private static double CurrencyRate;
        private static double CurrencyInput;
        private static double CurrencyOutput;
        private static double DollarsInput;
        private static double DollarsOutput;
        private static double Operation;
        private static double BankOperation;
        private static double Deposit;
        private static double AfterDeposit;
        private static double Withdraw;
        private static double AfterWithdraw;
        private static double BankWorth;
        private static double ShopChoice;
        private static double ShopPrice;
        private static double AfterShop;
        private static double ShopConfirm;



        //The actual program is located here.
        public static void Main()


        {
            //Defines the file where the bank account is stored.
            //Make a file called "bank.txt" in the folder this app is in then copy the path here and everywhere else where a file path is seen.
            //After you make the file, open it in notepad and type in how much currency you want to start with then save. 
            string bank = System.IO.File.ReadAllText(@"C:\Users\conner smith\source\repos\CalcBase\bank.txt");

            //Set the rate of exchange for your currency.
            //If $1 is worth more than one of your currency, the rate should be a normal number.
            //If $1 is worth less than one of your currency, the rate should be a lower than zero decimal.
            double CurrencyRate = 0.64;

            Console.ForegroundColor = ConsoleColor.White;
            //Choose what to do
            Console.WriteLine("1) Dollars to Currency");
            Console.WriteLine("2) Currency to Dollars");
            Console.WriteLine("3) Currency Bank");
            Console.WriteLine("4) Currency Shop");
            Console.WriteLine(">4) Exit");
            Console.WriteLine("Please input your choice.");
            Console.Write(">");
            Operation = Convert.ToDouble(Console.ReadLine());

            //Calculate Dollars into your currency.
            if (Operation == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Input the amount of Dollars. ");
                DollarsInput = Convert.ToDouble(Console.ReadLine());
                //The USD value is converted into Currency.
                double CurrencyOutput = DollarsInput * CurrencyRate;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("$" + DollarsInput + " is worth " + CurrencyOutput + "C");
                System.Threading.Thread.Sleep(
                (int)System.TimeSpan.FromSeconds(5).TotalMilliseconds);
                Console.ForegroundColor = ConsoleColor.Gray;
                System.Environment.Exit(1);
            }

            //Currency to Dollars
            if (Operation == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Input the amount of Currency. ");
                CurrencyInput = Convert.ToDouble(Console.ReadLine());
                //The Currency value is converted into USD
                double DollarsOutput = CurrencyInput / CurrencyRate;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(CurrencyInput + "C is worth $" + DollarsOutput);
                System.Threading.Thread.Sleep(
                (int)System.TimeSpan.FromSeconds(5).TotalMilliseconds);
                Console.ForegroundColor = ConsoleColor.Gray;
                System.Environment.Exit(1);
            }

            //Currency bank
            if (Operation == 3)
            {
                Console.WriteLine("You have " + bank + "C in your bank account.");
                //Show the USD worth of Currency in the bank account. Because why not.
                double BankWorth = Convert.ToDouble(bank) / CurrencyRate;
                Console.WriteLine("You have $" + BankWorth + " worth of Currency in your bank account.");
                Console.WriteLine("1) Deposit");
                Console.WriteLine("2) Withdraw");
                Console.WriteLine(">2) exit");
                Console.Write(">");
                BankOperation = Convert.ToDouble(Console.ReadLine());
                //Deposit into the account.
                if (BankOperation == 1)
                {
                    Console.WriteLine("Please enter how much C to deposit.");
                    Console.Write(">");
                    Deposit = Convert.ToDouble(Console.ReadLine());
                    double AfterDeposit = Convert.ToDouble(bank) + Deposit;
                    //Sends the Currency to the bank account
                    System.IO.File.WriteAllText(@"C:\Users\conner smith\source\repos\CalcBase\bank.txt", Convert.ToString(AfterDeposit));
                    Console.WriteLine("Deposit Successful!");
                    System.Threading.Thread.Sleep(
                    (int)System.TimeSpan.FromSeconds(3).TotalMilliseconds);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    System.Environment.Exit(1);
                }

                else
                {
                    //Withdraw Currency from the bank account
                    if (BankOperation == 2)
                    {
                        Console.WriteLine("Please enter how much C to withdraw.");
                        Console.Write(">");
                        Withdraw = Convert.ToDouble(Console.ReadLine());
                        double AfterWithdraw = Convert.ToDouble(bank) - Withdraw;
                        //Get the Currency out of the bank account
                        System.IO.File.WriteAllText(@"C:\Users\conner smith\source\repos\CalcBase\bank.txt", Convert.ToString(AfterWithdraw));
                        Console.WriteLine("Withdraw Successful!");
                        System.Threading.Thread.Sleep(
                        (int)System.TimeSpan.FromSeconds(3).TotalMilliseconds);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        System.Environment.Exit(1);
                    }



                    else
                    {
                        System.Environment.Exit(1);
                    }

                }

            }

            //Currency shop
            if (Operation == 4)
            {
                //Connects to the shop and see what item is being sold.
                Console.WriteLine("Loading. Please Wait...");
                System.Threading.Thread.Sleep(
                (int)System.TimeSpan.FromSeconds(5).TotalMilliseconds);
                //List the item that is for sale
                Console.WriteLine("In store today: ");
                Console.WriteLine("Item (1234C)");
                Console.WriteLine("You have " + bank + "C in your bank account.");
                Console.WriteLine("1) Buy");
                Console.WriteLine("2) No thanks");
                Console.Write(">");
                ShopChoice = Convert.ToDouble(Console.ReadLine());

                //If the user chooses to buy the item:
                if (ShopChoice == 1)
                {
                    //Set the price of the item here
                    double ShopPrice = 40000;
                    double AfterShop = Convert.ToDouble(bank) - ShopPrice;
                    Console.WriteLine("You will have " + AfterShop + "C left after this purchase.");
                    Console.WriteLine("1) Buy");
                    Console.WriteLine("~1) Cancel");
                    Console.Write(">");
                    ShopConfirm = Convert.ToDouble(Console.ReadLine());
                    if (ShopConfirm == 1)
                    {
                        //Purchase the item and send it to the user
                        System.IO.File.WriteAllText(@"C:\Users\conner smith\source\repos\CalcBase\NCBANK.txt", Convert.ToString(AfterShop));
                        Console.WriteLine("Your item has been purchased. Thank you!");
                        System.Threading.Thread.Sleep(
                        (int)System.TimeSpan.FromSeconds(5).TotalMilliseconds);
                        System.Environment.Exit(1);
                    }

                }

            }

        }

    }
}
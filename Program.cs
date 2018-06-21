/*PLEASE READ:
IT IS VERY IMPORTANT YOU EDIT THIS FILE TO INCLUDE THE PROPER FILE PATHS, CURRENCY EXCHANGE RATES, AND VARIABLES.
THE BANK AND STORE FUNCTIONS DON'T ACTUALLY BUY OR DO ANYTHING REALLY. THEY'RE JUST FOR FUN.
*/

/*
 Setting up CoinCalc
First, create a new project in Visual Studio using C# .NET (Not .NET core)
* If you already have a CoinCalc project, you can skip that step.
Make a new text file called "cBANK.txt" somewhere on your computer and type a 0 in the file and save.
* If you already have a cBANK file, you can skip that step.
In every place where you see "cBANK.txt", replace that with the file path to your cBANK.txt file.
If you are on Mac, move the file into the bin/debug/ folder of the project and leave the name as "cBANK.TXT"
Compile and run.
For questions and support, email me at conner@smith.net or talk to me on Discord: @conner.#1234
 */

//Define the system libraries needed for compiling.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//Makes a namespace for our program and give it a name.
namespace CoinCalc

{
    //The class for the main program script.
    public class Program

    {
        //Define all the variables we will need.
        private static string CurrencySign;
        private static string CurrencyName;
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
        private static string StopItem;
        private static double ShopItemWorth;
        private static double Rate;
        //Jesus christ thats a lot of variables!



        //The actual program is located here.
        public static void Main()


        {
            //Defines the file where the bank account is stored.
            string bank = System.IO.File.ReadAllText(@"cBANK.txt");

            /*
            Set the rate of exchange for your currency.
            If $1 is worth more than one of your currency, the rate should be a normal number.
            If $1 is worth less than one of your currency, the rate should be a lower than zero decimal.
            */
            double Rate = 1000;

            //Set the name and symbol for your currency here
            string CurrencySign = "C";
            string CurrencyName = "Currency";


            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Welcome to CoinCalc!");
            Console.WriteLine("Now loading...");
            System.Threading.Thread.Sleep(
            (int)System.TimeSpan.FromSeconds(5).TotalMilliseconds);
            Console.ForegroundColor = ConsoleColor.White;
            //Choose what to do
            Console.WriteLine("1) Dollars to " + CurrencyName);
            Console.WriteLine("2) " + CurrencyName + " to Dollars");
            Console.WriteLine("3) " + CurrencyName + " Bank");
            Console.WriteLine("4) " + CurrencyName + " Shop");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("5+) Exit");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please input your choice.");
            Console.Write(">");
            Operation = Convert.ToDouble(Console.ReadLine());

            //Calculate Dollars into your curreny.
            if (Operation == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Input the amount of Dollars. ");
                DollarsInput = Convert.ToDouble(Console.ReadLine());
                //The USD value is converted into your currency.
                double CurrenyOutput = DollarsInput * Rate;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("$" + DollarsInput + " is worth " + CurrencyOutput + CurrencySign);
                System.Threading.Thread.Sleep(
                (int)System.TimeSpan.FromSeconds(5).TotalMilliseconds);
                Console.ForegroundColor = ConsoleColor.Gray;
                System.Environment.Exit(1);
            }

            //Currency to Dollars
            if (Operation == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Input the amount of " + CurrencyName + " ");
                CurrencyInput = Convert.ToDouble(Console.ReadLine());
                //The currency value is converted into USD
                double DollarsOutput = CurrencyInput / Rate;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(CurrencyInput + CurrencySign + " is worth $" + DollarsOutput);
                System.Threading.Thread.Sleep(
                (int)System.TimeSpan.FromSeconds(5).TotalMilliseconds);
                Console.ForegroundColor = ConsoleColor.Gray;
                System.Environment.Exit(1);
            }

            //Currency bank
            if (Operation == 3)
            {
                Console.WriteLine("You have " + bank + CurrencySign + " in your bank account.");
                //Show the USD worth of your curreny in the bank account. Because why not.
                double BankWorth = Convert.ToDouble(bank) / Rate;
                Console.WriteLine("You have $" + BankWorth + " worth of " + CurrencyName + " in your bank account.");
                Console.WriteLine("1) Deposit");
                Console.WriteLine("2) Withdraw");
                Console.WriteLine("3+) exit");
                Console.Write(">");
                BankOperation = Convert.ToDouble(Console.ReadLine());
                //Deposit into the account.
                if (BankOperation == 1)
                {
                    Console.WriteLine("Please enter how much " + CurrencySign + " to deposit.");
                    Console.Write(">");
                    Deposit = Convert.ToDouble(Console.ReadLine());
                    double AfterDeposit = Convert.ToDouble(bank) + Deposit;
                    //Sends the currency to the bank account
                    File.WriteAllText(@"cBANK.txt", Convert.ToString(AfterDeposit));
                    string NewBank = File.ReadAllText(@"cBANK.txt");
                    if (Convert.ToDouble(NewBank) == AfterDeposit)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Deposit Successful!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Hmm.. There seems to be an error...");
                    }
                    System.Threading.Thread.Sleep(
                    (int)System.TimeSpan.FromSeconds(3).TotalMilliseconds);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    System.Environment.Exit(1);
                }

                else
                {
                    //Withdraw currency from the bank account
                    if (BankOperation == 2)
                    {
                        Console.WriteLine("Please enter how much " + CurrencySign + " to withdraw.");
                        Console.Write(">");
                        Withdraw = Convert.ToDouble(Console.ReadLine());
                        double AfterWithdraw = Convert.ToDouble(bank) - Withdraw;
                        //Get the currency out of the bank account
                        File.WriteAllText(@"cBANK.txt", Convert.ToString(AfterWithdraw));
                        string NewBank = File.ReadAllText(@"cBANK.txt");
                        if (Convert.ToDouble(NewBank) == AfterWithdraw)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Deposit Successful!");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Hmm.. There seems to be an error...");
                        }
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
                //Set the price of the item here (in Currency)
                double ShopPrice = 1234;
                //Set the name of the item here
                string ShopItem = "Shop item";
                Console.WriteLine(ShopItem + " (" + ShopPrice + CurrencySign + ")");
                double ShopItemWorth = ShopPrice / Rate;
                Console.WriteLine("This item is worth $" + ShopItemWorth);
                Console.WriteLine("You have " + bank + CurrencySign + " in your bank account.");
                Console.WriteLine("1) Buy");
                Console.WriteLine("2) No thanks");
                Console.Write(">");
                ShopChoice = Convert.ToDouble(Console.ReadLine());

                //If the user chooses to buy the item:
                if (ShopChoice == 1)
                {
                    double AfterShop = Convert.ToDouble(bank) - ShopPrice;
                    Console.WriteLine("You will have " + AfterShop + CurrencySign + " left after this purchase.");
                    Console.WriteLine("1) Buy");
                    Console.WriteLine("2+) Cancel");
                    Console.Write(">");
                    ShopConfirm = Convert.ToDouble(Console.ReadLine());
                    if (ShopConfirm == 1)
                    {
                        if (Convert.ToDouble(bank) >= ShopPrice)
                        {
                            //Purchase the item and send it to the user
                            File.WriteAllText(@"cBANK.txt", Convert.ToString(AfterShop));
                            string NewBank = File.ReadAllText(@"cBANK.txt");
                            if (Convert.ToDouble(NewBank) == AfterShop)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Your item has been purchased. Thank you!");
                                if (Convert.ToDouble(bank) == ShopPrice)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("!!WARNING!!");
                                    Console.WriteLine("You are out of money.");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Hmm.. There seems to be an error...");
                            }

                            System.Threading.Thread.Sleep(
                            (int)System.TimeSpan.FromSeconds(5).TotalMilliseconds);
                            System.Environment.Exit(1);

                        }

                        else
                        {
                            Console.WriteLine("Sorry, you don't have enough money.");
                            System.Threading.Thread.Sleep(
                            (int)System.TimeSpan.FromSeconds(5).TotalMilliseconds);
                            System.Environment.Exit(1);
                        }

                    }

                }

            }

        }

    }

}

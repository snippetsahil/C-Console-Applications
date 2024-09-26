namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Welcome To HDFC Bank");
            Console.WriteLine("Please Enter Your PIN To Access Your Account ");

            int PIN = 8984; int balance = 2000;
            Console.WriteLine("");
            Console.WriteLine("PLEASE ENTER YOUR 4 DIGIT PIN");
            int passCode = Convert.ToInt32(Console.ReadLine());
            // PIN = passCode;

            if (PIN == passCode)
            {
                Console.WriteLine("");
                Console.WriteLine("-----------------------");
                Console.WriteLine("");
                Console.WriteLine("!!WELCOME TO HDFC BANK  // CHOOSE YOUR OPTION!!");
                Console.WriteLine("!!CURRENT BALANCE " + (balance) + " RUPEES!!");
                Console.WriteLine("");
                Console.WriteLine("-----------------------"); 
                Console.WriteLine(""); 
                Console.WriteLine("1. Cash withdrawal");
                Console.WriteLine("2. Cash Deposit");
                Console.WriteLine("3.Balance check ");

                Console.Write("Select option: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter money to be withdrawn:");
                        // get the withdrawal money from user
                         int withdraw = Convert.ToInt32(Console.ReadLine());
                        // check whether the balance is greater than or equal to the withdrawal amount
                        if (balance >= withdraw)
                        {
                            // remove the withdrawal amount from the total balance
                            balance = balance - withdraw;
                            Console.WriteLine("Please collect your money");
                        }
                        else
                        {
                            // show custom error message
                            Console.WriteLine("Insufficient Balance");
                        }
                        Console.WriteLine("");
                        break;

                    case 2:
                        Console.Write("Enter money to be deposited:");
                        // get deposit amount from the user
                        int deposit = Convert.ToInt32(Console.ReadLine());
                        // add the deposit amount to the total balance
                        balance = balance + deposit;
                        Console.WriteLine("Your Money has been successfully deposited");
                        Console.WriteLine("");
                        break;

                    case 3:
                        // display the total balance of the user
                        Console.WriteLine("Balance : " + balance);
                        Console.WriteLine("");
                        break;

                    case 4:
                        // exit from the menu
                        Environment.Exit(0);
                        break;
                }
            }

            else
            {
                Console.WriteLine("");
                Console.WriteLine("INVALID PIN. PLEASE TRY AGAIN.");
            }
            Console.ReadLine();

        }
    }
}

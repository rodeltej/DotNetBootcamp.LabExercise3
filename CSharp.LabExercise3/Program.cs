using System;

namespace CSharp.LabExercise3
{

    class Account
    {
        public decimal Balance { get; set; }


        public Account()
        {
            this.Balance = 0;
        }
    }

    class CheckBalance
    {
        Account account;
        public CheckBalance(Account account)
        {
            this.account = account;
        }

        public void GetBalance()
        {
            Console.WriteLine("Your current account balance is: {0}", account.Balance);
        }

    }

    class FundDeposit
    {
        Account account;

        public FundDeposit(Account account)
        {
            this.account = account;
        }

        public void DepositToFund(decimal amount)
        {
            account.Balance += amount;
        }

    }

    class FundWithdrawal
    {
        Account account;

        public FundWithdrawal(Account account)
        {
            this.account = account;
        }

        public void WithdrawFromFund(decimal amount)
        {
            account.Balance -= amount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Account account = new Account();
            CheckBalance checkBalance = new CheckBalance(account);
            FundDeposit fundDeposit = new FundDeposit(account);
            FundWithdrawal fundWithdrawal = new FundWithdrawal(account);
            long accountNumber = 11223344556;
            int pinCode = 1379;

            while (true)
            {

                Console.WriteLine("Enter your account number: ");
                long accountNum1 = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter your pin: ");
                int pinCod1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");


                if (accountNum1 == accountNumber && pinCod1 == pinCode)
                {
                    Console.WriteLine("Welcome John!\n");
                    break;
                }
                else if (accountNum1 != accountNumber || pinCod1 != pinCode)
                {
                    Console.WriteLine("Incorrect credentials. Please try again.");
                    Console.WriteLine("");
                }

            }


            while (true)
            {
                Console.WriteLine("*************** Welcome to ATM Service ***************\n\n");
                Console.WriteLine("1. Check Balance\n");
                Console.WriteLine("2. Withdraw Cash\n");
                Console.WriteLine("3. Deposit Cash\n");
                Console.WriteLine("4. Quit\n");
                Console.WriteLine("******************************************************\n\n");
                Console.Write("Enter number of your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");



                if (choice == 1)
                {
                    Console.WriteLine("Account number: {0}", accountNumber);
                    checkBalance.GetBalance();
                    Console.WriteLine("\nThank you for using this ATM Service!");
                    Console.WriteLine("");
                    continue;
                }
                else if (choice == 2)
                {
                    bool withdrawTransaction = true;
                    while (withdrawTransaction)
                    {
                        Console.Write("Enter Withdraw Amount: ");
                        Console.WriteLine("");
                        string withAmount = Console.ReadLine();
                        decimal withdrawAmount = 0;
                        bool success = decimal.TryParse(withAmount, out withdrawAmount);

                        if (success)
                        {
                            if (withdrawAmount < 0 || (withdrawAmount % 100 != 0 && withdrawAmount > 0 && withdrawAmount < account.Balance))
                            {
                                Console.WriteLine("\nInvalid amount! Amount must be a positive number and should be divisible by 100.");
                                Console.WriteLine("");
                            }

                            else if (withdrawAmount <= account.Balance && withdrawAmount % 100 == 0)
                            {
                                fundWithdrawal.WithdrawFromFund(withdrawAmount);
                                Console.WriteLine("");
                                Console.WriteLine("You have successfully withdrawn {0} from your account.", withdrawAmount);
                                Console.WriteLine("");
                                Console.WriteLine("Account number: {0}", accountNumber);
                                checkBalance.GetBalance();
                                Console.WriteLine("Please get your money.");
                                Console.WriteLine("\nThank you for using this ATM Service!");
                                Console.WriteLine("");
                                withdrawTransaction = false;
                            }
                            else if (withdrawAmount > account.Balance)
                            {
                                Console.WriteLine("Insufficient Funds!");
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid Input. Please enter numbers only.");
                            Console.WriteLine("");
                        }

                    }
                    continue;

                }
                else if (choice == 3)
                {
                    bool depositTransaction = true;
                    while (depositTransaction)
                    {
                        Console.Write("\nEnter Deposit Amount: ");
                        string depoAmount = Console.ReadLine();
                        decimal depositAmount = 0;
                        Console.WriteLine("");
                        bool success = decimal.TryParse(depoAmount, out depositAmount);

                        if (success)
                        {
                            if (depositAmount >= 0)
                            {
                                fundDeposit.DepositToFund(depositAmount);
                                Console.WriteLine("You have successfully deposited {0} to your account.", depositAmount);
                                Console.WriteLine("");
                                Console.WriteLine("Account number: {0}", accountNumber);
                                checkBalance.GetBalance();
                                Console.WriteLine("\nThank you for using this ATM Service!");
                                Console.WriteLine("");
                                depositTransaction = false;
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount. Please input a positive amount.");
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid Input. Please enter numbers only.");
                        }

                    }
                    continue;

                }
                else if (choice == 4)
                {
                    Console.WriteLine("\nThank you for using this ATM Service!");
                    Console.WriteLine("Have a great day!");
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid Input!\n");
                    continue;
                }
            }


        }
    }
}

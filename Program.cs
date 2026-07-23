using System;

public class HelloWorld
{
    static void ShowMenu()
    {
        Console.WriteLine("1. Balance");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Deposit");
        Console.WriteLine("4. Transfer");
        Console.WriteLine("5. Exit");
    }

    static void ShowMenuFa()
    {
        Console.WriteLine("1. موجودی");
        Console.WriteLine("2. برداشت");
        Console.WriteLine("3. واریز");
        Console.WriteLine("4. انتقال");
        Console.WriteLine("5. خروج");
    }

    static void ShowBalance(double balance)
    {
        Console.WriteLine("Your balance: " + balance);
    }

    static void ShowBalanceFa(double balance)
    {
        Console.WriteLine("موجودی شما: " + balance);
    }

    static double Withdraw(double balance, double amount, int language)
    {
        if (amount <= balance)
        {
            balance -= amount;

            if (language == 1)
                ShowBalance(balance);
            else
                ShowBalanceFa(balance);
        }
        else
        {
            if (language == 1)
                Console.WriteLine("Insufficient Balance!");
            else
                Console.WriteLine("موجودی کافی نمی باشد");
        }

        return balance;
    }

    static double Deposit(double balance, double amount, int language)
    {
        if (amount > 0)
        {
            balance += amount;

            if (language == 1)
                ShowBalance(balance);
            else
                ShowBalanceFa(balance);
        }
        else
        {
            if (language == 1)
                Console.WriteLine("Invalid amount!");
            else
                Console.WriteLine("مبلغ نامعتبر است!");
        }

        return balance;
    }

    static double Transfer(double balance, double amount, ref double account1, int language)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            account1 += amount;

            if (language == 1)
                Console.WriteLine("Transfer Successful!");
            else
                Console.WriteLine("انتقال با موفقیت انجام شد");

            if (language == 1)
                ShowBalance(balance);
            else
                ShowBalanceFa(balance);
        }
        else
        {
            if (language == 1)
                Console.WriteLine("Insufficient Balance!");
            else
                Console.WriteLine("موجودی کافی نمی باشد");
        }

        return balance;
    }

    static void Main()
    {
        int pin = 1234;
        double balance = 1000000;
        double account1 = 5000;

        Console.WriteLine("===== ATM =====");
        Console.WriteLine("1. English");
        Console.WriteLine("2. فارسی");
        Console.Write("Choose Language / انتخاب زبان: ");

        int language;

        while (!int.TryParse(Console.ReadLine(), out language) || (language != 1 && language != 2))
        {
            Console.Write("Please enter 1 or 2: ");
        }


        int attempts = 0;
        int pinUser;
        while (attempts < 3)
        {
            if (language == 1)
                Console.Write("Enter PIN: ");
            else
                Console.Write("رمز را وارد کنید: ");

            while (!int.TryParse(Console.ReadLine(), out pinUser))
            {
                if (language == 1)
                    Console.Write("Please enter numbers only: ");
                else
                    Console.Write("فقط عدد وارد کنید: ");
            }

            if (pinUser == pin)
                break;

            attempts++;

            if (language == 1)
            {
                Console.WriteLine("Incorrect PIN!");
                Console.WriteLine("Attempts left: " + (3 - attempts));
            }
            else
            {
                Console.WriteLine("رمز اشتباه است!");
                Console.WriteLine("تعداد تلاش باقیمانده: " + (3 - attempts));
            }
        }

        if (attempts == 3)
        {
            if (language == 1)
                Console.WriteLine("Your card has been blocked.");
            else
                Console.WriteLine("کارت شما مسدود شد.");

            return;
        }

        if (language == 1)
            Console.WriteLine("Login Successful!");
        else
            Console.WriteLine("ورود موفقیت آمیز بود");

        bool exit = false;

        while (!exit)
        {
            if (language == 1)
                ShowMenu();
            else
                ShowMenuFa();

            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                if (language == 1)
                    Console.Write("Please enter a number: ");
                else
                    Console.Write("لطفاً یک عدد وارد کنید: ");
            }

            switch (choice)
            {
                case 1:
                    if (language == 1)
                        ShowBalance(balance);
                    else
                        ShowBalanceFa(balance);
                    break;

                case 2:
                    double withdrawAmount;

                    if (language == 1)
                        Console.Write("Enter amount: ");
                    else
                        Console.Write("مبلغ را وارد کنید: ");

                    while (!double.TryParse(Console.ReadLine(), out withdrawAmount))
                    {
                        if (language == 1)
                            Console.Write("Please enter a valid amount: ");
                        else
                            Console.Write("لطفاً مبلغ معتبر وارد کنید: ");
                    }

                    balance = Withdraw(balance, withdrawAmount, language);
                    break;

                case 3:
                    double depositAmount;

                    if (language == 1)
                        Console.Write("Enter amount: ");
                    else
                        Console.Write("مبلغ را وارد کنید: ");

                    while (!double.TryParse(Console.ReadLine(), out depositAmount))
                    {
                        if (language == 1)
                            Console.Write("Please enter a valid amount: ");
                        else
                            Console.Write("لطفاً مبلغ معتبر وارد کنید: ");
                    }

                    balance = Deposit(balance, depositAmount, language);


                    balance = Deposit(balance, depositAmount, language);
                    break;

                case 4:
                    double transferAmount;

                    if (language == 1)
                        Console.Write("Enter transfer amount: ");
                    else
                        Console.Write("مبلغ انتقال را وارد کنید: ");

                    while (!double.TryParse(Console.ReadLine(), out transferAmount))
                    {
                        if (language == 1)
                            Console.Write("Please enter a valid amount: ");
                        else
                            Console.Write("لطفاً مبلغ معتبر وارد کنید: ");
                    }

                    balance = Transfer(balance, transferAmount, ref account1, language);
                    break;

                case 5:
                    exit = true;

                    if (language == 1)
                        Console.WriteLine("Thank you for using our ATM.");
                    else
                        Console.WriteLine("از استفاده از خودپرداز متشکریم.");

                    break;

                default:
                    if (language == 1)
                        Console.WriteLine("Invalid choice!");
                    else
                        Console.WriteLine("انتخاب نامعتبر است!");
                    break;
            }
        }
    }
}

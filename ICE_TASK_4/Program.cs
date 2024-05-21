using System;

class BankAccount
{
    public string AccountNumber { get; }
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string accountNumber, string owner, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be greater than zero.");
            return;
        }
        Balance += amount;
        Console.WriteLine($"${amount} deposited successfully. Current balance: ${Balance}");
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be greater than zero.");
            return;
        }
        if (amount > Balance)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }
        Balance -= amount;
        Console.WriteLine($"${amount} withdrawn successfully. Current balance: ${Balance}");
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account Holder: {Owner}");
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Current Balance: ${Balance}");
    }
}

class Program
{
    static BankAccount[] accounts;

    static void Main(string[] args)
    {
        InitializeAccounts();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nWelcome to the Bank!");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateAccount();
                    break;
                case 2:
                    Deposit();
                    break;
                case 3:
                    Withdraw();
                    break;
                case 4:
                    CheckBalance();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void InitializeAccounts()
    {
        accounts = new BankAccount[10]; // Maximum 10 accounts
    }

    static void CreateAccount()
    {
        Console.Write("Enter account number: ");
        string accNumber = Console.ReadLine();
        Console.Write("Enter account holder name: ");
        string accHolder = Console.ReadLine();
        Console.Write("Enter initial balance: $");
        decimal initialBalance = decimal.Parse(Console.ReadLine());

        BankAccount newAccount = new BankAccount(accNumber, accHolder, initialBalance);

        // Find an empty slot in accounts array
        for (int i = 0; i < accounts.Length; i++)
        {
            if (accounts[i] == null)
            {
                accounts[i] = newAccount;
                Console.WriteLine("Account created successfully.");
                return;
            }
        }
        Console.WriteLine("Maximum accounts limit reached.");
    }

    static void Deposit()
    {
        Console.Write("Enter account number: ");
        string accNumber = Console.ReadLine();

        BankAccount account = FindAccount(accNumber);
        if (account != null)
        {
            Console.Write("Enter amount to deposit: $");
            decimal amount = decimal.Parse(Console.ReadLine());
            account.Deposit(amount);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static void Withdraw()
    {
        Console.Write("Enter account number: ");
        string accNumber = Console.ReadLine();

        BankAccount account = FindAccount(accNumber);
        if (account != null)
        {
            Console.Write("Enter amount to withdraw: $");
            decimal amount = decimal.Parse(Console.ReadLine());
            account.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static void CheckBalance()
    {
        Console.Write("Enter account number: ");
        string accNumber = Console.ReadLine();

        BankAccount account = FindAccount(accNumber);
        if (account != null)
        {
            account.CheckBalance();
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }

    static BankAccount FindAccount(string accNumber)
    {
        foreach (BankAccount acc in accounts)
        {
            if (acc != null && acc.AccountNumber == accNumber)
            {
                return acc;
            }
        }
        return null;
    }
}

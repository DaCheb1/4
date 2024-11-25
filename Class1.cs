using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._11._20234
{
    internal class Class1
    {
    }
}

public class BankAccount
{
    public string Username { get; private set; }
    public decimal Balance { get; private set; }

    public BankAccount(string username, decimal initialBalance)
    {
        Username = username;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма пополнения должна быть положительной.");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сумма снятия должна быть положительной.");
        if (Balance - amount < 0)
            throw new InvalidOperationException("Недостаточно средств для снятия.");

        Balance -= amount;
    }

    public void Transfer(BankAccount targetAccount, decimal amount)
    {
        if (targetAccount == null)
            throw new ArgumentNullException(nameof(targetAccount));

        Withdraw(amount);
        targetAccount.Deposit(amount);
    }
}

// Пример тестирования
public class Program
{
    public static void Main(string[] args)
    {
        BankAccount account1 = new BankAccount("Пользователь1", 1000);
        BankAccount account2 = new BankAccount("Пользователь2", 500);

        account1.Deposit(500);
        Console.WriteLine($"Баланс {account1.Username}: {account1.Balance}"); // 1500

        account1.Withdraw(200);
        Console.WriteLine($"Баланс {account1.Username}: {account1.Balance}"); // 1300

        account1.Transfer(account2, 300);
        Console.WriteLine($"Баланс {account1.Username}: {account1.Balance}"); // 1000
        Console.WriteLine($"Баланс {account2.Username}: {account2.Balance}"); // 800
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Delegate
{
    public delegate void LowBalanceHandler(object sender, EventArgs e);
    public interface IAccount
    {
        event LowBalanceHandler LowBalance;
    }
    public abstract class Account
    {
        public double Balance { get; protected set; }
        public abstract void Deposit(double amount);
        public abstract void Withdrawal(double amount);
    }
    public class SavingAccounts : Account, IAccount
    {
        public event LowBalanceHandler LowBalance;

        public override void Deposit(double amount)
        {
            this.Balance += amount;
        }

        public override void Withdrawal(double amount)
        {
            if (this.Balance-amount > 10000)
            {
                this.Balance -= amount;
            }
            else
            {
                LowBalance?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SavingAccounts acc = new SavingAccounts();
            //using  event handler to execute delegate
            //acc.LowBalance += new LowBalanceHandler(acc_LowBalance);
            //acc.LowBalance += acc_LowBalance;


            //Anonymous function
            //acc.LowBalance += delegate (object sender, EventArgs e)
            //{
            //    Console.WriteLine("Oops no Money");
            //};


            //Lambda expression
            //acc.LowBalance +=  ( sender,  e) => Console.WriteLine("Oops no Money");
            //OR
            acc.LowBalance += (sender, e) =>
            {
                Console.WriteLine("Oops no Money");
            };


            Console.WriteLine(acc.Balance);
            acc.Deposit(50000);
            Console.WriteLine(acc.Balance);
            acc.Withdrawal(35000);
            Console.WriteLine(acc.Balance);
            acc.Withdrawal(10000);
            Console.WriteLine(acc.Balance);
        }

        private static void acc_LowBalance(object sender, EventArgs e)
        {
            Console.WriteLine("Insufficient Balance");
        }
    }
}

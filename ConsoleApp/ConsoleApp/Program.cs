using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc1 = new Account(5000);
            acc1.Put(220);
            Account.AccountStateHandler colorHandler = new Account.AccountStateHandler(ColorDisplay);

            acc1.RegisterHandler(Display);
            acc1.RegisterHandler(colorHandler);
            acc1.Withdraw(1200);

            acc1.UnRegisterHandler(Display);
            acc1.Withdraw(560);
            acc1.Withdraw(7000);            
        }

        static void Display(string message)
        {
            Console.WriteLine("Method Display");
            Console.WriteLine(message);
        }

        static void ColorDisplay(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Method ColorDisplay");
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }

    class Account
    {
        private int sum;
        public delegate void AccountStateHandler(string message);
        AccountStateHandler _handler;
        public Account(int sum)
        {
            this.sum = sum;
        }

        public void RegisterHandler(AccountStateHandler handler)
        {
            _handler += handler;
        }

        public void UnRegisterHandler(AccountStateHandler handler)
        {
            _handler -= handler;
        }

        public int CurentSum {
            get
            {
                return sum;
            }
        }

        public void Put(int sum)
        {
            if (sum > 0)
                this.sum += sum;
        }

        public void Withdraw(int sum)
        {
            if (sum < this.sum)
            {
                this.sum -= sum;
                _handler?.Invoke($"Сумма {sum} была снята");
            }
            else
            {
                _handler?.Invoke($"На счете недостаточно денег");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void MyDelegate();
    public delegate void MyDelegate2(string text);
    public delegate int MyDelegate3(int number1, int number2);
    class Program
    {
        static void Main(string[] args)
        {
            //DelegateDemo();
            Calculator calculator = new Calculator();
            Func<int, int, int> func = calculator.Sum;
            Console.WriteLine(func(3, 4));

            Func<int> getRandomNumber = delegate ()
            {
                Random random = new Random();
                return random.Next(1, 100);
            };

            Func<int> getRandomNumber2 = () => new Random().Next(1, 100);

            Console.WriteLine(getRandomNumber2());


            

            Console.ReadLine();
        }

        

        private static void DelegateDemo()
        {
            CustomerManager customerManager = new CustomerManager();
            MyDelegate myDelegate1 = customerManager.SendMessage;
            myDelegate1 += customerManager.ShowAlert;
            myDelegate1 -= customerManager.SendMessage;
            myDelegate1();

            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2("hello my friend");

            Calculator calculator = new Calculator();
            MyDelegate3 myDelegate3 = calculator.Sum;
            myDelegate3 += calculator.Multiply;
            var result = myDelegate3(1, 3);

            Console.WriteLine(result);
        }
    }

    public class Calculator
    {
        public int Sum(int number1, int number2)
        {
            return number1 + number2;
        }

        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        public int GetRandomNumber(int min, int max)
        {
            return new Random().Next(min, max);
        }
    }

    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("message sended.!");
        }

        public void ShowAlert()
        {
            Console.WriteLine("be carefull");
        }

        public void SendMessage2(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }
}

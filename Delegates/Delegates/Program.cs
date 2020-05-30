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
            Console.ReadLine();
        }
    }

    public class Calculator
    {
        public int Sum(int number1,int number2)
        {
            return number1 + number2;
        }

        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
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

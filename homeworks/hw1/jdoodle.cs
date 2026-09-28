using System;
using System.Collections.Generic;


namespace HelloWorld
{
   class Program
   {
      static double PopolnitBalance(double balance, List <string> history)
      {
          Console.Write("Введите сумму: ");
          double n = Convert.ToDouble(Console.ReadLine());
          if (n > 0)
          {
              balance += n;
              history.Add($"Пополнение счета: +{n:F2}");
              Console.WriteLine($"Вы пополнили счет на {n:F2}");
          }
          else
          {
              Console.WriteLine("Зачем ты вводищь отрицательную сумму?");
          }
          return balance;
      }
      
      static double SnyatBalance(double balance, List <string> history)
      {
          Console.Write("Введите сумму: ");
          double n = Convert.ToDouble(Console.ReadLine());
          if (n > 0)
          {
              if (n <= balance)
              {
                  balance -= n;
                  history.Add($"Снятие со счета: -{n:F2}");
                  Console.WriteLine($"Вы сняли со счета {n:F2}");
              }
              else
              {
                  Console.WriteLine("У вас нет такой суммы");
                  Console.WriteLine($"Вы не можете снять больше чем {balance:F2}");
              }
          }
          else
          {
              Console.WriteLine("Зачем ты вводищь отрицательную сумму?");
          }
          return balance;
      }
      
      static void PrintBalance(double balance, string currency = "₽")
      {
          Console.WriteLine($"Ваш баланс: {balance:F2} {currency}");
      }
      
      static void PrintIstorya(List <string> history)
      {
          if (history.Count == 0)
          {
              Console.WriteLine("История пуста");
          }
          else
          {
              Console.WriteLine("История операций:");
              for (int i=0; i<history.Count; i++)
              {
                  Console.WriteLine($"{i+1}. {history[i]}");
              }
          }
      }
      
      static void Main(string[] args)
      {
          Console.Write("Введите изначальный баланс: ");
          double balance = Convert.ToDouble(Console.ReadLine());
          List <string> history = new List <string> ();
          
          int n = 8;
          while (true)
         {
             Console.WriteLine();
             Console.WriteLine("Меню:");
             Console.WriteLine("0. Выйти");
             Console.WriteLine("1. Показать баланс");
             Console.WriteLine("2. Пополнить счет");
             Console.WriteLine("3. Снять деньги");
             Console.WriteLine("4. Показать историю");
             Console.Write("Выберите пункт меню: ");
             Console.WriteLine();
             n = int.Parse(Console.ReadLine());
             if (n == 1)
             {
                 PrintBalance(balance);
             }
             else if (n == 2)
             {
                 balance = PopolnitBalance(balance, history);
             }
             else if (n == 3)
             {
                 balance = SnyatBalance(balance, history);
             }
             else if (n == 4)
             {
                 PrintIstorya(history);
             }
             else if (n == 0)
             {
                 Console.WriteLine("Вы остались без денег");
                 break;
             }
             else
             {
                 Console.WriteLine("Такого пункта нет");
             }
         }
      }
   }
}
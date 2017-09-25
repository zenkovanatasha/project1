using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Function
    {
        private double y,z;
        public double xn, xk, step = -1, F; // Х конечное, начальное, шаг функции
        public int number;
        public void InputX()/// Метод для введения Х начального, конечного и шага функции
        {
            Console.WriteLine("Введите Xначальное и Хконечное:");
            xn = Convert.ToDouble(Console.ReadLine());
            xk = Convert.ToDouble(Console.ReadLine());
            while (step < 0)
            {
                Console.WriteLine("Введите шаг функции:");
                step = Convert.ToDouble(Console.ReadLine());
            }
        }
        public void InputYZ()///Метод для Введения Y,Z
        {
            Console.WriteLine("Введите значение y, z:");
            y = Convert.ToDouble(Console.ReadLine());
            z = Convert.ToDouble(Console.ReadLine());
        }
        public double Computation(double x)/// Метод для рассчета значения функции и номера формулы
        {
            if (x >= 8 && x != 10)
            {
                F = Math.Pow(x + z, 3) + 1;
                number = 1;
               
            }
            else
            {
                if (x <= 1)
                {
                    F = 2 * Math.Pow(x - y, 2) + Math.Pow(x, 1 / 3);
                    number = 2;
                    
                }
                else
                {
                    F = Math.Sqrt(x + Math.Abs(z * y));
                    number = 3;
                    
                }
            }
            return F;
        }
        public void Formula() ///Метод для вывода формул на экран
        {
            Console.WriteLine("1. (x + z) ^ 3 + 1");
            Console.WriteLine("2. 2(x - y) ^ 2 + x ^ 1 / 3");
            Console.WriteLine("3. (x +| zy |) ^ 1 / 2");
        }
        public void Tabulation(double xn, double xk, double step)/// Метод для табулирования функции
        {
            double k;
            Table.TableHead(6, 8,8);
            k = Computation(xn);
            
            if (xn == xk)
            {
                Table.TableLine(xn, 6, k,number,8); 
            }
            else
            {
                do
                {
                    Table.TableLine(xn, 6, k, number, 8);
                    xn = (xn <= xk) ? xn + step : xn - step;
                    k = Computation(xn);                   
                }
                while (Math.Abs(xn - xk)>=step );
                Table.TableLine(xn, 6, k, number, 8);
            }
            Table.TableDown(6,8);
        }
    }
    class Table
        {
            private static string NameFun= "Значение функции";
            private static string NameArg="Хi",Name="Формула"; ///Заголовок столбцов       
            private int n1, n2, n3, n4; ///Ширина столбцов                                   
            public Table(string NameFun,string NameArg,string Name,int n1,int n2,int n3)
            {
                this.n1 = n1;
                this.n2 = n2;
                this.n3 = n3;
                this.n4 = n4;
        }
            public static void TableHead( int n1,int n2,int n4)/// Метод для создания шапки таблицы
            {
                Console.Write("╔");
                for (int i = 0; i < n1; i++)
                    Console.Write("═");
                Console.Write("╦");
                for (int i = 0; i < NameFun.Length; i++)
                    Console.Write("═");
                Console.Write("╦");
                for (int i = 0; i < n2; i++)
                    Console.Write("═");
                Console.WriteLine("╗");
                string s = "║{0,-" + n1.ToString() + "}║{1," + NameFun.Length.ToString() + "}║{2," + n2.ToString() + "}║";
                Console.WriteLine(s, NameArg,NameFun,Name);
                Console.Write("╠");
                for (int i = 0; i < n1; i++)
                    Console.Write("═");
                Console.Write("╬");
                for (int i = 0; i <NameFun.Length; i++)
                    Console.Write("═");
                Console.Write("╬");
                for (int i = 0; i < n2; i++)
                    Console.Write("═");
            Console.WriteLine("╣");
            }  
            public static void TableDown(int n1,int n2)/// Создание конца таблицы
            {
                Console.Write("╚");
                for (int i = 0; i < n1; i++)
                    Console.Write("═");
                Console.Write("╩");
                for (int i = 0; i < NameFun.Length; i++)
                  Console.Write("═");
                Console.Write("╩");
                for (int i = 0; i < n2; i++)
                    Console.Write("═");              
                    Console.WriteLine("╝");
            }
            public static void TableLine(double x, int n1, double y,int n3,int n2)/// Добавление строки таблицы
            {
                string s = "║{0," + n1.ToString() + "}║{1," + NameFun.Length.ToString() + ":f3}║{2,"+n2.ToString() +"}║";
                
                Console.WriteLine(s, x, y,n3);
            }
            
            
        }
    class Program
        {
            static void Main(string[] args)
            {
                Function f1 = new Function();
                Function f2 = new Function();
                f1.InputYZ();
                f1.InputX();
                
                f1.Tabulation(f1.xn,f1.xk,f1.step);
                f1.Formula();
                f2.InputYZ();
                f2.InputX();
                f2.Tabulation(f2.xn, f2.xk, f2.step);
                f2.Formula();
                Console.ReadKey();
            }
        }
}
        

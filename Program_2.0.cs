using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson_4// Осипенко В.О. 
{
    
    internal class Program
    {
        #region Метод записи в файл
        static void ProcessWriteData(string fileName, int[] lines)//метод записи в файл
        {
            StreamWriter streamWriter = new StreamWriter(fileName);


            for (int i = 0; i < lines.Length; i++)
            {
                streamWriter.WriteLine(lines[i]);
            }

            streamWriter.Close();
            Console.WriteLine("\nЗаписали в файл созданный массив из задачи 1");
        }
        #endregion


        static void Main(string[] args)
        {

            #region Задача 1 Вывести количество пар элементов массива, в которых только одно число делится на 3
            Console.WriteLine(@"                            Дан целочисленный массив из 20 элементов. 
                                Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
                                Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар элементов массива,
                                в которых только одно число делится на 3. 
                                В данной задаче под парой подразумевается два подряд идущих элемента массива.
");
            int[] mass = new int[10];//создаем массив, да в задаче написано массив из 20ти чисел, но 10 просто легче читается

            Random random = new Random();
            for (int x = 0; x < mass.Length; x++)
            {
                mass[x] = random.Next(-10000, 10001);//заполняем его значениями
                Console.Write($"{mass[x]}\t");
            }
            int counter = 0;
            for (int x = 0; x < mass.Length - 1; x++)//считаем пары, в которых только одно значение делится на 3
            {
                if (mass[x] % 3 == 0)
                {
                    if(mass[x + 1] % 3 != 0)
                    {
                        counter++;
                    }

                }
                else if (mass[x] % 3 != 0)
                {
                    if (mass[x + 1] % 3 == 0)
                    {
                        counter++;
                    }

                }
            }

            ProcessWriteData(AppDomain.CurrentDomain.BaseDirectory + "out1.txt", mass);//записали массив в файл

            Console.WriteLine("\nколичество пар, в которых хотя бы один эллемент делится на 3: " + counter);
            Console.ReadLine();
            #endregion

            #region Задача 2 Делаем задачу 1 через статический класс и статические методы
            Console.WriteLine(@"
                                        Реализуйте задачу 1 в виде статического класса StaticClass;
                            а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
                            б) Добавьте статический метод для считывания массива из текстового файла.
                                Метод должен возвращать массив целых чисел;
                            в)*Добавьте обработку ситуации отсутствия файла на диске.
");
            Console.WriteLine("\nВыполняем задачу через созданный класс");
            Console.ReadLine();
            StaticClass.ReadMass(mass);
            #endregion
        }
    }
}

static class StaticClass//создаем свой класс с методами
{
    #region Метод считывания файла с диска
    public static void ProcessData(string path)//метод считыванияи информации из файла
    {

        StreamReader streamReader = new StreamReader(path);
        try
        {
            Console.WriteLine("\nСчитываем массив из задачи 1");



            string[] massiv = new string[10];
            for (int i = 0; i < massiv.Length; i++)
            {
                massiv[i] = streamReader.ReadLine();
                Console.Write($"{massiv[i]}\t");
            }
            streamReader.Close();
        }
        catch(ArgumentNullException)
        {
            Console.WriteLine("Неопределенное значение");
        }
        
        #endregion
        Console.ReadLine();

    }


    public static void ReadMass(int[] a)//статический метод задачи 1
    {
        Console.WriteLine("\nВыполняем задачу через статический метод, статического класса");
        for (int x = 0; x < a.Length; x++)
        {
            Console.Write($"{a[x]}\t");//печатаем данный нам массив
        }
        int counter = 0;

        for (int x = 0; x < a.Length - 1; x++)//считаем пары, в которых только одно значение делится на 3
        {
            if (a[x] % 3 == 0)
            {
                if (a[x + 1] % 3 != 0)
                {
                    counter++;
                }

            }
            else if (a[x] % 3 != 0)
            {
                if (a[x + 1] % 3 == 0)
                {
                    counter++;
                }

            }
        }
        Console.WriteLine("\nколичество пар, в которых хотя бы один эллемент делится на 3: " + counter);
        Console.ReadLine();
        //Обработка ситуации при отсуствии файла
        try
        {
            ProcessData(AppDomain.CurrentDomain.BaseDirectory + "out1.txt");//Считываем файл с диска(с базовой папки)
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файла не обноружено!");
        }
        Console.ReadLine();
    }
}


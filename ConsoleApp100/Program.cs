using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp100
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();            // класс со случайными числами
            int kol_judges = rnd.Next(3, 10);    // кол-во судей
            int kol_figuresk = rnd.Next(10, 100);     // кол-во фигуристов
            int[,] chempionat = new int[kol_figuresk, kol_judges];   // вступительные данные
            double[] grade = new double[kol_judges];   // оценки участника
            double min_grade = 10;
            double max_grade = 0;
            int number_min_grade = 0;
            int number_max_grade = 0;

            for (int i = 0; i < kol_figuresk; i++) // счет фигуристов
            {
                do
                {
                    min_grade = 10; 
                    max_grade = 0; 

                    for (int f = 0; f < kol_judges; f++) // все члены жюри участвуют
                    {
                        grade[f] = (rnd.Next(-0, 100) / 10.0); //оценка

                        if (min_grade > grade[f]) // минимум
                        {
                            min_grade = grade[f];
                            number_min_grade = f;
                        }

                        if (max_grade < grade[f]) // максимум
                        {
                            max_grade = grade[f];
                            number_max_grade = f;
                        }
                    }
                }
                while (!(number_min_grade == grade[kol_judges - 1]) & !(number_min_grade == grade[kol_judges - 2]) & !(number_max_grade == grade[kol_judges - 1]) & !(number_max_grade == grade[kol_judges - 2])); // проверяем не являестя ли последнее и предпоследнее числа минимальным или максиммальным
                grade[number_min_grade] = grade[kol_judges - 1]; // меняем наименьшую оценку последним числом
                grade[number_max_grade] = grade[kol_judges - 2]; // меняем наибольшую оценку предпоследним числом 

                double summ = 0;
                double sred = 0;

                for (int n = 0; n < kol_judges - 2; n++) summ += grade[n]; // сумма всех оценок

                sred = summ / (kol_judges - 2); 


                Console.WriteLine("При подсчете результата фигурист под номером " + (i + 1) + " набрал " + Math.Round(sred, 1) + " очков."); 
                Console.WriteLine(""); 


            }
            Console.ReadKey();
        }
    }
}

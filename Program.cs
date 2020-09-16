using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером\



            //// Объявление переменных:
            int playerNumber;    // число, вводимое игроками
            int gameNumber;      // случайное число 
            byte numberOfPlayers; // количество игроков
            int gameNumberMin;    //Нижний предел случайного числа
            int gameNumberMax;    //Верхний предел случайного числа
            string robot;         // Переменная, принимающая с роботом идет игра или нет
            bool gameRun = true;  //Флаг активности игры



            //// Инициализация переменных:
            playerNumber = 0;
            Random rand = new Random();
            Console.Write($"Игра с компьютером? Д(Да)/Н(НЕТ)");
            robot = Console.ReadLine();
            Console.WriteLine($"{robot}");

           
                Console.Write($"Ввести количество игроков: ");
                numberOfPlayers = byte.Parse(Console.ReadLine());
                string[] user = new string[numberOfPlayers]; // игроки
                Console.Clear();
            if (robot == "Д")
            {
                user[user.Length - 1] = "Robot";
                for (int i = 0; i < user.Length - 1; i++)
                {
                    Console.Write($"Ввести имя {i + 1}го игрока: ");
                    user[i] = Console.ReadLine();
                    Console.Clear();
                }
            }
            else
            {
                for (int i = 0; i < user.Length; i++)
                {
                    Console.Write($"Ввести имя {i + 1}го игрока: ");
                    user[i] = Console.ReadLine();
                    Console.Clear();
                }
            }
                Console.Write($"Играют:\n");
                for (int j = 0; j < user.Length; j++)
                {
                    Console.Write($"{user[j]}\n");

                }

                while (gameRun)
                {
                    
                        Console.WriteLine($"\nВыбираем диапазон игрового числа\nВведите нижний предел:");
                        gameNumberMin = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Введите верхний предел предел:");
                        gameNumberMax = int.Parse(Console.ReadLine());
                        gameNumberMax++;
                        gameNumber = rand.Next(gameNumberMin, gameNumberMax); // Выдаёт случайное число из выбранного диапазона
                        Console.WriteLine($"Число: {gameNumber}");
                    
                    int i;
                    for (i = 0; i < user.Length; i++)
                    {
                        if ((i == user.Length - 1) && (user[user.Length - 1] == "Robot"))
                            {
                                //Console.Write($"Робот вводит число: ");
                                playerNumber = rand.Next(1, gameNumber+1);
                                Console.Write($"Робот вводит число: {playerNumber}\n");
                    }
                        else
                            {
                                Console.Write($"Игрок {user[i]} вводит число: ");
                                playerNumber = int.Parse(Console.ReadLine());
                             }
                        if(gameNumber < playerNumber)
                        {

                        Console.Write($"Игрок {user[i]} должен ввести число, меньше, либо равное {gameNumber}\n");
                            i--;
                            continue;
                        }
                        else gameNumber -= playerNumber;

                        if (gameNumber == 0)
                        {
                            Console.WriteLine($"{user[i]} победил!");
                        Console.WriteLine($"Желаете реванш?Д(Да) / Н(НЕТ)");
                            if ("Д" == Console.ReadLine())
                            {
                                break;
                            }
                            else gameRun = false;
                            
                        }
                        if (false == gameRun) break;
                        Console.WriteLine($"\nЧисло: {gameNumber}");
                        if (i == user.Length-1) i = -1;
                    }
                    if (false == gameRun)
                    {
                        break;
                    }
            }
            Console.WriteLine($"\nНажмите любую клавишу для выхода из игры");
            Console.ReadKey();
        }
    }
}


using System;

class TicTacToeV2
{
    static char[] board = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];
    static int player = 1;
    static int choice;
    static int flag = 0;
    static int scoreX = 0;
    static int scoreO = 0;
    static char symbolX = 'X';
    static char symbolO = 'O';

    public static char[] Board { get => board; set => board = value; }

    static void Main(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);
        Console.WriteLine("=== КРЕСТИКИ-НОЛИКИ (Версия 2) ===\n");

        // Кастомизация символов
        CustomizeSymbols();

        do
        {
            Console.Clear();
            Console.WriteLine("=== КРЕСТИКИ-НОЛИКИ (Версия 2) ===\n");
            Console.WriteLine($"СЧЕТ:  X ({symbolX}) - {scoreX} : {scoreO} - ({symbolO}) O\n");
            Console.WriteLine("Игрок 1: {0} | Игрок 2: {1}\n", symbolX, symbolO);

            DrawBoard();

            if (player % 2 == 0)
            {
                Console.Write($"\nХод игрока 2 ({symbolO}): ");
            }
            else
            {
                Console.Write($"\nХод игрока 1 ({symbolX}): ");
            }

            // Проверка корректности ввода
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9)
            {
                choice--;

                if (Board[choice] != symbolX && Board[choice] != symbolO)
                {
                    if (player % 2 == 0)
                    {
                        Board[choice] = symbolO;
                        player++;
                    }
                    else
                    {
                        Board[choice] = symbolX;
                        player++;
                    }
                }
                else
                {
                    Console.WriteLine("Эта клетка уже занята!");
                    Console.WriteLine("Нажмите Enter, чтобы продолжить...");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод! Введите число от 1 до 9.");
                Console.WriteLine("Нажмите Enter, чтобы продолжить...");
                Console.ReadLine();
            }

            flag = CheckWin();

            if (flag == 1 || flag == -1)
            {
                Console.Clear();
                DrawBoard();

                if (flag == 1)
                {
                    if (player % 2 == 0)
                    {
                        Console.WriteLine($"\nИгрок 1 ({symbolX}) победил!");
                        scoreX++;
                    }
                    else
                    {
                        Console.WriteLine($"\nИгрок 2 ({symbolO}) победил!");
                        scoreO++;
                    }
                }
                else
                {
                    Console.WriteLine("\nНичья!");
                }

                Console.WriteLine($"\nТекущий счет: {symbolX} - {scoreX} : {scoreO} - {symbolO}");
                Console.Write("\nХотите сыграть еще? (y/n): ");

                if (Console.ReadLine().Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    // Сброс игры
                    ResetBoard();
                    Console.Write("Хотите изменить символы? (y/n): ");
                    if (Console.ReadLine().Equals("y", StringComparison.CurrentCultureIgnoreCase))
                    {
                        CustomizeSymbols();
                    }
                }
                else
                {
                    Console.WriteLine("\nСпасибо за игру!");
                    Console.WriteLine($"Финальный счет: {symbolX} - {scoreX} : {scoreO} - {symbolO}");
                    break;
                }
            }

        } while (true);
    }

    static void CustomizeSymbols()
    {
        Console.Write("Введите символ для игрока X (по умолчанию X): ");
        string input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            symbolX = input[0];
        }

        Console.Write("Введите символ для игрока O (по умолчанию O): ");
        input = Console.ReadLine();
        if (!string.IsNullOrEmpty(input))
        {
            symbolO = input[0];
        }

        // Обновление доски с новыми символами
        for (int i = 0; i < 9; i++)
        {
            if (Board[i] == 'X' || Board[i] == 'O')
            {
                // Оставляем старые символы, если они уже были на доске
            }
            else
            {
                Board[i] = (char)('1' + i);
            }
        }
    }

    static void DrawBoard()
    {
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {Board[0]}  |  {Board[1]}  |  {Board[2]}  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {Board[3]}  |  {Board[4]}  |  {Board[5]}  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {Board[6]}  |  {Board[7]}  |  {Board[8]}  ");
        Console.WriteLine("     |     |     ");
    }

    static int CheckWin()
    {
        // Проверка победы
        if (Board[0] == Board[1] && Board[1] == Board[2])
            return 1;
        else if (Board[3] == Board[4] && Board[4] == Board[5])
            return 1;
        else if (Board[6] == Board[7] && Board[7] == Board[8])
            return 1;
        else if (Board[0] == Board[3] && Board[3] == Board[6])
            return 1;
        else if (Board[1] == Board[4] && Board[4] == Board[7])
            return 1;
        else if (Board[2] == Board[5] && Board[5] == Board[8])
            return 1;
        else if (Board[0] == Board[4] && Board[4] == Board[8])
            return 1;
        else if (Board[2] == Board[4] && Board[4] == Board[6])
            return 1;
        // Проверка ничьей
        else if (Board[0] != '1' && Board[1] != '2' && Board[2] != '3' &&
                 Board[3] != '4' && Board[4] != '5' && Board[5] != '6' &&
                 Board[6] != '7' && Board[7] != '8' && Board[8] != '9')
            return -1;
        else
            return 0;
    }

    static void ResetBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            Board[i] = (char)('1' + i);
        }
        player = 1;
        flag = 0;
    }
}

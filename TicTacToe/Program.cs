// Автор: Боровинская Ксения Владимировна 
// Группа: ИСП(9)-23-1»

using System;

class Program
{
    static char[] board = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];
    static int player = 1;
    static int choice;
    static int flag = 0;

    public static char[] Board { get => board; set => board = value; }

    static void Main(string[] args)
    {
        ArgumentNullException.ThrowIfNull(args);
        do
        {
            Console.Clear();
            Console.WriteLine("Крестики-нолики (Версия 1)");
            Console.WriteLine("Игрок 1: X | Игрок 2: O\n");

            DrawBoard();

            if (player % 2 == 0)
            {
                Console.WriteLine("\nХод игрока 2 (O)");
            }
            else
            {
                Console.WriteLine("\nХод игрока 1 (X)");
            }

            Console.Write("Введите номер клетки: ");
            choice = int.Parse(Console.ReadLine()) - 1;

            if (board[choice] != 'X' && board[choice] != 'O')
            {
                if (player % 2 == 0)
                {
                    board[choice] = 'O';
                    player++;
                }
                else
                {
                    board[choice] = 'X';
                    player++;
                }
            }
            else
            {
                Console.WriteLine("Эта клетка уже занята!");
                Console.WriteLine("Нажмите Enter, чтобы продолжить...");
                Console.ReadLine();
            }

            flag = CheckWin();

        } while (flag != 1 && flag != -1);

        Console.Clear();
        DrawBoard();

        if (flag == 1)
        {
            Console.WriteLine($"\nИгрок {(player % 2) + 1} победил!");
        }
        else
        {
            Console.WriteLine("\nНичья!");
        }

        Console.ReadLine();
    }

    static void DrawBoard()
    {
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]}  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]}  ");
        Console.WriteLine("_____|_____|_____");
        Console.WriteLine("     |     |     ");
        Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]}  ");
        Console.WriteLine("     |     |     ");
    }

    static int CheckWin()
    {
        // Проверка победы
        if (board[0] == board[1] && board[1] == board[2])
            return 1;
        else if (board[3] == board[4] && board[4] == board[5])
            return 1;
        else if (board[6] == board[7] && board[7] == board[8])
            return 1;
        else if (board[0] == board[3] && board[3] == board[6])
            return 1;
        else if (board[1] == board[4] && board[4] == board[7])
            return 1;
        else if (board[2] == board[5] && board[5] == board[8])
            return 1;
        else if (board[0] == board[4] && board[4] == board[8])
            return 1;
        else if (board[2] == board[4] && board[4] == board[6])
            return 1;
        // Проверка ничьей
        else if (board[0] != '1' && board[1] != '2' && board[2] != '3' &&
                 board[3] != '4' && board[4] != '5' && board[5] != '6' &&
                 board[6] != '7' && board[7] != '8' && board[8] != '9')
            return -1;
        else
            return 0;
    }
}
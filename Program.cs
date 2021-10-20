using System;
using System.Linq;

namespace TicTacToe
{
    
    class Program
        {

        const char empty = '.';
        const char circle = 'o';
        const char cross = 'x';

        static char[,] gameTable = new char[3,3];

        const int stateIdle = 0;
        const int turnC = 1; // player 1
        const int turnX = 2; // player 2
        const int stateWin = 3;  // win
        const int stateDraw = 4; // draw

        const bool clearConsole = true;

        static int state = stateIdle;
        static void DrawTable()
        {
            Console.WriteLine("\nMade by Giovanni Monti \n(2021) \nGiovanni Monti#5749\n\n");

            Console.WriteLine("\t\t0\t1\t2");
            Console.WriteLine("\t\t--\t--\t--\n");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i}\t|\t");
                for (int k = 0; k < 3; k++)
                {

                    Console.Write($"{ gameTable[i, k] }\t");
                }
                Console.WriteLine();
            }
        }

        static bool DrawCheck()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {

                    if (gameTable[i,k] == empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        static bool WinCheck()
        {

            if (gameTable[0,0] == gameTable[0,1] && gameTable[0, 1] == gameTable[0,2] && gameTable[0, 2] != empty)
            {
                return true;
            }
            if (gameTable[1,0] == gameTable[1,1] && gameTable[1, 1] == gameTable[1,2] && gameTable[1, 2] != empty)
            {
                return true;
            }
            if (gameTable[2,0] == gameTable[2,1] && gameTable[2, 1] == gameTable[2,2] && gameTable[2, 2] != empty)
            {
                return true;
            }
            if (gameTable[0,0] == gameTable[1,0] && gameTable[1, 0] == gameTable[2,0] && gameTable[2, 0] != empty)
            {
                return true;
            }
            if (gameTable[0,1] == gameTable[1,1] && gameTable[1, 1] == gameTable[2,1] && gameTable[2, 1] != empty)
            {
                return true;
            }
            if (gameTable[0,2] == gameTable[1,2] && gameTable[1, 2] == gameTable[2,2] && gameTable[2, 2] != empty)
            {
                return true;
            }
            if (gameTable[0,0] == gameTable[1,1] && gameTable[1, 1] == gameTable[2,2] && gameTable[2, 2] != empty)
            {
                return true;
            }
            if (gameTable[0,2] == gameTable[1,1] && gameTable[1, 1] == gameTable[2,0] && gameTable[2, 0] != empty)
            {
                return true;
            }
            return false;
            
        }

        static void TurnCircle() 
        {
            state = turnC;
            int posx, posy; // inverted
            Console.WriteLine("\n Player 1 : Insert Coordinate you wish to select (line) : ");
            posx = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n Player 1 : Insert Coordinate you wish to select (column) : ");
            posy = Convert.ToInt32(Console.ReadLine());

            if (posx < 3 && posy < 3 && gameTable[posx, posy] == empty)
            {
                gameTable[posx, posy] = circle;
            }
            if (WinCheck())
            {
                state = stateWin;
                Console.WriteLine(state);
            }
            if (DrawCheck())
            {
                state = stateDraw;
            }
        }

        static void TurnX()
        {
            state = turnX;
            int posx, posy; // inverititi
            Console.WriteLine("\n Player 2 : Insert Coordinate you wish to select (y) : ");
            posx = Convert.ToInt32( Console.ReadLine() );
            Console.WriteLine("\n Player 2 : Insert Coordinate you wish to select (x) : ");
            posy = Convert.ToInt32(Console.ReadLine());

            if (posx < 3 && posy < 3 && gameTable[posx,posy] == empty)
            {
                gameTable[posx,posy] = cross;
            }
            if (WinCheck())
            {
                state = stateWin;
            }
            if (DrawCheck())
            {
                state = stateDraw;
            }
        }

        static void Game()
        {

            while (state != stateWin)
            {

                if (clearConsole)
                {
                    Console.Clear();
                }

                DrawTable();
 
                if (state == stateIdle)
                {
                    TurnCircle();
                }
                else if (state == turnX)
                {
                    TurnCircle();
                }
                else if (state == turnC)
                {
                    TurnX();
                }
                else if (state == stateWin)
                {
                    Console.WriteLine( $"\n\nPlayer {state} has won!");
                }
                else if (state == stateDraw)
                {
                    Console.WriteLine("\n\nIt's a draw.");
                }
            }

        }

        static void Main(string[] args)
            {
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {

                    gameTable[i, k] = empty;
                }
            }

            Game();
        }

    }
}






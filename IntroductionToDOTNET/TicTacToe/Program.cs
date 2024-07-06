using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
	class TicTacToeBots
	{
		const int FIELD_SIZE = 3;
		char[,] board = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
		Random rand;

		char player1sym;
		char player2sym;


        public TicTacToeBots()
        {
            rand = new Random();

			player1sym = rand.Next(0, 2) == 0 ? 'O' : 'X';
			player2sym = player1sym == 'O' ? 'X' : 'O';
        }

		public void Play()
		{
			try
			{
				Thread.Sleep(500);
				Turn(player1sym);
				Console.Clear();
				DrawBoard();
				if (!IsWin(player1sym))
				{
					Thread.Sleep(500);
					Turn(player2sym);
					Console.Clear();
					DrawBoard();
					if (!IsWin(player2sym))
					{
						Play();
					}
					else { Console.WriteLine($"Player 2 ({player2sym}) won"); };
				}
				else { Console.WriteLine($"Player 1 ({player1sym}) won"); };
			}
			catch (BoardFullException) { Console.WriteLine("Draw"); }
		}

		void DrawBoard()
		{
			for (int i = 0; i < FIELD_SIZE; i++)
			{
				for (int j = 0; j < FIELD_SIZE; j++)
				{
					Console.Write($" {board[i, j]} ");
				}
				Console.WriteLine();
			}
		}

        void FillField(int row, int col, char sym)
		{
			if (!board.Cast<char>().Any(item => item == ' '))
			{
				throw new BoardFullException("Board is full, game over");
			}
			if (board[row, col] != ' ')
			{
				throw new FieldTakenException("Field already taken");
			}
			board[row, col] = sym;
		}

		void Turn(char sym)
		{
			int row, col;
			row = rand.Next(FIELD_SIZE);
			col = rand.Next(FIELD_SIZE);

			try { FillField(row, col, sym); }
			catch (BoardFullException) { throw; }
			catch (FieldTakenException) { Turn(sym); }
		}

		bool IsWin(char sym)
		{
			// TODO this might be optimised
			return board[0, 0] == sym && board[0, 0] == board[0, 1] && board[0, 0] == board[0, 2] ||
				board[1, 0] == sym && board[1, 0] == board[1, 1] && board[1, 0] == board[1, 2] ||
				board[2, 0] == sym && board[2, 0] == board[2, 1] && board[2, 0] == board[2, 2] ||
				board[0, 0] == sym && board[0, 0] == board[1, 0] && board[0, 0] == board[2, 0] ||
				board[0, 1] == sym && board[0, 1] == board[1, 1] && board[0, 1] == board[2, 1] ||
				board[0, 2] == sym && board[0, 2] == board[1, 2] && board[0, 2] == board[2, 2] ||
				board[0, 0] == sym && board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] ||
				board[0, 2] == sym && board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0];
		}
	}

	class BoardFullException : Exception
	{
		public BoardFullException() { }

		public BoardFullException(string message) : base(message) { }

		public BoardFullException(string message, Exception inner) : base(message, inner) { }
	}

	class FieldTakenException : Exception
	{
		public FieldTakenException() { }

		public FieldTakenException(string message) : base(message) { }

		public FieldTakenException(string message, Exception inner) : base(message, inner) { }
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WindowHeight = 10;
			Console.WindowWidth = 20;
			TicTacToeBots game = new TicTacToeBots();

			game.Play();
		}
	}
}

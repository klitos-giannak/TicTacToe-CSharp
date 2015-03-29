/*
 * Created by SharpDevelop.
 * User: klitos
 * Date: 3/29/2015
 * Time: 9:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe_CSharp
{
	/// <summary>
	/// Description of GameBoardView.
	/// </summary>
	public class GameBoardView: Control
	{
		private int cellWidth;
		private int cellHeight;
		
		private GameData gameData;
		
		public GameBoardView()
		{
			gameData = new GameData();
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			
			Pen pen = new Pen(ForeColor);
			
			e.Graphics.DrawLine(pen, cellWidth, 0, cellWidth, Size.Height);
			e.Graphics.DrawLine(pen, cellWidth * 2, 0, cellWidth * 2, Size.Height);
			e.Graphics.DrawLine(pen, 0, cellHeight, Size.Width, cellHeight);
			e.Graphics.DrawLine(pen, 0, cellHeight * 2, Size.Width, cellHeight * 2);
			
			for(int i = 0 ; i < 3 ; i++)
			{
				for(int j = 0 ; j < 3 ; j++)
				{
					if(gameData[i, j] == GameData.CellState.X)
						drawX(pen, e.Graphics, i, j);
					else if(gameData[i, j] == GameData.CellState.O)
						drawO(pen, e.Graphics, i, j);
				}
			}
		}
		
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			
			cellWidth = Size.Width / 3;
			cellHeight = Size.Height / 3;
			
			Invalidate();
		}
		
		/// <summary>
		///  The drawX method draws an X in the celldefined by x kai y 
		/// </summary>
		/// <param name="pen">A Pen object to draw the X with</param>
		/// <param name="g">A Graphics object to use for calling the DrawLine method</param>
		/// <param name="x">The x to define the cell in grid coordinates(0 to 2)</param>
		/// <param name="y">The y to define the cell in grid coordinates (0 to 2)</param>
		private void drawX(Pen pen, Graphics g, int x, int y)
		{
			int x1 = x*cellWidth;
			int y1 = y*cellHeight;
			int x2 = x*cellWidth + cellWidth;
			int y2 = y*cellHeight + cellHeight;
			g.DrawLine(pen, x1, y1, x2, y2);
			g.DrawLine(pen, x1, y2, x2, y1);
		}
		
		/// <summary>
		///  The drawO method draws a O in the celldefined by x kai y 
		/// </summary>
		/// <param name="pen">A Pen object to draw the O with</param>
		/// <param name="g">A Graphics object to use for calling the DrawEllipse method</param>
		/// <param name="x">The x to define the cell in grid coordinates(0 to 2)</param>
		/// <param name="y">The y to define the cell in grid coordinates (0 to 2)</param>
		private void drawO(Pen pen, Graphics g, int x, int y)
		{
			int x1 = x*cellWidth;
			int y1 = y*cellHeight;
			int w1 = cellWidth;
			int h1 = cellHeight;
			g.DrawEllipse(pen, x1, y1, w1, h1);
		}
		
		/// <summary>
		/// Handles click actions on a certain Point. First it locates the cell in which
		/// the click happened and then calls nextMove with the (translated) grid coordinates
		/// for the specific cell
		/// </summary>
		/// <param name="click">The window coordinates where the click happened</param>
		public void onClick(Point click)
		{			
			int x = -1;
			int y = -1;
			if(click.X < cellWidth)
				x = 0;
			else if(click.X < 2*cellWidth)
				x = 1;
			else
				x = 2;
			
			if(click.Y < cellHeight)
				y = 0;
			else if(click.Y < 2*cellHeight)
				y = 1;
			else
				y = 2;
			        
			nextMove(x, y);
			Invalidate();
			checkWin();
		}
		
		/// <summary>
		/// Handles the next move on the cell specified by x and y
		/// and sets the data to the gameData object
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		private void nextMove(int x, int y)
		{
			if(gameData[x,y] == GameData.CellState.EMPTY)
			{
				if(gameData.XTurn)
					gameData[x,y] = GameData.CellState.X;
				else
					gameData[x,y] = GameData.CellState.O;
			
				gameData.changeTurn();
			}
		}
		
		/// <summary>
		/// Checks if the grid is full and calls showTieMessage()
		/// </summary>
		private void checkGameOver()
		{
			bool gameOver = true;
			for(int i = 0 ; i<gameData.Width ; i++)
			{
				for(int j = 0 ; j<gameData.Height ; j++)
				{
					if(gameData[i,j] == GameData.CellState.EMPTY)
					{
						gameOver = false;
						break;
					}
				}
			}
			
			if(gameOver)
				showTieMessage();
				
		}
		
		private void checkWin(){
			GameData.CellState winner = checkWinHorizontal();
			if(winner == GameData.CellState.EMPTY)
				winner = checkWinVertical();
			if(winner == GameData.CellState.EMPTY)
				winner = checkWinDiagonally();
			
			//if a winner is found then show the win message
			if(winner != GameData.CellState.EMPTY)
			{
				showWinMessage(winner);
			}
			else
				checkGameOver();
		}
		
		/// <summary>
		/// Checks for a winner horizontally
		/// </summary>
		/// <returns>a CellState containing the found winner or empty if a winner was not found</returns>
		private GameData.CellState checkWinHorizontal()
		{
			for(int i = 0 ; i<gameData.Height ; i++)
			{
				if( gameData[0,i] != GameData.CellState.EMPTY && 
				   gameData[0,i] == gameData[1,i] && gameData[1,i] == gameData[2,i] )
					return gameData[0,i];
			}
			return GameData.CellState.EMPTY;
		}
		
		/// <summary>
		/// Checks for a winner vertically
		/// </summary>
		/// <returns>a CellState containing the found winner or empty if a winner was not found</returns>
		private GameData.CellState checkWinVertical()
		{
			for(int i = 0 ; i<gameData.Width ; i++)
			{
				if( gameData[i,0] != GameData.CellState.EMPTY &&
				   gameData[i,0] == gameData[i,1] && gameData[i,1] == gameData[i,2] )
					return gameData[i,0];
			}
			return GameData.CellState.EMPTY;
		}
		
		/// <summary>
		/// Checks for a winner diagonally
		/// </summary>
		/// <returns>a CellState containing the found winner or empty if a winner was not found</returns>
		private GameData.CellState checkWinDiagonally()
		{
			if( gameData[0,0] != GameData.CellState.EMPTY &&
			   gameData[0,0] == gameData[1,1] && gameData[1,1] == gameData[2,2] )
				return gameData[0,0];
			if( gameData[2,0] != GameData.CellState.EMPTY &&
			   gameData[2,0] == gameData[1,1] && gameData[1,1] == gameData[0,2] )
				return gameData[2,0];
			
			return GameData.CellState.EMPTY;
		}
		
		private void showWinMessage(GameData.CellState winner)
		{
			MessageBox.Show("Player " + winner + " wins");
		}
		
		private void showTieMessage()
		{
			MessageBox.Show("The game is a tie.\nNobody Wins.");
		}
	}
}

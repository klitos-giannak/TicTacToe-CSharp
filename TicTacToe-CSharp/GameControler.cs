/*
 * Created by SharpDevelop.
 * User: klitos
 * Date: 3/29/2015
 * Time: 11:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe_CSharp
{
	/// <summary>
	/// Description of GameControler.
	/// </summary>
	public class GameControler
	{
		private GameBoardView boardView;
		private GameData gameData;
		private bool gameLocked;
		
		public GameControler(GameBoardView boardView, GameData gameData)
		{
			this.boardView = boardView;
			this.gameData = gameData;
			
			restartGame();
		}
		
				
		/// <summary>
		/// Handles click actions on a certain Point. First it locates the cell in which
		/// the click happened and then calls nextMove with the (translated) grid coordinates
		/// for the specific cell
		/// </summary>
		/// <param name="click">The window coordinates where the click happened</param>
		public void onClick(Point click)
		{
			if(gameLocked)
				return;
			
			int x = boardView.convertWindowToGridXCoordinate(click.X);
			int y = boardView.convertWindowToGridYCoordinate(click.Y);
			        
			nextMove(x, y);
			boardView.Invalidate();
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
			{
				showTieMessage();
				gameLocked = true;
			}
				
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
				gameLocked = true;
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
		
		public void restartGame()
		{
			gameData.reset();
			gameLocked = false;
			boardView.Invalidate();
		}
	}
}

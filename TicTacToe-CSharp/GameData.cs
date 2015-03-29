/*
 * Created by SharpDevelop.
 * User: klitos
 * Date: 3/29/2015
 * Time: 9:44 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TicTacToe_CSharp
{
	/// <summary>
	/// Description of GameData.
	/// </summary>
	public class GameData
	{
		//an array to hold the states of all cells
		private CellState[,] cellData;
		
		//a bool to hold the player's turn
		private bool xTurn = true;
		
		public GameData()
		{
			cellData = new CellState[3,3];
			reset();
		}
		
		public void reset(){
			for(int i = 0 ; i < Width ; i++)
			{
				for(int j = 0 ; j < Height ; j++)
				{
					cellData[i,j] = CellState.EMPTY;
				}
			}
			xTurn = true;
		}
					
		public void changeTurn()
		{
			if(xTurn)
				xTurn = false;
			else
				xTurn = true;
		}
		
		#region Properties / Indexers
		public int Width
		{
			get { return cellData.GetLength(0); }
		}
		
		public int Height
		{
			get { return cellData.GetLength(1); }
		}
		
		public CellState this[int cx, int cy]
		{
			get { return cellData[cx, cy]; }
			set { cellData[cx, cy] = value; }
		}
		
		public bool XTurn
		{
			get{ return xTurn; }
		}
		#endregion

		
		/// <summary>
		/// An enumeration to give the three possible states of each cell on our board
		/// </summary>
		public enum CellState
		{
			X, O, EMPTY
		}
	}
}

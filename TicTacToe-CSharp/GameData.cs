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
		}
		
		
		#region Properties 
		
		public bool XTurn
		{
			get{ return xTurn; }
			set{ xTurn = value; }
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

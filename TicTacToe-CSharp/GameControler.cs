/*
 * Created by SharpDevelop.
 * User: klitos
 * Date: 3/29/2015
 * Time: 11:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TicTacToe_CSharp
{
	/// <summary>
	/// Description of GameControler.
	/// </summary>
	public class GameControler
	{
		private GameBoardView boardView;
		private GameData gameData;
		
		public GameControler(GameBoardView boardView, GameData gameData)
		{
			this.boardView = boardView;
			this.gameData = gameData;
		}
		
		
	}
}

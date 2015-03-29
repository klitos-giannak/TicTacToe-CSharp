/*
 * Created by SharpDevelop.
 * User: klitos
 * Date: 3/29/2015
 * Time: 8:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToe_CSharp
{
	/// <summary>
	/// Description of GameForm.
	/// </summary>
	public partial class GameForm : Form
	{
		private GameControler gameController;
		
		public GameForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			GameData gameData = new GameData();
			
			//the boardView object is defined and instantiated in GameForm.Designer.cs by visual tools
			this.boardView.GData = gameData;
			
			gameController = new GameControler(this.boardView, gameData);
		}
		
		void BoardViewClick(object sender, EventArgs e)
		{
			if(e is MouseEventArgs)
			{
				MouseEventArgs me = (MouseEventArgs) e;
				this.boardView.onClick(new Point(me.X, me.Y));
			}
		}
		
		void RestartButtonClick(object sender, EventArgs e)
		{
			this.boardView.restartGame();
		}
	}
}

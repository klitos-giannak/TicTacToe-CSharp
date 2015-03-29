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
		
		public GameBoardView()
		{
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			
			Pen pen = new Pen(ForeColor);
			
			e.Graphics.DrawLine(pen, cellWidth, 0, cellWidth, Size.Height);
			e.Graphics.DrawLine(pen, cellWidth * 2, 0, cellWidth * 2, Size.Height);
			e.Graphics.DrawLine(pen, 0, cellHeight, Size.Width, cellHeight);
			e.Graphics.DrawLine(pen, 0, cellHeight * 2, Size.Width, cellHeight * 2);
		}
		
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			
			cellWidth = Size.Width / 3;
			cellHeight = Size.Height / 3;
			
			Invalidate();
		}
	}
}

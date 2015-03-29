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
			
			for(int i = 0 ; i < 3 ; i++)
			{
				for(int j = 0 ; j < 3 ; j++)
				{
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
	}
}

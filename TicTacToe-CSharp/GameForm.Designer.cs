/*
 * Created by SharpDevelop.
 * User: klitos
 * Date: 3/29/2015
 * Time: 8:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace TicTacToe_CSharp
{
	partial class GameForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private TicTacToe_CSharp.GameBoardView boardView;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.boardView = new TicTacToe_CSharp.GameBoardView();
			this.SuspendLayout();
			// 
			// boardView
			// 
			this.boardView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.boardView.Location = new System.Drawing.Point(0, 0);
			this.boardView.Name = "boardView";
			this.boardView.Size = new System.Drawing.Size(284, 261);
			this.boardView.TabIndex = 0;
			this.boardView.Text = "boardView";
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.boardView);
			this.Name = "GameForm";
			this.Text = "TicTacToe-CSharp";
			this.ResumeLayout(false);

		}
	}
}

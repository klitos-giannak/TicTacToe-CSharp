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
		private System.Windows.Forms.Button restartButton;
		
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
			this.restartButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// boardView
			// 
			this.boardView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.boardView.Location = new System.Drawing.Point(0, 0);
			this.boardView.Name = "boardView";
			this.boardView.Size = new System.Drawing.Size(284, 261);
			this.boardView.TabIndex = 0;
			this.boardView.Text = "boardView";
			this.boardView.Click += new System.EventHandler(this.BoardViewClick);
			// 
			// restartButton
			// 
			this.restartButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.restartButton.Location = new System.Drawing.Point(107, 268);
			this.restartButton.Name = "restartButton";
			this.restartButton.Size = new System.Drawing.Size(70, 24);
			this.restartButton.TabIndex = 1;
			this.restartButton.Text = "Restart";
			this.restartButton.UseVisualStyleBackColor = true;
			this.restartButton.Click += new System.EventHandler(this.RestartButtonClick);
			// 
			// GameForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 301);
			this.Controls.Add(this.restartButton);
			this.Controls.Add(this.boardView);
			this.MinimumSize = new System.Drawing.Size(150, 170);
			this.Name = "GameForm";
			this.Text = "TicTacToe-CSharp";
			this.ResumeLayout(false);

		}
	}
}

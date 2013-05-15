namespace kibicom.wd_1c_trans_gdi
{
	partial class confirm_calc
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbl_success = new System.Windows.Forms.Label();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.btn_confirm_calc = new System.Windows.Forms.Button();
			this.lbl_counter = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbl_success
			// 
			this.lbl_success.AutoSize = true;
			this.lbl_success.BackColor = System.Drawing.Color.Transparent;
			this.lbl_success.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_success.ForeColor = System.Drawing.Color.Brown;
			this.lbl_success.Location = new System.Drawing.Point(287, 11);
			this.lbl_success.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_success.Name = "lbl_success";
			this.lbl_success.Size = new System.Drawing.Size(102, 31);
			this.lbl_success.TabIndex = 8;
			this.lbl_success.Text = "Успех!";
			this.lbl_success.Visible = false;
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(12, 13);
			this.progress.Margin = new System.Windows.Forms.Padding(4);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(267, 29);
			this.progress.Step = 1;
			this.progress.TabIndex = 7;
			// 
			// btn_confirm_calc
			// 
			this.btn_confirm_calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_confirm_calc.ForeColor = System.Drawing.Color.ForestGreen;
			this.btn_confirm_calc.Location = new System.Drawing.Point(13, 46);
			this.btn_confirm_calc.Margin = new System.Windows.Forms.Padding(4);
			this.btn_confirm_calc.Name = "btn_confirm_calc";
			this.btn_confirm_calc.Size = new System.Drawing.Size(376, 90);
			this.btn_confirm_calc.TabIndex = 9;
			this.btn_confirm_calc.Text = "Подтвердить расход";
			this.btn_confirm_calc.UseVisualStyleBackColor = true;
			this.btn_confirm_calc.Click += new System.EventHandler(this.btn_confirm_calc_2_1c_Click);
			// 
			// lbl_counter
			// 
			this.lbl_counter.AutoSize = true;
			this.lbl_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_counter.Location = new System.Drawing.Point(288, 16);
			this.lbl_counter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_counter.Name = "lbl_counter";
			this.lbl_counter.Size = new System.Drawing.Size(0, 25);
			this.lbl_counter.TabIndex = 10;
			// 
			// confirm_calc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 149);
			this.Controls.Add(this.lbl_counter);
			this.Controls.Add(this.btn_confirm_calc);
			this.Controls.Add(this.lbl_success);
			this.Controls.Add(this.progress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "confirm_calc";
			this.Text = "Подтверждение расхода";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_success;
		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Button btn_confirm_calc;
		private System.Windows.Forms.Label lbl_counter;
	}
}
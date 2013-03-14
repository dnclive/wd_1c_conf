namespace kibicom.wd_1c_trans_gdi
{
	partial class frm_main
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
			this.btn_cancel_calc_1c = new System.Windows.Forms.Button();
			this.btn_calc_2_1c = new System.Windows.Forms.Button();
			this.btn_close = new System.Windows.Forms.Button();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
			this.lineShape4 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
			this.lbl_counter = new System.Windows.Forms.Label();
			this.lbl_success = new System.Windows.Forms.Label();
			this.btn_Calc = new System.Windows.Forms.Button();
			this.btn_good = new System.Windows.Forms.Button();
			this.btn_export_good = new System.Windows.Forms.Button();
			this.btn_get_qu = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btn_cancel_calc_1c
			// 
			this.btn_cancel_calc_1c.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_cancel_calc_1c.ForeColor = System.Drawing.Color.Red;
			this.btn_cancel_calc_1c.Location = new System.Drawing.Point(12, 201);
			this.btn_cancel_calc_1c.Name = "btn_cancel_calc_1c";
			this.btn_cancel_calc_1c.Size = new System.Drawing.Size(407, 80);
			this.btn_cancel_calc_1c.TabIndex = 2;
			this.btn_cancel_calc_1c.Text = "Отменить расход в 1С";
			this.btn_cancel_calc_1c.UseVisualStyleBackColor = true;
			this.btn_cancel_calc_1c.Click += new System.EventHandler(this.btn_calc_2_1c_Click);
			// 
			// btn_calc_2_1c
			// 
			this.btn_calc_2_1c.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_calc_2_1c.ForeColor = System.Drawing.Color.ForestGreen;
			this.btn_calc_2_1c.Location = new System.Drawing.Point(12, 115);
			this.btn_calc_2_1c.Name = "btn_calc_2_1c";
			this.btn_calc_2_1c.Size = new System.Drawing.Size(407, 80);
			this.btn_calc_2_1c.TabIndex = 1;
			this.btn_calc_2_1c.Text = "Передать расход в 1С";
			this.btn_calc_2_1c.UseVisualStyleBackColor = true;
			this.btn_calc_2_1c.Click += new System.EventHandler(this.btn_calc_2_1c_Click);
			// 
			// btn_close
			// 
			this.btn_close.BackColor = System.Drawing.Color.Red;
			this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_close.ForeColor = System.Drawing.Color.White;
			this.btn_close.Location = new System.Drawing.Point(369, 12);
			this.btn_close.Name = "btn_close";
			this.btn_close.Size = new System.Drawing.Size(50, 40);
			this.btn_close.TabIndex = 0;
			this.btn_close.Text = "X";
			this.btn_close.UseVisualStyleBackColor = false;
			this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(12, 86);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(321, 23);
			this.progress.Step = 1;
			this.progress.TabIndex = 3;
			// 
			// shapeContainer1
			// 
			this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
			this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
			this.shapeContainer1.Name = "shapeContainer1";
			this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape4,
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
			this.shapeContainer1.Size = new System.Drawing.Size(431, 296);
			this.shapeContainer1.TabIndex = 4;
			this.shapeContainer1.TabStop = false;
			// 
			// lineShape4
			// 
			this.lineShape4.Name = "lineShape4";
			this.lineShape4.X1 = 0;
			this.lineShape4.X2 = 0;
			this.lineShape4.Y1 = 0;
			this.lineShape4.Y2 = 295;
			// 
			// lineShape3
			// 
			this.lineShape3.Name = "lineShape3";
			this.lineShape3.X1 = 0;
			this.lineShape3.X2 = 430;
			this.lineShape3.Y1 = 295;
			this.lineShape3.Y2 = 295;
			// 
			// lineShape2
			// 
			this.lineShape2.Name = "lineShape2";
			this.lineShape2.X1 = 430;
			this.lineShape2.X2 = 430;
			this.lineShape2.Y1 = 0;
			this.lineShape2.Y2 = 295;
			// 
			// lineShape1
			// 
			this.lineShape1.Name = "lineShape1";
			this.lineShape1.X1 = 0;
			this.lineShape1.X2 = 430;
			this.lineShape1.Y1 = 0;
			this.lineShape1.Y2 = 0;
			// 
			// lbl_counter
			// 
			this.lbl_counter.AutoSize = true;
			this.lbl_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_counter.Location = new System.Drawing.Point(12, 63);
			this.lbl_counter.Name = "lbl_counter";
			this.lbl_counter.Size = new System.Drawing.Size(0, 20);
			this.lbl_counter.TabIndex = 5;
			// 
			// lbl_success
			// 
			this.lbl_success.AutoSize = true;
			this.lbl_success.BackColor = System.Drawing.Color.Transparent;
			this.lbl_success.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_success.ForeColor = System.Drawing.Color.Brown;
			this.lbl_success.Location = new System.Drawing.Point(339, 84);
			this.lbl_success.Name = "lbl_success";
			this.lbl_success.Size = new System.Drawing.Size(83, 25);
			this.lbl_success.TabIndex = 6;
			this.lbl_success.Text = "Успех!";
			this.lbl_success.Visible = false;
			// 
			// btn_Calc
			// 
			this.btn_Calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_Calc.Location = new System.Drawing.Point(12, 12);
			this.btn_Calc.Name = "btn_Calc";
			this.btn_Calc.Size = new System.Drawing.Size(102, 39);
			this.btn_Calc.TabIndex = 8;
			this.btn_Calc.Text = "Расход";
			this.btn_Calc.UseVisualStyleBackColor = true;
			this.btn_Calc.Click += new System.EventHandler(this.btn_Calc_Click);
			// 
			// btn_good
			// 
			this.btn_good.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_good.Location = new System.Drawing.Point(120, 12);
			this.btn_good.Name = "btn_good";
			this.btn_good.Size = new System.Drawing.Size(102, 39);
			this.btn_good.TabIndex = 8;
			this.btn_good.Text = "Остатки";
			this.btn_good.UseVisualStyleBackColor = true;
			this.btn_good.Click += new System.EventHandler(this.btn_good_Click);
			// 
			// btn_export_good
			// 
			this.btn_export_good.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_export_good.ForeColor = System.Drawing.Color.ForestGreen;
			this.btn_export_good.Location = new System.Drawing.Point(12, 115);
			this.btn_export_good.Name = "btn_export_good";
			this.btn_export_good.Size = new System.Drawing.Size(407, 80);
			this.btn_export_good.TabIndex = 1;
			this.btn_export_good.Text = "Выгрузить материалы";
			this.btn_export_good.UseVisualStyleBackColor = true;
			this.btn_export_good.Visible = false;
			this.btn_export_good.Click += new System.EventHandler(this.btn_export_good_Click);
			// 
			// btn_get_qu
			// 
			this.btn_get_qu.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_get_qu.ForeColor = System.Drawing.Color.Red;
			this.btn_get_qu.Location = new System.Drawing.Point(12, 201);
			this.btn_get_qu.Name = "btn_get_qu";
			this.btn_get_qu.Size = new System.Drawing.Size(407, 80);
			this.btn_get_qu.TabIndex = 2;
			this.btn_get_qu.Text = "Получить остатки";
			this.btn_get_qu.UseVisualStyleBackColor = true;
			this.btn_get_qu.Visible = false;
			// 
			// frm_main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(431, 296);
			this.Controls.Add(this.btn_get_qu);
			this.Controls.Add(this.btn_export_good);
			this.Controls.Add(this.btn_good);
			this.Controls.Add(this.btn_Calc);
			this.Controls.Add(this.lbl_success);
			this.Controls.Add(this.lbl_counter);
			this.Controls.Add(this.btn_close);
			this.Controls.Add(this.progress);
			this.Controls.Add(this.btn_cancel_calc_1c);
			this.Controls.Add(this.btn_calc_2_1c);
			this.Controls.Add(this.shapeContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "frm_main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Выгрузка в 1С";
			this.TopMost = true;
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_main_MouseDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_cancel_calc_1c;
		private System.Windows.Forms.Button btn_calc_2_1c;
		private System.Windows.Forms.Button btn_close;
		private System.Windows.Forms.ProgressBar progress;
		private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
		private Microsoft.VisualBasic.PowerPacks.LineShape lineShape4;
		private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
		private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
		private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
		private System.Windows.Forms.Label lbl_counter;
		private System.Windows.Forms.Label lbl_success;
		private System.Windows.Forms.Button btn_Calc;
		private System.Windows.Forms.Button btn_good;
		private System.Windows.Forms.Button btn_export_good;
		private System.Windows.Forms.Button btn_get_qu;
	}
}


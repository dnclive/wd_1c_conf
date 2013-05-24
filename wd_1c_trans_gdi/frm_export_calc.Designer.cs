namespace kibicom.wd_1c_trans_gdi
{
	partial class frm_export_calc
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
			this.btn_export_calc = new System.Windows.Forms.Button();
			this.lbl_success = new System.Windows.Forms.Label();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.lbl_counter = new System.Windows.Forms.Label();
			this.rbtn_by_manufact = new System.Windows.Forms.RadioButton();
			this.rbtn_by_date = new System.Windows.Forms.RadioButton();
			this.dt_from = new System.Windows.Forms.DateTimePicker();
			this.dt_to = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_cancel_calc = new System.Windows.Forms.Button();
			this.lbl_manuf_name = new System.Windows.Forms.Label();
			this.btn_laminat = new System.Windows.Forms.Button();
			this.txt_order_name = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btn_export_calc
			// 
			this.btn_export_calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_export_calc.ForeColor = System.Drawing.Color.ForestGreen;
			this.btn_export_calc.Location = new System.Drawing.Point(13, 163);
			this.btn_export_calc.Margin = new System.Windows.Forms.Padding(4);
			this.btn_export_calc.Name = "btn_export_calc";
			this.btn_export_calc.Size = new System.Drawing.Size(378, 86);
			this.btn_export_calc.TabIndex = 12;
			this.btn_export_calc.Text = "Выгрузить расход";
			this.btn_export_calc.UseVisualStyleBackColor = true;
			this.btn_export_calc.Click += new System.EventHandler(this.btn_calc_2_1c_Click);
			// 
			// lbl_success
			// 
			this.lbl_success.AutoSize = true;
			this.lbl_success.BackColor = System.Drawing.Color.Transparent;
			this.lbl_success.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_success.ForeColor = System.Drawing.Color.Brown;
			this.lbl_success.Location = new System.Drawing.Point(273, 124);
			this.lbl_success.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_success.Name = "lbl_success";
			this.lbl_success.Size = new System.Drawing.Size(102, 31);
			this.lbl_success.TabIndex = 11;
			this.lbl_success.Text = "Успех!";
			this.lbl_success.Visible = false;
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(14, 126);
			this.progress.Margin = new System.Windows.Forms.Padding(4);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(251, 29);
			this.progress.Step = 1;
			this.progress.TabIndex = 10;
			// 
			// lbl_counter
			// 
			this.lbl_counter.AutoSize = true;
			this.lbl_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_counter.Location = new System.Drawing.Point(273, 130);
			this.lbl_counter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_counter.Name = "lbl_counter";
			this.lbl_counter.Size = new System.Drawing.Size(0, 25);
			this.lbl_counter.TabIndex = 13;
			// 
			// rbtn_by_manufact
			// 
			this.rbtn_by_manufact.AutoSize = true;
			this.rbtn_by_manufact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rbtn_by_manufact.Location = new System.Drawing.Point(14, 13);
			this.rbtn_by_manufact.Name = "rbtn_by_manufact";
			this.rbtn_by_manufact.Size = new System.Drawing.Size(210, 29);
			this.rbtn_by_manufact.TabIndex = 14;
			this.rbtn_by_manufact.Text = "По заданию/заказу";
			this.rbtn_by_manufact.UseVisualStyleBackColor = true;
			// 
			// rbtn_by_date
			// 
			this.rbtn_by_date.AutoSize = true;
			this.rbtn_by_date.Checked = true;
			this.rbtn_by_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rbtn_by_date.Location = new System.Drawing.Point(13, 51);
			this.rbtn_by_date.Name = "rbtn_by_date";
			this.rbtn_by_date.Size = new System.Drawing.Size(128, 29);
			this.rbtn_by_date.TabIndex = 14;
			this.rbtn_by_date.TabStop = true;
			this.rbtn_by_date.Text = "За период";
			this.rbtn_by_date.UseVisualStyleBackColor = true;
			// 
			// dt_from
			// 
			this.dt_from.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dt_from.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.dt_from.Location = new System.Drawing.Point(28, 86);
			this.dt_from.Name = "dt_from";
			this.dt_from.Size = new System.Drawing.Size(150, 22);
			this.dt_from.TabIndex = 15;
			// 
			// dt_to
			// 
			this.dt_to.Location = new System.Drawing.Point(209, 86);
			this.dt_to.Name = "dt_to";
			this.dt_to.Size = new System.Drawing.Size(150, 22);
			this.dt_to.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(184, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 25);
			this.label1.TabIndex = 16;
			this.label1.Text = "-";
			// 
			// btn_cancel_calc
			// 
			this.btn_cancel_calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_cancel_calc.ForeColor = System.Drawing.Color.Red;
			this.btn_cancel_calc.Location = new System.Drawing.Point(13, 360);
			this.btn_cancel_calc.Margin = new System.Windows.Forms.Padding(4);
			this.btn_cancel_calc.Name = "btn_cancel_calc";
			this.btn_cancel_calc.Size = new System.Drawing.Size(378, 86);
			this.btn_cancel_calc.TabIndex = 12;
			this.btn_cancel_calc.Text = "Отменить расход";
			this.btn_cancel_calc.UseVisualStyleBackColor = true;
			this.btn_cancel_calc.Click += new System.EventHandler(this.btn_calc_2_1c_Click);
			// 
			// lbl_manuf_name
			// 
			this.lbl_manuf_name.AutoSize = true;
			this.lbl_manuf_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_manuf_name.Location = new System.Drawing.Point(230, 17);
			this.lbl_manuf_name.Name = "lbl_manuf_name";
			this.lbl_manuf_name.Size = new System.Drawing.Size(0, 25);
			this.lbl_manuf_name.TabIndex = 17;
			// 
			// btn_laminat
			// 
			this.btn_laminat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.btn_laminat.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_laminat.ForeColor = System.Drawing.Color.ForestGreen;
			this.btn_laminat.Location = new System.Drawing.Point(13, 257);
			this.btn_laminat.Margin = new System.Windows.Forms.Padding(4);
			this.btn_laminat.Name = "btn_laminat";
			this.btn_laminat.Size = new System.Drawing.Size(378, 91);
			this.btn_laminat.TabIndex = 12;
			this.btn_laminat.Text = "Выгрузить Ламинацию";
			this.btn_laminat.UseVisualStyleBackColor = true;
			this.btn_laminat.Click += new System.EventHandler(this.btn_laminat_Click);
			// 
			// txt_order_name
			// 
			this.txt_order_name.Location = new System.Drawing.Point(399, 257);
			this.txt_order_name.Name = "txt_order_name";
			this.txt_order_name.Size = new System.Drawing.Size(228, 22);
			this.txt_order_name.TabIndex = 18;
			// 
			// frm_export_calc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(639, 464);
			this.Controls.Add(this.txt_order_name);
			this.Controls.Add(this.lbl_manuf_name);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dt_to);
			this.Controls.Add(this.dt_from);
			this.Controls.Add(this.rbtn_by_date);
			this.Controls.Add(this.rbtn_by_manufact);
			this.Controls.Add(this.lbl_counter);
			this.Controls.Add(this.btn_cancel_calc);
			this.Controls.Add(this.btn_laminat);
			this.Controls.Add(this.btn_export_calc);
			this.Controls.Add(this.lbl_success);
			this.Controls.Add(this.progress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frm_export_calc";
			this.Text = "Расход/Подтверждение";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_export_calc;
		private System.Windows.Forms.Label lbl_success;
		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.Label lbl_counter;
		private System.Windows.Forms.RadioButton rbtn_by_manufact;
		private System.Windows.Forms.RadioButton rbtn_by_date;
		private System.Windows.Forms.DateTimePicker dt_from;
		private System.Windows.Forms.DateTimePicker dt_to;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_cancel_calc;
		private System.Windows.Forms.Label lbl_manuf_name;
		private System.Windows.Forms.Button btn_laminat;
		private System.Windows.Forms.TextBox txt_order_name;
	}
}
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
			this.label2 = new System.Windows.Forms.Label();
			this.tab_main = new System.Windows.Forms.TabControl();
			this.tab_calc = new System.Windows.Forms.TabPage();
			this.tab_good = new System.Windows.Forms.TabPage();
			this.btn_unload_good_group = new System.Windows.Forms.Button();
			this.btn_unload_good = new System.Windows.Forms.Button();
			this.tab_lamin = new System.Windows.Forms.TabPage();
			this.btn_get_price_from_1c = new System.Windows.Forms.Button();
			this.tab_res_demand = new System.Windows.Forms.TabPage();
			this.btn_send_res_demand = new System.Windows.Forms.Button();
			this.tab_main.SuspendLayout();
			this.tab_calc.SuspendLayout();
			this.tab_good.SuspendLayout();
			this.tab_lamin.SuspendLayout();
			this.tab_res_demand.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_export_calc
			// 
			this.btn_export_calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_export_calc.ForeColor = System.Drawing.Color.ForestGreen;
			this.btn_export_calc.Location = new System.Drawing.Point(7, 113);
			this.btn_export_calc.Margin = new System.Windows.Forms.Padding(4);
			this.btn_export_calc.Name = "btn_export_calc";
			this.btn_export_calc.Size = new System.Drawing.Size(409, 86);
			this.btn_export_calc.TabIndex = 12;
			this.btn_export_calc.Text = "Выгрузить расход";
			this.btn_export_calc.UseVisualStyleBackColor = true;
			this.btn_export_calc.Click += new System.EventHandler(this.btn_calc_2_1c_Click);
			// 
			// lbl_success
			// 
			this.lbl_success.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lbl_success.AutoSize = true;
			this.lbl_success.BackColor = System.Drawing.Color.Transparent;
			this.lbl_success.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_success.ForeColor = System.Drawing.Color.Brown;
			this.lbl_success.Location = new System.Drawing.Point(333, 11);
			this.lbl_success.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_success.Name = "lbl_success";
			this.lbl_success.Size = new System.Drawing.Size(102, 31);
			this.lbl_success.TabIndex = 11;
			this.lbl_success.Text = "Успех!";
			this.lbl_success.Visible = false;
			// 
			// progress
			// 
			this.progress.Location = new System.Drawing.Point(13, 13);
			this.progress.Margin = new System.Windows.Forms.Padding(4);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(312, 29);
			this.progress.Step = 1;
			this.progress.TabIndex = 10;
			// 
			// lbl_counter
			// 
			this.lbl_counter.AutoSize = true;
			this.lbl_counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_counter.Location = new System.Drawing.Point(333, 17);
			this.lbl_counter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lbl_counter.Name = "lbl_counter";
			this.lbl_counter.Size = new System.Drawing.Size(0, 25);
			this.lbl_counter.TabIndex = 13;
			// 
			// rbtn_by_manufact
			// 
			this.rbtn_by_manufact.AutoSize = true;
			this.rbtn_by_manufact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.rbtn_by_manufact.Location = new System.Drawing.Point(6, 6);
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
			this.rbtn_by_date.Location = new System.Drawing.Point(5, 44);
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
			this.dt_from.Location = new System.Drawing.Point(20, 79);
			this.dt_from.Name = "dt_from";
			this.dt_from.Size = new System.Drawing.Size(150, 22);
			this.dt_from.TabIndex = 15;
			// 
			// dt_to
			// 
			this.dt_to.Location = new System.Drawing.Point(201, 79);
			this.dt_to.Name = "dt_to";
			this.dt_to.Size = new System.Drawing.Size(150, 27);
			this.dt_to.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(176, 76);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 25);
			this.label1.TabIndex = 16;
			this.label1.Text = "-";
			// 
			// btn_cancel_calc
			// 
			this.btn_cancel_calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_cancel_calc.ForeColor = System.Drawing.Color.Red;
			this.btn_cancel_calc.Location = new System.Drawing.Point(7, 202);
			this.btn_cancel_calc.Margin = new System.Windows.Forms.Padding(4);
			this.btn_cancel_calc.Name = "btn_cancel_calc";
			this.btn_cancel_calc.Size = new System.Drawing.Size(409, 86);
			this.btn_cancel_calc.TabIndex = 12;
			this.btn_cancel_calc.Text = "Отменить расход";
			this.btn_cancel_calc.UseVisualStyleBackColor = true;
			this.btn_cancel_calc.Click += new System.EventHandler(this.btn_calc_2_1c_Click);
			// 
			// lbl_manuf_name
			// 
			this.lbl_manuf_name.AutoSize = true;
			this.lbl_manuf_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbl_manuf_name.Location = new System.Drawing.Point(222, 10);
			this.lbl_manuf_name.Name = "lbl_manuf_name";
			this.lbl_manuf_name.Size = new System.Drawing.Size(0, 25);
			this.lbl_manuf_name.TabIndex = 17;
			// 
			// btn_laminat
			// 
			this.btn_laminat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_laminat.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_laminat.ForeColor = System.Drawing.Color.ForestGreen;
			this.btn_laminat.Location = new System.Drawing.Point(7, 55);
			this.btn_laminat.Margin = new System.Windows.Forms.Padding(4);
			this.btn_laminat.Name = "btn_laminat";
			this.btn_laminat.Size = new System.Drawing.Size(409, 92);
			this.btn_laminat.TabIndex = 12;
			this.btn_laminat.Text = "Выгрузить Ламинацию";
			this.btn_laminat.UseVisualStyleBackColor = true;
			this.btn_laminat.Click += new System.EventHandler(this.btn_laminat_Click);
			// 
			// txt_order_name
			// 
			this.txt_order_name.Location = new System.Drawing.Point(6, 26);
			this.txt_order_name.Name = "txt_order_name";
			this.txt_order_name.Size = new System.Drawing.Size(410, 27);
			this.txt_order_name.TabIndex = 18;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 3);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(267, 20);
			this.label2.TabIndex = 19;
			this.label2.Text = "Номера заказов с ламинацией";
			// 
			// tab_main
			// 
			this.tab_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tab_main.Controls.Add(this.tab_calc);
			this.tab_main.Controls.Add(this.tab_good);
			this.tab_main.Controls.Add(this.tab_lamin);
			this.tab_main.Controls.Add(this.tab_res_demand);
			this.tab_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.tab_main.Location = new System.Drawing.Point(12, 49);
			this.tab_main.Multiline = true;
			this.tab_main.Name = "tab_main";
			this.tab_main.SelectedIndex = 0;
			this.tab_main.Size = new System.Drawing.Size(431, 372);
			this.tab_main.TabIndex = 20;
			// 
			// tab_calc
			// 
			this.tab_calc.Controls.Add(this.rbtn_by_manufact);
			this.tab_calc.Controls.Add(this.btn_export_calc);
			this.tab_calc.Controls.Add(this.btn_cancel_calc);
			this.tab_calc.Controls.Add(this.lbl_manuf_name);
			this.tab_calc.Controls.Add(this.rbtn_by_date);
			this.tab_calc.Controls.Add(this.label1);
			this.tab_calc.Controls.Add(this.dt_from);
			this.tab_calc.Controls.Add(this.dt_to);
			this.tab_calc.Location = new System.Drawing.Point(4, 29);
			this.tab_calc.Name = "tab_calc";
			this.tab_calc.Padding = new System.Windows.Forms.Padding(3);
			this.tab_calc.Size = new System.Drawing.Size(423, 339);
			this.tab_calc.TabIndex = 1;
			this.tab_calc.Text = "Раcход";
			this.tab_calc.UseVisualStyleBackColor = true;
			// 
			// tab_good
			// 
			this.tab_good.Controls.Add(this.btn_get_price_from_1c);
			this.tab_good.Controls.Add(this.btn_unload_good_group);
			this.tab_good.Controls.Add(this.btn_unload_good);
			this.tab_good.Location = new System.Drawing.Point(4, 29);
			this.tab_good.Name = "tab_good";
			this.tab_good.Padding = new System.Windows.Forms.Padding(3);
			this.tab_good.Size = new System.Drawing.Size(423, 339);
			this.tab_good.TabIndex = 0;
			this.tab_good.Text = "Материалы";
			this.tab_good.UseVisualStyleBackColor = true;
			this.tab_good.Click += new System.EventHandler(this.tab_good_Click);
			// 
			// btn_unload_good_group
			// 
			this.btn_unload_good_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_unload_good_group.ForeColor = System.Drawing.Color.ForestGreen;
			this.btn_unload_good_group.Location = new System.Drawing.Point(7, 101);
			this.btn_unload_good_group.Margin = new System.Windows.Forms.Padding(4);
			this.btn_unload_good_group.Name = "btn_unload_good_group";
			this.btn_unload_good_group.Size = new System.Drawing.Size(409, 86);
			this.btn_unload_good_group.TabIndex = 13;
			this.btn_unload_good_group.Text = "Выгрузить группы материалов";
			this.btn_unload_good_group.UseVisualStyleBackColor = true;
			this.btn_unload_good_group.Click += new System.EventHandler(this.btn_unload_good_group_Click);
			// 
			// btn_unload_good
			// 
			this.btn_unload_good.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_unload_good.ForeColor = System.Drawing.Color.Crimson;
			this.btn_unload_good.Location = new System.Drawing.Point(7, 7);
			this.btn_unload_good.Margin = new System.Windows.Forms.Padding(4);
			this.btn_unload_good.Name = "btn_unload_good";
			this.btn_unload_good.Size = new System.Drawing.Size(409, 86);
			this.btn_unload_good.TabIndex = 13;
			this.btn_unload_good.Text = "Выгрузить материалы";
			this.btn_unload_good.UseVisualStyleBackColor = true;
			this.btn_unload_good.Click += new System.EventHandler(this.btn_unload_good_Click);
			// 
			// tab_lamin
			// 
			this.tab_lamin.Controls.Add(this.btn_laminat);
			this.tab_lamin.Controls.Add(this.label2);
			this.tab_lamin.Controls.Add(this.txt_order_name);
			this.tab_lamin.Location = new System.Drawing.Point(4, 29);
			this.tab_lamin.Name = "tab_lamin";
			this.tab_lamin.Padding = new System.Windows.Forms.Padding(3);
			this.tab_lamin.Size = new System.Drawing.Size(423, 339);
			this.tab_lamin.TabIndex = 2;
			this.tab_lamin.Text = "Ламинация";
			this.tab_lamin.UseVisualStyleBackColor = true;
			// 
			// btn_get_price_from_1c
			// 
			this.btn_get_price_from_1c.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_get_price_from_1c.ForeColor = System.Drawing.Color.ForestGreen;
			this.btn_get_price_from_1c.Location = new System.Drawing.Point(7, 195);
			this.btn_get_price_from_1c.Margin = new System.Windows.Forms.Padding(4);
			this.btn_get_price_from_1c.Name = "btn_get_price_from_1c";
			this.btn_get_price_from_1c.Size = new System.Drawing.Size(409, 86);
			this.btn_get_price_from_1c.TabIndex = 13;
			this.btn_get_price_from_1c.Text = "Загрузить цены из 1С";
			this.btn_get_price_from_1c.UseVisualStyleBackColor = true;
			this.btn_get_price_from_1c.Click += new System.EventHandler(this.btn_get_price_from_1c_Click);
			// 
			// tab_res_demand
			// 
			this.tab_res_demand.Controls.Add(this.btn_send_res_demand);
			this.tab_res_demand.Location = new System.Drawing.Point(4, 29);
			this.tab_res_demand.Name = "tab_res_demand";
			this.tab_res_demand.Padding = new System.Windows.Forms.Padding(3);
			this.tab_res_demand.Size = new System.Drawing.Size(423, 339);
			this.tab_res_demand.TabIndex = 3;
			this.tab_res_demand.Text = "Требование";
			this.tab_res_demand.UseVisualStyleBackColor = true;
			// 
			// btn_send_res_demand
			// 
			this.btn_send_res_demand.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btn_send_res_demand.ForeColor = System.Drawing.Color.ForestGreen;
			this.btn_send_res_demand.Location = new System.Drawing.Point(10, 7);
			this.btn_send_res_demand.Margin = new System.Windows.Forms.Padding(4);
			this.btn_send_res_demand.Name = "btn_send_res_demand";
			this.btn_send_res_demand.Size = new System.Drawing.Size(409, 106);
			this.btn_send_res_demand.TabIndex = 13;
			this.btn_send_res_demand.Text = "Выгрузить потребность в материалах";
			this.btn_send_res_demand.UseVisualStyleBackColor = true;
			this.btn_send_res_demand.Click += new System.EventHandler(this.btn_send_res_demand_Click);
			// 
			// frm_export_calc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(455, 433);
			this.Controls.Add(this.tab_main);
			this.Controls.Add(this.lbl_counter);
			this.Controls.Add(this.lbl_success);
			this.Controls.Add(this.progress);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frm_export_calc";
			this.Text = "Расход/Подтверждение";
			this.tab_main.ResumeLayout(false);
			this.tab_calc.ResumeLayout(false);
			this.tab_calc.PerformLayout();
			this.tab_good.ResumeLayout(false);
			this.tab_lamin.ResumeLayout(false);
			this.tab_lamin.PerformLayout();
			this.tab_res_demand.ResumeLayout(false);
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
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabControl tab_main;
		private System.Windows.Forms.TabPage tab_calc;
		private System.Windows.Forms.TabPage tab_good;
		private System.Windows.Forms.TabPage tab_lamin;
		private System.Windows.Forms.Button btn_unload_good;
		private System.Windows.Forms.Button btn_unload_good_group;
		private System.Windows.Forms.Button btn_get_price_from_1c;
		private System.Windows.Forms.TabPage tab_res_demand;
		private System.Windows.Forms.Button btn_send_res_demand;
	}
}
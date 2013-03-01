using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using kibicom;
using kibicom.tlib;
using kibicom.wd_1c_conf;
using System.Data;
using System.Data.SqlClient;

namespace kibicom.wd_1c_trans_gdi
{
	public partial class frm_main : Form
	{


		t_wd_1c_trans wd_1c_trans = new t_wd_1c_trans();

		t args;

		public frm_main()
		{
			InitializeComponent();
		}

		public frm_main(SqlConnection conn)
		{
			InitializeComponent();

			//принимаем переданное соединение
			args["conn"] = new t(conn);

			
			
		}



		#region служебное

		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;
		private void frm_main_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Capture = false;
				Message msg = Message.Create(Handle, WM_NCLBUTTONDOWN, (IntPtr)HT_CAPTION, IntPtr.Zero);
				base.WndProc(ref msg);
			}
		}

		private void btn_close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		#endregion служебное

		private void btn_calc_2_1c_Click(object sender, EventArgs e)
		{

			//выключаем кнопки что бы не щелкали по ка не закончиться текущая операция
			lbl_success.Visible = false;
			btn_calc_2_1c.Enabled = false;
			btn_cancel_calc_1c.Enabled = false;

			wd_1c_trans.f_calc_wd_2_dbf(new t()
			{
				{
					"wd_db", new t()
					{
						{"server",			"192.168.1.201"},
						{"server_name",		""},
						{"login",			"sa"},
						{"pass",			"82757662=z"},
						{"db_name",			"ecad_venta"},
						{"tab_name",		"calc"},
						{"count",			""},
						{"order_name",		""},
						{"idorder",			"91964"},
						{"md_name",			""},
						{"idmanufactdoc",	""},
						{"conn",			args["conn"]},
						{"reconnect",		false}
					}
				},
				{
					"dbf_db", new t()
					{
						{"location",		@"c:\dbf\"},
						{"db_file_name",	""},
						{"login",			"Admin"},
						{"pass",			""},
						{"tab_name",		"calc"},
					}
				},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{
						string query = args_1["query"].f_val<string>();

						//txt_log.Text += query;

						lbl_success.Visible = true;

						//и включаем все
						btn_calc_2_1c.Enabled = true;
						btn_cancel_calc_1c.Enabled = true;

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						MessageBox.Show(msg+"\r\n"+ex.Message);
						//txt_log.Text += msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				},
				{
					"f_progress", new t_f<t,t>(delegate(t args_1)
					{

						int i=args_1["index"].f_val<int>();
						int cnt = args_1["cnt"].f_val<int>();

						progress.Maximum = cnt;
						progress.Increment(1);

						lbl_counter.Text = i.ToString() + "/" + cnt.ToString();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						//txt_log.Text += msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				}
			});
		}

	}
}

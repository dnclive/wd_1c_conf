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
using System.IO;

namespace kibicom.wd_1c_trans_gdi
{
	public partial class frm_main : Form
	{


		t_wd_1c_trans wd_1c_trans = new t_wd_1c_trans();

		t args=new t();

		public frm_main()
		{
			//*******данный код вызывается при запуске проекта в студии, для отладки
			InitializeComponent();

			SqlConnection conn = new SqlConnection("Server=192.168.1.201;Database=ecad_venta;User Id=sa;Password=82757662=z;Connection Timeout=300");

			//conn.Open();
			//conn.Close();

			//принимаем переданное соединение
			args["conn"] = new t(conn);

			//принимаем переданное соединение
			//args["conn"] = new t(conn);

			//выгрузка расхода заказа
			//args["id"] = new t(91964);
			//args["wd_id_name"] = new t("idorder");
			//args["dbf_id_name"] = new t("idorder");

			//выгрузка расхода ПЗ
			args["id"] = new t(3271);
			args["wd_id_name"] = new t("idmanufact");
			args["dbf_id_name"] = new t("idmanufact");

			args["dbf_location"] = new t(@"Z:\");

		}

		public frm_main(SqlConnection conn)
		{
			InitializeComponent();

			//принимаем переданное соединение
			args["conn"] = new t(conn);


			args["dbf_location"] = new t(@"Z:\");
			
		}

		public frm_main(SqlConnection conn, string wd_id_name, string dbf_id_name, int id)
		{
			
			//*******
			//даный конструктор выполняется из WinDraw на production
			//*******

			InitializeComponent();

			//принимаем переданное соединение
			args["conn"] = new t(conn);
			args["id"] = new t(id);
			args["wd_id_name"] = new t(wd_id_name);
			args["dbf_id_name"] = new t(dbf_id_name);

			//args["dbf_location"] = new t(@"Z:\");
			args["dbf_location"] = new t(@"\\SERVER3\dbf\");
			

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

		private void btn_Calc_Click(object sender, EventArgs e)
		{
			btn_calc_2_1c.Visible = true;
			btn_cancel_calc_1c.Visible = true;
			btn_export_good.Visible = false;
			btn_get_qu.Visible = false;
		}

		private void btn_good_Click(object sender, EventArgs e)
		{
			btn_calc_2_1c.Visible = false;
			btn_cancel_calc_1c.Visible = false;
			btn_export_good.Visible = true;
			btn_get_qu.Visible = true;
		}

		#endregion служебное

		private void btn_calc_2_1c_Click_chain(object sender, EventArgs e)
		{

		}

		//временное решение пока нет асинхронности
		//правильное решение через f_chain
		private void btn_calc_2_1c_Click(object sender, EventArgs e)
		{
			//выключаем кнопки что бы не щелкали пока не закончиться текущая операция
			lbl_counter.Text = "";
			lbl_success.Visible = false;
			btn_calc_2_1c.Enabled = false;
			btn_cancel_calc_1c.Enabled = false;
			progress.Value = 0;

			Button btn = (Button)sender;

			bool is_calc = false;
			bool is_cancel = false;

			if (btn.Name.Contains("cancel"))
			{
				is_cancel = true;
			}
			else
			{
				is_calc = true;
			}

			string dbf_location = args["dbf_location"].f_str();

			//удаляем таблицу calc
			wd_1c_trans.f_drop_tab(new t()
			{
				{"location_",		dbf_location},
				{"location",		"./"},
				{"db_file_name",	""},
				{"login",			"Admin"},
				{"pass",			""},
				{"tab_name",		"calc"},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{

						//txt_log.Text += "table calc dropped";

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						//txt_log.Text = msg + "\r\n" + ex.Message + "\r\n";

						return null;
					})
				}
			});
			
			//создаем новую
			wd_1c_trans.f_make_tab_calc(new t()
			{
				{"location_",		dbf_location},
				{"location",		"./"},
				{"db_file_name",	""},
				{"login",			"Admin"},
				{"pass",			""},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{

						//txt_log.Text += "table calc created\r\n";

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						//txt_log.Text += "\r\n" + msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				}
			});
						

			//наполняем таблицу данными
			wd_1c_trans.f_calc_wd_dbf_trans(new t()
			{
				{
					"wd_db", new t()
					{
						{"server",					"192.168.1.201"},
						{"server_name",				""},
						{"login",					"sa"},
						{"pass",					"82757662=z"},
						{"db_name",					"ecad_venta"},
						{"tab_name",				"calc"},
						{"count",					""},
						{"order_name",				""},
						{"id_name",					args["wd_id_name"].f_str()},
						{"id",						args["id"].f_str()},
						{"md_name",					""},
						{"idmanufactdoc",			""},
						{"conn",					args["conn"].f_def(new SqlConnection())},
						{"reconnect",				false}
					}
				},
				{
					"dbf_db", new t()
					{
						//{"location",		@"\\SERVER3\dbf"},
						//{"location",		@"C:\dbf"},
						{"location_",		dbf_location},
						{"location",		"./"},
						//{"location",		@"Z:\"},
						{"db_file_name",	""},
						{"login",			"Admin"},
						{"pass",			""},
						{"tab_name",		"calc"},
						{"id_name",			args["dbf_id_name"].f_str()},
						{"id",				args["id"].f_str()},
						{"is_calc",			is_calc},
						{"is_cancel",		is_cancel}
					}
				},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{
						string query = args_1["query"].f_val<string>();

						//txt_log.Text += query;

						//MessageBox.Show("123");

						wd_1c_trans.f_close_all(new t());

						f_enable_face();

						//lbl_success.Visible = true;

						//и включаем все
						//btn_calc_2_1c.Enabled = true;
						//btn_cancel_calc_1c.Enabled = true;

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

			//удаляем файл если уже есть
			if (File.Exists(dbf_location + "calc.dbf"))
			{
				File.Delete(dbf_location + "calc.dbf");
			}

			//перемещаем наполненный файл в сеть
			File.Move("calc.dbf", dbf_location + "calc.dbf");

			//удаляем файл если уже есть
			if (File.Exists(dbf_location + "update"))
			{
				File.Delete(dbf_location + "update");
			}

			//создаем файл символизирующий обновление
			File.Create(dbf_location + "update");

		}

		private void btn_export_good_Click(object sender, EventArgs e)
		{
			//выключаем кнопки что бы не щелкали пока не закончиться текущая операция
			f_disable_face();

			Button btn = (Button)sender;


			string dbf_location = args["dbf_location"].f_str();

			//удаление good
			wd_1c_trans.f_drop_tab(new t()
			{
				//{"location",		dbf_location},
				{"location",		"./"},
			    {"db_file_name",	""},
                {"login",			"Admin"},
                {"pass",			""},
				{"tab_name",		"good"},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{

						//txt_log.Text += "table good dropped";

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						//txt_log.Text = msg + "\r\n" + ex.Message + "\r\n";

						return null;
					})
				}
			});

			//создание good
			wd_1c_trans.f_make_tab_good(new t()
			{
				//{"location",		dbf_location},
				{"location",		"./"},
			    {"db_file_name",	""},
                {"login",			"Admin"},
                {"pass",			""},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{

						//txt_log.Text += "table good created\r\n";

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						//txt_log.Text += "\r\n" + msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				}
			});

			//наполнение good
			wd_1c_trans.f_good_wd_2_dbf(new t()
			{
				{
					"wd_db", new t()
					{
						{"server",					"192.168.1.201"},
						{"server_name",				""},
						{"login",					"sa"},
						{"pass",					"82757662=z"},
						{"db_name",					"ecad_venta"},
						{"count",					""},
						{"tab_name",				"good"},
					}
				},
				{
					"dbf_db", new t()
					{
						//{"location",		dbf_location},
						{"location",		"./"},
						{"db_file_name",	""},
						{"login",			"Admin"},
						{"pass",			""},
						{"tab_name",		"good"},
					}
				},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{
						string query = args_1["query"].f_val<string>();

						//MessageBox.Show("123");

						wd_1c_trans.f_close_all(new t());

						f_enable_face();

						//txt_log.Text += query;

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

			//удаляем файл если уже есть
			if (File.Exists(dbf_location + "good.dbf"))
			{
				File.Delete(dbf_location + "good.dbf");
			}

			//перемещаем наполненный файл в сеть
			File.Move("good.dbf", dbf_location + "good.dbf");

			//удаляем файл если уже есть
			if (File.Exists(dbf_location + "update"))
			{
				File.Delete(dbf_location + "update");
			}

			//создаем файл символизирующий обновление
			File.Create(dbf_location + "update");


		}


		private void f_disable_face()
		{
			//выключаем кнопки что бы не щелкали пока не закончиться текущая операция
			lbl_counter.Text = "";
			lbl_success.Visible = false;

			btn_Calc.Enabled = false;
			btn_good.Enabled = false;

			btn_calc_2_1c.Enabled = false;
			btn_cancel_calc_1c.Enabled = false;

			btn_export_good.Enabled = false;
			btn_get_qu.Enabled = false;

			btn_close.Enabled = false;

			progress.Value = 0;

		}

		private void f_enable_face()
		{
			//выключаем кнопки что бы не щелкали пока не закончиться текущая операция
			//lbl_counter.Text = "";
			//lbl_success.Visible = false;

			lbl_success.Visible = true;

			//и включаем все
			btn_calc_2_1c.Enabled = true;
			btn_cancel_calc_1c.Enabled = true;

			btn_Calc.Enabled = true;
			btn_good.Enabled = true;

			btn_calc_2_1c.Enabled = true;
			btn_cancel_calc_1c.Enabled = true;

			btn_export_good.Enabled = true;
			btn_get_qu.Enabled = true;

			btn_close.Enabled = true;

			//progress.Value = 0;

		}



	}
}

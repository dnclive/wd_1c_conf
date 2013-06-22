﻿using System;
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
	public partial class frm_export_calc : Form
	{
		t_wd_1c_trans wd_1c_trans = new t_wd_1c_trans();

		t args=new t();

		#region init

		public frm_export_calc()
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
			args["id"] = new t("95759,95760,95770");
			//args["wd_id_name"] = new t("idmanufact");
			args["wd_id_name"] = new t("idorder");
			//args["dbf_id_name"] = new t("idmanufact");
			args["dbf_id_name"] = new t("idorder");
			args["dbf_manuf_name"] = new t("р 345/05");

			args["dbf_file_name"] = new t("manuf");
			args["dbf_file_name_lamin"] = new t("lamin");
			args["dbf_location"] = new t(@"Z:\");

		}

		public frm_export_calc(SqlConnection conn)
		{
			InitializeComponent();

			//принимаем переданное соединение
			args["conn"] = new t(conn);


			args["dbf_location"] = new t(@"Z:\");
			
		}

		public frm_export_calc
		(
			SqlConnection conn, 
			string wd_id_name, 
			string dbf_id_name, 
			string id, 
			string manuf_name,
			string tab_name
		)
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
			args["dbf_manuf_name"] = new t(manuf_name);

			lbl_manuf_name.Text=manuf_name;

			args["dbf_file_name"] = new t(tab_name);

			//args["dbf_location"] = new t(@"Z:\");
			args["dbf_location"] = new t(@"\\SERVER3\dbf\");
			

		}

		#endregion init

		//временное решение пока нет асинхронности
		//правильное решение через f_chain
		private void btn_calc_2_1c_Click(object sender, EventArgs e)
		{
			//выключаем кнопки что бы не щелкали пока не закончиться текущая операция

			f_disable_face();

			progress.Value = 0;

			string dbf_file_name = args["dbf_file_name"].f_def("calc").f_str();

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

			string id = args["id"].f_str();
			if (rbtn_by_date.Checked)
			{
				if (args["wd_id_name"].f_str() == "idmanufact")
				{
					id = " (select idmanufactdoc from manufactdoc where dbo.atdate1(dtdoc) between '" +
						dt_from.Value.ToString("yyyyMMdd") + "' and '" +
						dt_to.Value.ToString("yyyyMMdd") + "') ";
				}
				else
				{
					id = " (select idorder from orders where dbo.atdate1(dtdoc) between '" +
						dt_from.Value.ToString("yyyyMMdd") + "' and '" +
						dt_to.Value.ToString("yyyyMMdd") + "') ";
				}
			}

			//MessageBox.Show(id);

			//удаляем таблицу
			wd_1c_trans.f_drop_tab(new t()
			{
				{"location_",		dbf_location},
				{"location",		"./"},
				{"db_file_name",	""},
				{"login",			"Admin"},
				{"pass",			""},
				{"tab_name",		dbf_file_name},
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
				{"db_file_name",	dbf_file_name},
				{"tab_name",		dbf_file_name},
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

						MessageBox.Show(msg+"\r\n"+ex.Message);
						//txt_log.Text += "\r\n" + msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				}
			});

			//MessageBox.Show("2");

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
						{"tab_name",				dbf_file_name},
						{"count",					""},
						{"order_name",				""},
						{"id_name",					args["wd_id_name"].f_str()},
						{"id",						id},
						{"view_name",				"view_1c_good_calc"},
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
						{"tab_name",		dbf_file_name},
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
			if (File.Exists(dbf_location + dbf_file_name+ ".dbf"))
			{
				File.Delete(dbf_location + dbf_file_name + ".dbf");
			}

			if (File.Exists(dbf_file_name + ".dbf"))
			{
				//перемещаем наполненный файл в сеть
				File.Move(dbf_file_name + ".dbf", dbf_location + dbf_file_name + ".dbf");
			}

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

			rbtn_by_date.Enabled = false;
			rbtn_by_manufact.Enabled = false;

			dt_from.Enabled = false;
			dt_to.Enabled = false;

			btn_export_calc.Enabled = false;
			btn_cancel_calc.Enabled = false;
			btn_laminat.Enabled = false;

			args["is_blocked"].f_val(true);

			progress.Value = 0;

		}

		private void f_enable_face()
		{
			lbl_counter.Text = "";
			lbl_counter.Visible = true;
			lbl_success.Visible = true;

			rbtn_by_date.Enabled = true;
			rbtn_by_manufact.Enabled = true;

			dt_from.Enabled = true;
			dt_to.Enabled = true;

			btn_export_calc.Enabled = true;
			btn_cancel_calc.Enabled = true;
			btn_laminat.Enabled = true;

			args["is_blocked"].f_val(false);

		}

		private void btn_laminat_Click(object sender, EventArgs e)
		{
			//выключаем кнопки что бы не щелкали пока не закончиться текущая операция

			f_disable_face();

			progress.Value = 0;

			string dbf_file_name = args["dbf_file_name_lamin"].f_def("lamin").f_str();

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

			string id = args["id"].f_str();
			if (rbtn_by_date.Checked)
			{
				/*
				if (args["wd_id_name"].f_str() == "idmanufact")
				{
					id = " (select idmanufactdoc from manufactdoc where dbo.atdate1(dtdoc) between '" +
						dt_from.Value.ToString("yyyyMMdd") + "' and '" +
						dt_to.Value.ToString("yyyyMMdd") + "') ";
				}
				else
				{
					id = " (select idorder from orders where dbo.atdate1(dtdoc) between '" +
						dt_from.Value.ToString("yyyyMMdd") + "' and '" +
						dt_to.Value.ToString("yyyyMMdd") + "') ";
				}
				*/

				id = "'"+txt_order_name.Text.Trim().Replace(" ", "','")+"'";
			}



			//MessageBox.Show(id);

			//удаляем таблицу
			wd_1c_trans.f_drop_tab(new t()
			{
				{"location_",		dbf_location},
				{"location",		"./"},
				{"db_file_name",	""},
				{"login",			"Admin"},
				{"pass",			""},
				{"tab_name",		dbf_file_name},
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
				{"db_file_name",	dbf_file_name},
				{"tab_name",		dbf_file_name},
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

						MessageBox.Show(msg+"\r\n"+ex.Message);
						//txt_log.Text += "\r\n" + msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				}
			});

			//MessageBox.Show("2");

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
						{"tab_name",				dbf_file_name},
						{"count",					""},
						{"order_name",				""},
						{"id_name",					"order_num"},
						{"id",						id},
						{"view_name",				"view_1c_lamination"},
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
						{"tab_name",		dbf_file_name},
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
			if (File.Exists(dbf_location + dbf_file_name + ".dbf"))
			{
				File.Delete(dbf_location + dbf_file_name + ".dbf");
			}

			if (File.Exists(dbf_file_name + ".dbf"))
			{
				//перемещаем наполненный файл в сеть
				File.Move(dbf_file_name + ".dbf", dbf_location + dbf_file_name + ".dbf");
			}

			//удаляем файл если уже есть
			if (File.Exists(dbf_location + "update"))
			{
				File.Delete(dbf_location + "update");
			}

			//создаем файл символизирующий обновление
			File.Create(dbf_location + "update");
		}

		private void btn_unload_good_Click(object sender, EventArgs e)
		{
			f_unload_good(this.args);
			//f_unload_good_group(this.args);
		}

		private t f_unload_good(t args)
		{

			//выключаем кнопки что бы не щелкали пока не закончиться текущая операция
			f_disable_face();

			//Button btn = (Button)sender;


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

			return new t();
		}

		private t f_unload_good_group(t args)
		{

			//выключаем кнопки что бы не щелкали пока не закончиться текущая операция
			f_disable_face();

			//Button btn = (Button)sender;


			string dbf_location = args["dbf_location"].f_str();

			//удаление good
			wd_1c_trans.f_drop_tab(new t()
			{
				//{"location",		dbf_location},
				{"location",		"./"},
			    {"db_file_name",	""},
                {"login",			"Admin"},
                {"pass",			""},
				{"tab_name",		"good_group"},
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
			wd_1c_trans.f_make_tab_good_group(new t()
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
			wd_1c_trans.f_good_group_2_dbf(new t()
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
						{"tab_name",		"good_group"},
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
			if (File.Exists(dbf_location + "good_group.dbf"))
			{
				File.Delete(dbf_location + "good_group.dbf");
			}

			//перемещаем наполненный файл в сеть
			File.Move("good_group.dbf", dbf_location + "good_group.dbf");

			//удаляем файл если уже есть
			if (File.Exists(dbf_location + "update"))
			{
				File.Delete(dbf_location + "update");
			}

			//создаем файл символизирующий обновление
			File.Create(dbf_location + "update");

			return new t();
		}

		private void tab_good_Click(object sender, EventArgs e)
		{

		}

		private void btn_unload_good_group_Click(object sender, EventArgs e)
		{
			f_unload_good_group(this.args);
		}

		private void btn_get_price_from_1c_Click(object sender, EventArgs e)
		{
			//наполнение good
			wd_1c_trans.f_get_price_from_1C(new t()
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
						{"location",		args["dbf_location"].f_str()},
						//{"location",		"./"},
						{"db_file_name",	""},
						{"login",			"Admin"},
						{"pass",			""},
						{"tab_name",		"good1C"},
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

						Update();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						//txt_log.Text += msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				}
			});
		}

		private void btn_send_res_demand_Click(object sender, EventArgs e)
		{
			//выключаем кнопки что бы не щелкали пока не закончиться текущая операция

			f_disable_face();

			progress.Value = 0;

			string dbf_file_name = "needs";

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

			string id = args["id"].f_str();
			if (rbtn_by_date.Checked&&1==0)
			{
				if (args["wd_id_name"].f_str() == "idmanufact")
				{
					id = " (select idmanufactdoc from manufactdoc where dbo.atdate1(dtdoc) between '" +
						dt_from.Value.ToString("yyyyMMdd") + "' and '" +
						dt_to.Value.ToString("yyyyMMdd") + "') ";
				}
				else
				{
					id = " (select idorder from orders where dbo.atdate1(dtdoc) between '" +
						dt_from.Value.ToString("yyyyMMdd") + "' and '" +
						dt_to.Value.ToString("yyyyMMdd") + "') ";
				}
			}
			else
			{
				
				foreach (t id_i in (IList<t>)args["id"])
				{
					id = t_uti.fjoin(id, ',', id_i.f_str());
				}
			}

			//MessageBox.Show(id);

			//удаляем таблицу
			wd_1c_trans.f_drop_tab(new t()
			{
				{"location_",		dbf_location},
				{"location",		"./"},
				{"db_file_name",	""},
				{"login",			"Admin"},
				{"pass",			""},
				{"tab_name",		dbf_file_name},
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
			wd_1c_trans.f_make_tab_good_needs(new t()
			{
				{"location_",		dbf_location},
				{"location",		"./"},
				{"db_file_name",	dbf_file_name},
				{"tab_name",		dbf_file_name},
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

						MessageBox.Show(msg+"\r\n"+ex.Message);
						//txt_log.Text += "\r\n" + msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				}
			});

			//MessageBox.Show("2");

			//наполняем таблицу данными
			wd_1c_trans.f_good_needs_2_dbf(new t()
			{
				{
					"wd_db", new t()
					{
						{"server",					"192.168.1.201"},
						{"server_name",				""},
						{"login",					"sa"},
						{"pass",					"82757662=z"},
						{"db_name",					"ecad_venta"},
						{"tab_name",				dbf_file_name},
						{"count",					""},
						{"order_name",				""},
						{"id_name",					args["wd_id_name"].f_str()},
						{"id",						id},
						{"view_name",				"view_1c_good_needs"},
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
						{"tab_name",		dbf_file_name},
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
			if (File.Exists(dbf_location + dbf_file_name + ".dbf"))
			{
				File.Delete(dbf_location + dbf_file_name + ".dbf");
			}

			if (File.Exists(dbf_file_name + ".dbf"))
			{
				//перемещаем наполненный файл в сеть
				File.Move(dbf_file_name + ".dbf", dbf_location + dbf_file_name + ".dbf");
			}

			//удаляем файл если уже есть
			if (File.Exists(dbf_location + "update"))
			{
				File.Delete(dbf_location + "update");
			}

			//создаем файл символизирующий обновление
			File.Create(dbf_location + "update");
		}

	}
}

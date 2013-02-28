using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using kibicom.tlib;

namespace kibicom.wd_1c_conf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class main_win : Window
	{

		t_wd_1c_trans wd_1c_trans = new t_wd_1c_trans();

		t args;

		public main_win()
		{
			InitializeComponent();



			txt_log.Text += "\r\n";
		}

		#region создание таблиц dbf

		private void btn_make_all_Click(object sender, RoutedEventArgs e)
		{
			wd_1c_trans.f_make_tab_good(new t()
			{
				{"location",		txt_db_location.Text},
			    {"db_file_name",	""},
                {"login",			"Admin"},
                {"pass",			""}
			});
		}

		private void btn_make_tab_good_Click(object sender, RoutedEventArgs e)
		{
			wd_1c_trans.f_make_tab_good(new t()
			{
				{"location",		txt_db_location.Text},
			    {"db_file_name",	""},
                {"login",			"Admin"},
                {"pass",			""},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{

						txt_log.Text += "table good created\r\n";

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						txt_log.Text += "\r\n" + msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				}
			});
		}

		private void make_tab_goodcalc_Click(object sender, RoutedEventArgs e)
		{
			wd_1c_trans.f_make_tab_calc(new t()
			{
				{"location",		txt_db_location.Text},
			    {"db_file_name",	""},
                {"login",			"Admin"},
                {"pass",			""},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{

						txt_log.Text += "table calc created\r\n";

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						txt_log.Text += "\r\n" + msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				}
			});
		}

		#endregion создание таблиц dbf

		private void btn_connect_Click(object sender, RoutedEventArgs e)
		{

		}

		#region удаление таблиц из dbf

		private void btn_drop_good_Click(object sender, RoutedEventArgs e)
		{
			wd_1c_trans.f_drop_tab(new t()
			{
				{"location",		txt_db_location.Text},
			    {"db_file_name",	""},
                {"login",			"Admin"},
                {"pass",			""},
				{"tab_name",		"good"},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{

						txt_log.Text += "table good dropped";

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						txt_log.Text = msg + "\r\n" + ex.Message + "\r\n";

						return null;
					})
				}
			});
		}

		private void btn_drop_goodcalc_Click(object sender, RoutedEventArgs e)
		{
			wd_1c_trans.f_drop_tab(new t()
			{
				{"location",		txt_db_location.Text},
			    {"db_file_name",	""},
                {"login",			"Admin"},
                {"pass",			""},
				{"tab_name",		"calc"},
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{

						txt_log.Text += "table calc dropped";

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						txt_log.Text = msg + "\r\n" + ex.Message + "\r\n";

						return null;
					})
				}
			});
		}

		private void btn_drop_all_Click(object sender, RoutedEventArgs e)
		{

		}

		#endregion удаление таблиц из dbf

		#region заполнение таблиц

		private void btn_fill_good_Click(object sender, RoutedEventArgs e)
		{
			wd_1c_trans.f_good_wd_2_dbf(new t()
			{
				{
					"wd_db", new t()
					{
						{"server",			txt_server.Text},
						{"server_name",		txt_server_name.Text},
						{"login",			txt_login.Text},
						{"pass",			txt_pass.Password},
						{"db_name",			txt_db_name.Text},
						{"tab_name",		"good"},
						{"count",			txt_cnt.Text},
					}
				},
				{
					"dbf_db", new t()
					{
						{"location",		txt_db_location.Text},
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

						//txt_log.Text += query;

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						txt_log.Text += msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				}
			});
		}

		private void btn_calc_2_1c_Click(object sender, RoutedEventArgs e)
		{
			wd_1c_trans.f_calc_wd_2_dbf(new t()
			{
				{
					"wd_db", new t()
					{
						{"server",			txt_server.Text},
						{"server_name",		txt_server_name.Text},
						{"login",			txt_login.Text},
						{"pass",			txt_pass.Password},
						{"db_name",			txt_db_name.Text},
						{"tab_name",		"calc"},
						{"count",			txt_cnt.Text},
						{"order_name",		txt_order_name_id.Text},
						{"idorder",			txt_order_name_id.Text},
						{"md_name",			txt_manuf_name_id.Text},
						{"idmanufactdoc",	txt_manuf_name_id.Text},
					}
				},
				{
					"dbf_db", new t()
					{
						{"location",		txt_db_location.Text},
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

						return null;
					})
				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						//MessageBox.Show(msg+"\r\n"+ex.Message);
						txt_log.Text += msg + "\r\n" + ex.Message+"\r\n";

						return null;
					})
				},
				{"f_log", new t_f<t,t>(f_log)}
			});
		}

		#endregion заполнение таблиц

		#region служебное

		private t f_fail(t args)
		{
			Exception ex = args["ex"].f_def_set(new Exception("ex не задан")).f_val<Exception>();

			txt_log.Text = "\r\n\r\n"+ ex.Message + "\r\n";
			txt_log.Text = args["message"].f_str() + "\r\n";

			return null;
		}


		private t f_log(t args)
		{
			string msg = args["msg"].f_str();

			txt_log.Text = "\r\n\r\n" + msg + "\r\n";

			return null;
		}

		#endregion служебное

		private void w_wd_1c_conf_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				this.DragMove();
		}

		private void bnt_win_close_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}



	}


}

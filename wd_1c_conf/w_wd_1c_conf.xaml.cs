using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using tlib;

namespace wd_1c_conf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		t_wd_1c_trans wd_1c_trans = new t_wd_1c_trans();

		public MainWindow()
		{
			InitializeComponent();

			txt_log.Text += "\r\n";
		}

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

		private void btn_drop_all_Click(object sender, RoutedEventArgs e)
		{

		}

		private void btn_connect_Click(object sender, RoutedEventArgs e)
		{

		}

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

		private void btn_drop_good_Click(object sender, RoutedEventArgs e)
		{
			wd_1c_trans.f_drop_tab_good(new t()
			{
				{"location",		txt_db_location.Text},
			    {"db_file_name",	""},
                {"login",			"Admin"},
                {"pass",			""},
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
						txt_log.Text = msg + "\r\n" + ex.Message;

						return null;
					})
				}
			});
		}

		private void f_log()
		{

		}

	}

	
}

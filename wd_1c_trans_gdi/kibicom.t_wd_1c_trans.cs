using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using kibicom.tlib;
using System.Windows;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace kibicom.wd_1c_conf
{
	public class t_wd_1c_trans : t
	{

		public t_oledb_cli f_oledb_cli(t args)
		{
			if (this["oledb_cli"].f_is_empty())
			{
				this["oledb_cli"] = new t_oledb_cli(args);
			}

			t.f_f("f_done", args);

			return this["oledb_cli"].f_val<t_oledb_cli>();
		}

		#region создание/удаление таблиц

		//***good
		public void f_make_tab_good(t args)
		{

			t_oledb_cli oledb_cli = this["oledb_cli"].f_def(new t_oledb_cli(args)).f_val<t_oledb_cli>();

			try
			{
				oledb_cli.f_exec_cmd(args.f_add(true, new t()
				{
					{"cmd_",		"CREATE TABLE [good] "+
								"( "+
								"	id				int, "+
								"	marking			varchar(100) NULL, "+
								"	marking_id		varchar(100) NULL "+
								")"
					},
				
					{"cmd",		"CREATE TABLE [good] "+
								"( "+
								"	id				int, "+
								"	marking			varchar(100)	NULL, "+
								"	marking_id		varchar(100)	NULL, "+
								"	name			varchar(100)	NULL, "+
								"	colorin			varchar(100)	NULL, "+
								"	colorout		varchar(100)	NULL, "+
								"	pack_stand		varchar(100)	NULL, "+
								"	measure			varchar(100)	NULL, "+
								"	price			decimal(12,4)	NULL, "+
								"	price_base		decimal(12,4)	NULL, "+
								"	good_type		varchar(100)	NULL, "+
								"	system			varchar(100)	NULL, "+
								"	waste			decimal(3,4)	NULL "+
								")"
					},
					{
						"f_done", new t_f<t,t>(delegate(t args_1)
						{

							Console.WriteLine("done");

							return null;
						})
					},
					{"f_fail", args["f_fail"].f_f()},
				}));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return;
		}

		//***calc
		public void f_make_tab_calc(t args)
		{

			t_oledb_cli oledb_cli = this["oledb_cli"].f_def(new t_oledb_cli(args)).f_val<t_oledb_cli>();

			try
			{
				oledb_cli.f_exec_cmd(args.f_add(true, new t()
				{
				
					{"cmd_",				"CREATE TABLE [good] ( id int, marking varchar(100) )"},
					{"cmd",		"CREATE TABLE [calc] "+
								"( "+
								//"	id				int, "+
								"	id_good			int, "+
								"	marking			varchar(100)	NULL, "+
								"	marking_id		varchar(100)	NULL, "+
								"	qu				double NULL, "+
								"	qu_store		double NULL, "+
								"	idorder			int NULL, "+
								"	idorderitem		int NULL, "+
								"	idmanufact		int NULL, "+
								"	dtcre			TimeStamp NULL, "+
								"	store			varchar(100) NULL "+
								")"
					},
					{
						"f_done_", new t_f<t,t>(delegate(t args_1)
						{

							Console.WriteLine("done");

							return null;
						})
					}
				}));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return;
		}


		//удаляем
		public void f_drop_tab(t args)
		{

			t_oledb_cli oledb_cli = f_oledb_cli(args);

			string tab_name = args["tab_name"].f_str();

			//t_oledb_cli oledb_cli = this["oledb_cli"].f_def(new t_oledb_cli(args)).f_val<t_oledb_cli>();

			try
			{
				oledb_cli.f_exec_cmd(args.f_add(true, new t()
				{
				
					{"cmd",		"drop table " +tab_name},
					{
						"f_done_", new t_f<t,t>(delegate(t args_1)
						{

							

							return null;
						})
					}
				}));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

			return;
		}

		#endregion создание/удаление таблиц

		//выгрузка данных good в dbf
		public void f_good_wd_2_dbf(t args)
		{
			t_msslq_cli mssql_cli = this["mssql_cli"].f_def(new t_msslq_cli()).f_val<t_msslq_cli>();

			t_oledb_cli oledb_cli = f_oledb_cli(args["dbf_db"]);

			//t_oledb_cli oledb_cli = this["oledb_cli"].f_def(new t_oledb_cli(args["dbf_db"])).f_val<t_oledb_cli>();

			string count = args["wd_db"]["count"].f_def("1000000").f_str();

			//получаем список доступных бд для сервера
			//и выполняем f_each если передана
			mssql_cli.f_select(args["wd_db"].f_add(true, new t()
            {
				{"conn_keep_open", true},
                {"cmd",			"select "+(count==""?"":"top "+count)+" "+
								"	idgood as id, "+
								"	marking, "+
								"	extmarking as marking_id, "+
								"	g.name as name, "+
								"	(select name from color where idcolor=g.idcolor1) as colorin, "+
								"	(select name from color where idcolor=g.idcolor2) as colorout, "+
								"	packing as pack_stand, "+
								"	(select name from measure where g.idmeasure=idmeasure) as measure, "+
								"	price1 as price, "+
								"	CAST(price1 *[ecad_venta].[dbo].[get_valutrate](g.idvalut, getdate()) as numeric(15,4))as price_base,	"+
								"	(select name from goodtype where g.idgoodtype=idgoodtype) as good_type, "+
								"	(select name from system where g.idsystem=idsystem) as system, "+
								"	waste "+
								"from good g where deleted is null"+
								""
				},
                {
					"f_each_", new t_f<t,t>(delegate(t args_1)
					{
						DataRow dr=args_1["each"]["item"].f_val<DataRow>();
						int index = args_1["each"]["index"].f_val<int>();

						MessageBox.Show(index.ToString());

						/*
						f_f("f_each", args.f_add(true, new t()
						{
							{"item",	dr["name"].ToString()},
							{"index",	index}
						}));
						*/
						return null;
					})
				},
				{"f_fail", args["f_fail"].f_f()},
				{	//когда будет получена таблица
					"f_done", new t_f<t,t>(delegate(t args_1)
					{
						DataTable tab = args_1["tab"].f_val<DataTable>();

						//количество строк результата
						int row_cnt = tab.Rows.Count;

						//текущая обрабатываемая строка
						int i=0;

						//формируем inset запрос для строк полученной таблицы
						oledb_cli.f_make_ins_query(args["dbf_db"].f_add(true, new t()
						{
							{"tab", tab},
							{
								"f_each", new t_f<t,t>(delegate(t args_2)
								{
									string query = args_2["query"].f_val<string>();

									//MessageBox.Show(query);

									//t.f_f("f_done", args.f_add(true, args_2));

									i++;

									t.f_f(args["f_progress"].f_f(), new t() { { "cnt", row_cnt}, {"index",  i} });

									//return null;

									try
									{
										oledb_cli.f_exec_cmd(args["dbf_db"].f_add(true, new t()
										{
											{"conn_keep_open", true},
											{"cmd",				query},
											{"db_file_name",	"good"},
											{
												"f_done_", new t_f<t,t>(delegate(t args_3)
												{

													Console.WriteLine("done");

													return null;
												})
											},
											{"f_done", args["f_done"].f_f()},
											{"f_fail", args["f_fail"].f_f()}
										}));
									}
									catch (Exception ex)
									{
										MessageBox.Show(ex.Message);
									}

									return null;
								})
							}
						}));

						return null;
					})
				}
            }));

			return;
		}

		public void f_calc_wd_dbf_trans(t args)
		{
			f_drop_calc_in_dbf(new t().f_add(true, args).f_add(true, new t()
			{
				{
					"f_done", new t_f<t,t>(delegate(t args_1)
					{

						f_calc_wd_2_dbf(new t().f_add(true, args).f_add(true, new t()
						{
							{
								"f_done_", new t_f<t,t>(delegate(t args_2)
								{

						

									return null;
								})
							},
						}));

						return null;
					})


				},
				{
					"f_fail", new t_f<t,t>(delegate(t args_1)
					{

						string msg=args_1["message"].f_str();
						Exception ex=args_1["ex"].f_def(new Exception("ex не задан")).f_val<Exception>();

						MessageBox.Show(msg+"\r\n"+ex.Message+"\r\n"+((t)ex.Data["args"])["cmd_text"].f_str());

						//MessageBox.Show("fail");

						return null;
					})


				},
			}));
		}

		public void f_drop_calc_in_dbf(t args)
		{
			t_oledb_cli oledb_cli = f_oledb_cli(new t().f_add(true, args["dbf_db"]).f_drop("f_done"));

			string id_name = args["dbf_db"]["id_name"].f_def("o.idorder").f_str();
			string id_val = args["dbf_db"]["id"].f_def(0).f_str();

			try
			{
				oledb_cli.f_exec_cmd(new t().f_add(true, args["dbf_db"].f_add(true, new t()
				{
				
					{"cmd",				"delete from calc where " +id_name+" = "+id_val},
					{"db_file_name",	"calc"},
					{
						"f_done_", new t_f<t,t>(delegate(t args_3)
						{
							oledb_cli["sql_conn"].f_val<OleDbConnection>().Close();
							Console.WriteLine("done");

							return null;
						})
					},
					{"f_done", args["f_done"].f_f()},
					{"f_fail", args["f_fail"].f_f()}
				})));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		//выгрузка данных goodcalc в dbf
		public void f_calc_wd_2_dbf(t args)
		{
			t_msslq_cli mssql_cli = this["mssql_cli"].f_def(new t_msslq_cli()).f_val<t_msslq_cli>();

			t_oledb_cli oledb_cli = f_oledb_cli(new t().f_add(true, args["dbf_db"]).f_drop("f_done"));

			//t_oledb_cli oledb_cli = this["oledb_cli"].f_def(new t_oledb_cli(args["dbf_db"])).f_val<t_oledb_cli>();

			string cout = args["wd_db"]["count"].f_def("1000").f_str();
			string order_name = args["wd_db"]["order_name"].f_def("").f_str();
			string idorder = args["wd_db"]["idorder"].f_def(0).f_str();
			string md_name = args["wd_db"]["md_name"].f_def("").f_str();
			string idmanufactdoc = args["wd_db"]["idmanufactdoc"].f_def(0).f_str();

			string id_name = args["wd_db"]["id_name"].f_def("o.idorder").f_str();
			string id_val = args["wd_db"]["id"].f_def(0).f_str();

			bool is_calc = args["dbf_db"]["is_calc"].f_def(true).f_val<bool>();
			bool is_cancel = args["dbf_db"]["is_cancel"].f_def(false).f_val<bool>();

			//получаем список доступных бд для сервера
			//и выполняем f_each если передана
			mssql_cli.f_select(args["wd_db"].f_add(true, new t()
            {
				{"conn_keep_open", true},
                {"cmd",		"select "+
							"	g.idgood as id_good, "+
							"	g.marking as marking, "+
							"	g.extmarking as marking_id, "+
							(is_calc?"	mc.qu, ":"	-mc.qu as qu, ")+
							(is_calc?"	mc.qustore as qu_store, ":"	-mc.qustore as qu_store, ")+
							"	mc.idorder, "+
							"	mc.idorderitem, "+
							"	md.idmanufactdoc as idmanufact, "+
							"	GETDATE() as dtcre, "+
							"	'' as store "+
							"from  "+
							"	modelcalc mc "+
							"	left join good g on mc.idgood=g.idgood "+
							"	left join orderitem oi on mc.idorderitem=oi.idorderitem "+
							"	left join orders o on mc.idorder=o.idorder "+
							"	left join manufactdocpos md_ps on md_ps.idorderitem=oi.idorderitem "+
							"	left join manufactdoc md on md_ps.idmanufactdoc=md.idmanufactdoc "+
							"where "+
							" o.deleted is null and "+
							" mc.deleted is null and "+
							" md.deleted is null and "+
							" md_ps.deleted is null and "+
							" oi.deleted is null and "+
							id_name+" = "+ id_val
							//"	o.name like 'б 345/12' or "+
							//"	o.idorder = 91964 "// or "+
							//"	md.name like 'б 123' or "+
							//"	md.idmanufactdoc=234234"
				},
				{"f_fail", args["f_fail"].f_f()},
				{	//когда будет получена таблица
					"f_done", new t_f<t,t>(delegate(t args_1)
					{
						//результат запроса
						DataTable tab = args_1["tab"].f_val<DataTable>();

						//количество строк результата
						int row_cnt = tab.Rows.Count;

						//текущая обрабатываемая строка
						int i=0;

						//формируем inset запрос для строк полученной таблицы
						oledb_cli.f_make_ins_query(args["dbf_db"].f_add(true, new t()
						{
							{"conn_keep_open", true},
							{"tab", tab},
							{
								"f_each", new t_f<t,t>(delegate(t args_2)
								{
									string query = args_2["query"].f_val<string>();

									//MessageBox.Show(query);

									i++;

									t.f_f(args["f_progress"].f_f(), new t() { { "cnt", row_cnt}, {"index",  i} });

									//return null;

									try
									{
										oledb_cli.f_exec_cmd(new t().f_add(true, args["dbf_db"].f_add(true, new t()
										{
				
											{"cmd",				query},
											{"db_file_name",	"calc"},
											{
												"f_done_", new t_f<t,t>(delegate(t args_3)
												{

													Console.WriteLine("done");

													return null;
												})
											},
											{"f_fail", args["f_fail"].f_f()}
										})).f_drop("f_done"));
									}
									catch (Exception ex)
									{
										MessageBox.Show(ex.Message);
									}

									return null;
								})
							},
							{"f_done", args["f_done"].f_f()},
						}));

						return null;
					})
				}
            }));

			return;
		}


	}
}

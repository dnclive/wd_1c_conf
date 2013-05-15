using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace kibicom.wd_1c_trans_gdi
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new frm_main());
			//Application.Run(new confirm_calc());
			Application.Run(new frm_export_calc());
		}
	}
}

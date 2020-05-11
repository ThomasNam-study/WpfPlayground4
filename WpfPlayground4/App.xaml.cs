using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WpfPlayground4
{
	/// <summary>
	/// App.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class App : Application
	{
		private Bootstrapper bootstrapper;

		public App()
		{
			ShutdownMode = ShutdownMode.OnMainWindowClose;

			bootstrapper = new Bootstrapper();

			// var config = Resolver.Resolve<ConfigVm>();
		}
	}
}

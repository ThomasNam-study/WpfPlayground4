using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace WpfPlayground4
{
	public class Bootstrapper
	{
		protected ContainerBuilder ContainerBuilder { get; private set; }

		public Bootstrapper()
		{
			Initialize();
			FinishInitialization();
		}

		protected virtual void Initialize()
		{
			ContainerBuilder = new ContainerBuilder();

			/*
			 * ContainerBuilder.RegisterType<MainVm> ().SingleInstance ();

			ContainerBuilder.RegisterType<UspmApi> ().As<IUspmApi> ().SingleInstance ();
			 */
		}

		private void FinishInitialization()
		{
			var container = ContainerBuilder.Build();
			Resolver.Initialize(container);
		}
	}
}

using System;
using Autofac;

namespace WpfPlayground4
{
	public class Resolver
	{
		private static IContainer _container;

		public static void Initialize(IContainer container)
		{
			_container = container;
		}

		public static object Resolve(Type type)
		{
			return _container.Resolve(type);
		}

		public static T Resolve<T>()
		{
			try
			{
				return _container.Resolve<T>();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);

				return default(T);
			}

		}
	}
}

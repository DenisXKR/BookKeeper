﻿using System.Web;
using System.Web.Mvc;

namespace BookKeeper.Web.Site
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}

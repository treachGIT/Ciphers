using Algorithms.App.ViewModels;
using Algorithms.App.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Algorithms.App
{
    public static class PageLocator
    {
		private static Dictionary<Type, Type> viewModelLookup = new Dictionary<Type, Type>
		{
			{ typeof(MainPageViewModel), typeof(MainPage) },
			{ typeof(RailFenceViewModel), typeof(RailFencePage) },
			{ typeof(LFSRViewModel), typeof(LFSRPage) },
			{ typeof(StreamCipherPageViewModel), typeof(StreamCipherPage) },
			{ typeof(CiphertextAutokeyViewModel), typeof(CiphertextAutokeyPage) }
		};

		public static Page CreatePage(Type viewModelType)
		{
			Type pageType = GetPageTypeForViewModel(viewModelType);
			if (pageType == null)
			{
				throw new Exception($"Cannot locate page type for {viewModelType}");
			}

			Page page = Activator.CreateInstance(pageType) as Page;
			return page;
		}

		private static Type GetPageTypeForViewModel(Type viewModelType)
		{
			var viewType = viewModelLookup[viewModelType];
			return viewType;
		}
	}
}

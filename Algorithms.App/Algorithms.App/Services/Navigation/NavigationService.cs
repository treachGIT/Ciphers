using Algorithms.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Algorithms.App.Services
{
    public class NavigationService : INavigationService
    {
		public Task InitializeAsync<TViewModel>() where TViewModel : BaseViewModel
		{
			return NavigateToAsync<TViewModel>();
		}

		public async Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
		{
			Page page = PageLocator.CreatePage(typeof(TViewModel));
			page.BindingContext = App.GetViewModel<TViewModel>();

			(page.BindingContext as BaseViewModel).Prepare();

			var navigationPage = Application.Current.MainPage as NavigationPage;
			NavigationPage.SetHasNavigationBar(page, false);
			if (navigationPage != null)
			{
				await navigationPage.PushAsync(page);
			}
			else
			{
				Application.Current.MainPage = new NavigationPage(page);
			}
		}

		public async Task NavigateToAsync<TViewModel, TParameter>(TParameter parameter) where TViewModel : BaseViewModel<TParameter>
		{
			Page page = PageLocator.CreatePage(typeof(TViewModel));
			page.BindingContext = App.GetViewModel<TViewModel>();

			(page.BindingContext as BaseViewModel<TParameter>).Prepare(parameter);

			var navigationPage = Application.Current.MainPage as NavigationPage;
			NavigationPage.SetHasNavigationBar(page, false);
			if (navigationPage != null)
			{
				await navigationPage.PushAsync(page);
			}
			else
			{
				Application.Current.MainPage = new NavigationPage(page);
			}
		}

		public async Task NavigateBackAsync()
		{
			var navigationPage = Application.Current.MainPage as NavigationPage;
			await navigationPage.PopAsync();
		}
	}
}

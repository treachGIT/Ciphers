using Algorithms.App.Services;
using Algorithms.App.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;

namespace Algorithms.App
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public App()
        {
            InitializeComponent();
            SetupServices();

            INavigationService navigationService = ServiceProvider.GetService<INavigationService>();
            navigationService.InitializeAsync<MainPageViewModel>();

           // MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private void SetupServices()
        {
            var serviceProvider = new ServiceCollection();

            serviceProvider.AddSingleton<INavigationService, NavigationService>();	

            serviceProvider.AddTransient<MainPageViewModel>();
            serviceProvider.AddTransient<RailFenceViewModel>();

            ServiceProvider = serviceProvider.BuildServiceProvider();
        }

        public static BaseViewModel GetViewModel<TViewModel>() where TViewModel : BaseViewModel
        {
            return ServiceProvider.GetService<TViewModel>();
        }
    }
}

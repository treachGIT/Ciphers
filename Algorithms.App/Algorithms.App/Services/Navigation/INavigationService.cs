using Algorithms.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.App.Services
{
    public interface INavigationService
    {
        Task InitializeAsync<TViewModel>() 
            where TViewModel : BaseViewModel;
        Task NavigateToAsync<TViewModel>() 
            where TViewModel : BaseViewModel;
        Task NavigateToAsync<TViewModel, 
            TParameter>(TParameter parameter) where TViewModel : BaseViewModel<TParameter>;
        Task NavigateBackAsync();
    }
}

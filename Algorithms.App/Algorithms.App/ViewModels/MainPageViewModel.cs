using Algorithms.App.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Algorithms.App.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            this.navigateToRailFenceCommand = new Command(async () => await _navigationService.NavigateToAsync<RailFenceViewModel>());

            this.navigateToLFSRGeneratorCommand = new Command(async () => await _navigationService.NavigateToAsync<LFSRViewModel>());

            this.navigateToStreamCipherCommand = new Command(async () => await _navigationService.NavigateToAsync<StreamCipherPageViewModel>());

            this.navigateToCiphertextAutokeyCommand = new Command(async () => await _navigationService.NavigateToAsync<CiphertextAutokeyViewModel>());

        }

        private Command navigateToRailFenceCommand;

        private Command navigateToTranspositionACommand;

        private Command navigateToTranspositionBCommand;

        private Command navigateToLFSRGeneratorCommand;

        private Command navigateToStreamCipherCommand;

        private Command navigateToCiphertextAutokeyCommand;

        private Command navigateToDesCommand;

        public ICommand NavigateToRailFenceCommand => this.navigateToRailFenceCommand;
        public ICommand NavigateToTranspositionACommand => this.navigateToTranspositionACommand;
        public ICommand NavigateToTranspositionBCommand => this.navigateToTranspositionBCommand;
        public ICommand NavigateToLFSRGeneratorCommand => this.navigateToLFSRGeneratorCommand;
        public ICommand NavigateToStreamCipherCommand => this.navigateToStreamCipherCommand;
        public ICommand NavigateToCiphertextAutokeyCommand => this.navigateToCiphertextAutokeyCommand;
        public ICommand NavigateToDesCommand => this.navigateToDesCommand;
    }
}

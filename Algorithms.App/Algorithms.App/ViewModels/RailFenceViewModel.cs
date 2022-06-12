using Algorithms.App.Services;
using AlgorithmsLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Algorithms.App.ViewModels
{
    public class RailFenceViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        private string textToEncrypt;

        private int key;

        private string encryptResult;

        public RailFenceViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
 
            this.encryptCommand = new Command(this.Encrypt);
            this.navigateBackCommand = new Command(async () => await _navigationService.NavigateBackAsync());
        }

        private Command encryptCommand;

        private Command navigateBackCommand;

        public ICommand EncryptCommand => this.encryptCommand;
        public ICommand NavigateBackCommand => this.navigateBackCommand;

        public string TextToEncrypt
        {
            get => this.textToEncrypt;
            set => this.SetProperty(ref this.textToEncrypt, value);
        }

        public int Key
        {
            get => this.key;
            set => this.SetProperty(ref this.key, value);
        }

        public string EncryptResult
        {
            get => this.encryptResult;
            set => this.SetProperty(ref this.encryptResult, value);
        }

        public void Encrypt()
        {
            //var result = RailFence.Encrypt(TextToEncrypt, 3);
            EncryptResult = "xd";
        }
    }
}

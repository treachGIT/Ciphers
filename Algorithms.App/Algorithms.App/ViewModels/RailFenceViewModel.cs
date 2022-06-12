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

        private string encryptResult;

        private string textToDecrypt;

        private string decryptResult;

        public RailFenceViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
 
            this.encryptCommand = new Command(this.Encrypt);
            this.decryptCommand = new Command(this.Decrypt);
            this.navigateBackCommand = new Command(async () => await _navigationService.NavigateBackAsync());
        }

        private Command encryptCommand;

        private Command decryptCommand;

        private Command navigateBackCommand;    

        public ICommand EncryptCommand => this.encryptCommand;
        public ICommand DecryptCommand => this.decryptCommand;
        public ICommand NavigateBackCommand => this.navigateBackCommand;

        public string TextToEncrypt
        {
            get => this.textToEncrypt;
            set
            {
                if (this.SetProperty(ref this.textToEncrypt, value))
                {
                    EncryptResult = String.Empty;
                }
            }
        }

        public string EncryptResult
        {
            get => this.encryptResult;
            set => this.SetProperty(ref this.encryptResult, value);
        }

        public string TextToDecrypt
        {
            get => this.textToDecrypt;
            set
            {
                if (this.SetProperty(ref this.textToDecrypt, value))
                {
                    DecryptResult = String.Empty;
                }
            }
        }

        public string DecryptResult
        {
            get => this.decryptResult;
            set => this.SetProperty(ref this.decryptResult, value);
        }

        public void Encrypt()
        {
            EncryptResult = RailFence.Encrypt(TextToEncrypt, 3);
        }

        public void Decrypt()
        {
            DecryptResult = RailFence.Decrypt(TextToDecrypt, 3);
        }
    }
}

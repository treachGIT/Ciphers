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

        private bool canEncrypt = false;

        private bool canDecrypt = false;

        private string encryptKey;

        private string textToEncrypt;

        private string encryptResult;

        private string decryptKey;

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

        public string EncryptKey
        {
            get => this.encryptKey;
            set
            {
                if (this.SetProperty(ref this.encryptKey, value))
                {
                    ValidateEncryptInput();
                    EncryptResult = String.Empty;
                }
            }
        }

        public string TextToEncrypt
        {
            get => this.textToEncrypt;
            set
            {
                if (this.SetProperty(ref this.textToEncrypt, value))
                {
                    ValidateEncryptInput();
                    EncryptResult = String.Empty;
                }
            }
        }

        public string EncryptResult
        {
            get => this.encryptResult;
            set => this.SetProperty(ref this.encryptResult, value);
        }

        public string DecryptKey
        {
            get => this.decryptKey;
            set 
            {
                if (this.SetProperty(ref this.decryptKey, value))
                {
                    ValidateDecryptInput();
                    DecryptResult = String.Empty;
                }
            }
        }

        public string TextToDecrypt
        {
            get => this.textToDecrypt;
            set
            {
                if (this.SetProperty(ref this.textToDecrypt, value))
                {
                    ValidateDecryptInput();
                    DecryptResult = String.Empty;
                }
            }
        }

        public string DecryptResult
        {
            get => this.decryptResult;
            set => this.SetProperty(ref this.decryptResult, value);
        }

        public bool CanEncrypt
        {
            get => this.canEncrypt;
            set => this.SetProperty(ref this.canEncrypt, value);
        }

        public bool CanDecrypt
        {
            get => this.canDecrypt;
            set => this.SetProperty(ref this.canDecrypt, value);
        }

        public void ValidateEncryptInput()
        {
            if (String.IsNullOrEmpty(EncryptKey) || !int.TryParse(EncryptKey, out int number) 
                || String.IsNullOrEmpty(TextToEncrypt) )
            {
                CanEncrypt = false;
                return;
            }       

            CanEncrypt = true;
        }

        public void ValidateDecryptInput()
        {
            if (String.IsNullOrEmpty(DecryptKey) || !int.TryParse(DecryptKey, out int number)
            || String.IsNullOrEmpty(TextToDecrypt))
            {
                CanDecrypt = false;
                return;
            }

            CanDecrypt = true;
        }

        public void Encrypt()
        {
            EncryptResult = RailFence.Encrypt(TextToEncrypt, int.Parse(EncryptKey));
        }

        public void Decrypt()
        {
            DecryptResult = RailFence.Decrypt(TextToDecrypt, int.Parse(DecryptKey));
        }
    }
}

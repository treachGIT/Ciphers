using Algorithms.App.Services;
using AlgorithmsLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Algorithms.App.ViewModels
{
    public class CiphertextAutokeyViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        private bool canEncrypt = false;

        private bool canDecrypt = false;

        private string encryptBitString;

        private string encryptSeed;

        private string encryptPolynomialBitMask;

        private string encryptResult;

        private string decryptBitString;

        private string decryptSeed;

        private string decryptPolynomialBitMask;

        private string decryptResult;

        public CiphertextAutokeyViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            this.encryptCommand = new Command(this.Encrypt);
            this.decryptCommand = new Command(this.Decrypt);

            // this.navigateBackCommand = new Command(async () => await _navigationService.NavigateBackAsync());
        }

        private Command encryptCommand;

        private Command decryptCommand;

        public ICommand EncryptCommand => this.encryptCommand;
        public ICommand DecryptCommand => this.decryptCommand;

        public string EncryptBitString
        {
            get => this.encryptBitString;
            set
            {
                if (this.SetProperty(ref this.encryptBitString, value))
                {
                    ValidateEncryptInput();
                }
            }
        }

        public string EncryptSeed
        {
            get => this.encryptSeed;
            set
            {
                if (this.SetProperty(ref this.encryptSeed, value))
                {
                    ValidateEncryptInput();
                }
            }
        }

        public string EncryptPolynomialBitMask
        {
            get => this.encryptPolynomialBitMask;
            set
            {
                if (this.SetProperty(ref this.encryptPolynomialBitMask, value))
                {
                    ValidateEncryptInput();
                }
            }
        }

        public string EncryptResult
        {
            get => this.encryptResult;
            set => this.SetProperty(ref this.encryptResult, value);
        }

        public string DecryptBitString
        {
            get => this.decryptBitString;
            set
            {
                if (this.SetProperty(ref this.decryptBitString, value))
                {
                    ValidateDecryptInput();
                }
            }
        }

        public string DecryptSeed
        {
            get => this.decryptSeed;
            set
            {
                if (this.SetProperty(ref this.decryptSeed, value))
                {
                    ValidateDecryptInput();
                }
            }
        }

        public string DecryptPolynomialBitMask
        {
            get => this.decryptPolynomialBitMask;
            set
            {
                if (this.SetProperty(ref this.decryptPolynomialBitMask, value))
                {
                    ValidateDecryptInput();
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

        private void Encrypt()
        {
            EncryptResult = CiphertextAutokey.Encrypt(EncryptBitString, EncryptSeed, EncryptPolynomialBitMask);
        }

        private void Decrypt()
        {
            DecryptResult = CiphertextAutokey.Decrypt(DecryptBitString, DecryptSeed, DecryptPolynomialBitMask);
        }

        public void ValidateEncryptInput()
        {
            if (String.IsNullOrEmpty(EncryptBitString) || !isStringBinary(EncryptBitString))
            {
                CanEncrypt = false;
                return;
            }

            if (String.IsNullOrEmpty(EncryptSeed) || String.IsNullOrEmpty(EncryptPolynomialBitMask))
            {
                CanEncrypt = false;
                return;
            }

            if (!isStringBinary(EncryptSeed) || !isStringBinary(EncryptPolynomialBitMask))
            {
                CanEncrypt = false;
                return;
            }

            if (EncryptSeed.Length != EncryptPolynomialBitMask.Length)
            {
                CanEncrypt = false;
                return;
            }

            CanEncrypt = true;
        }

        public void ValidateDecryptInput()
        {
            if (String.IsNullOrEmpty(DecryptBitString) || !isStringBinary(DecryptBitString))
            {
                CanDecrypt = false;
                return;
            }

            if (String.IsNullOrEmpty(DecryptSeed) || String.IsNullOrEmpty(DecryptPolynomialBitMask))
            {
                CanDecrypt = false;
                return;
            }

            if (!isStringBinary(DecryptSeed) || !isStringBinary(DecryptPolynomialBitMask))
            {
                CanDecrypt = false;
                return;
            }

            if (DecryptSeed.Length != DecryptPolynomialBitMask.Length)
            {
                CanDecrypt = false;
                return;
            }

            CanDecrypt = true;
        }

        private bool isStringBinary(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '1' && str[i] != '0')
                    return false;
            }
            return true;
        }
    }
}


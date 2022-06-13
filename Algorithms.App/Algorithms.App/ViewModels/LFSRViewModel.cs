using Algorithms.App.Services;
using AlgorithmsLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Algorithms.App.ViewModels
{
    public class LFSRViewModel : BaseViewModel
    {
        private INavigationService _navigationService;

        private CancellationTokenSource token;

        private bool canStart = false;

        private bool canStop = false;

        private string seed;

        private string polynomialBitMask;

        private string result;

        public LFSRViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            this.generateCommand = new Command( async () => await this.GenerateLFSR() );

            this.stopGeneratingCommand = new Command(StopGenerating);

           // this.navigateBackCommand = new Command(async () => await _navigationService.NavigateBackAsync());
        }

        private Command generateCommand;

        private Command stopGeneratingCommand;

        public ICommand GenerateCommand => this.generateCommand;

        public ICommand StopGeneratingCommand => this.stopGeneratingCommand;

        public string Seed
        {
            get => this.seed;
            set 
            {
                if (this.SetProperty(ref this.seed, value))
                {                   
                    ValidateInput();
                }
            }
        }

        public string PolynomialBitMask
        {
            get => this.polynomialBitMask;
            set
            {
                if (this.SetProperty(ref this.polynomialBitMask, value))
                {
                    ValidateInput();
                }
            }
        }

        public string Result
        {
            get => this.result;
            set => this.SetProperty(ref this.result, value);
        }

        public bool CanStart
        {
            get => this.canStart;
            set => this.SetProperty(ref this.canStart, value);
        }

        public bool CanStop
        {
            get => this.canStop;
            set => this.SetProperty(ref this.canStop, value);
        }

        private async Task GenerateLFSR()
        {
            CanStart = false;

            Result = String.Empty;
            LFSR keyGenerator = new LFSR(Seed, PolynomialBitMask);

            token = new CancellationTokenSource();

            CanStop = true;
            try
            {
                this.token.Token.ThrowIfCancellationRequested();
                while (true)
                {
                    Result = keyGenerator.GenerateNumber();
                    await Task.Delay(500, this.token.Token);
                }
            }
            catch (OperationCanceledException e)
            {
                return;
            }        
        }

        private void StopGenerating()
        {
            token.Cancel();

            CanStop = false;
            CanStart = true;      
            
            Result = String.Empty;
        }

        public void ValidateInput()
        {
            if(String.IsNullOrEmpty(Seed) || String.IsNullOrEmpty(PolynomialBitMask))
            {
                CanStart = false;
                return;
            }

            if(!isStringBinary(Seed) || !isStringBinary(PolynomialBitMask))
            {
                CanStart = false;
                return;
            }

            if(Seed.Length != PolynomialBitMask.Length)
            {
                CanStart = false;
                return;
            }

            CanStart = true;
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

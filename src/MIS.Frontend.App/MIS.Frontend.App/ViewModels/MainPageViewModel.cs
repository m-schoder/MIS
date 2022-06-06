using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MIS.Common.Client.Interfaces;
using MIS.Common.DataTransferObjects.Enums;
using MIS.Frontend.App.ViewModels.Base;
using Xamarin.Forms;
using Xamarin.Essentials;
using static MIS.Common.Constants.Constants;

namespace MIS.Frontend.App.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IServiceClient _serviceClient;
        private readonly ISolenoidClient _solenoidClient;
        private readonly IClientConfiguration _clientConfiguration;
        public ICommand ToggleSolenoid { get; }
        public ICommand ReloadConfig { get; }
        private SolenoidState _solenoidState;

        public string ApiKey
        {
            get => _clientConfiguration.ApiKey;
            set
            {
                _clientConfiguration.ApiKey = value;
                OnPropertyChanged(nameof(ApiKey));
            }
        }
        public string ServiceBaseUrl
        {
            get => _clientConfiguration.ServiceBaseUrl;
            set
            {
                _clientConfiguration.ServiceBaseUrl = value;
                OnPropertyChanged(nameof(ApiKey));
            }
        }

        public SolenoidState SolenoidState
        {
            get => _solenoidState;
            set
            {
                if (value == _solenoidState)
                {
                    return;
                }
                _solenoidState = value;
                OnPropertyChanged(nameof(SolenoidState));
                OnPropertyChanged(nameof(DisplayInformation));
                OnPropertyChanged(nameof(BackgroundColor));
            }
        }
        public string DisplayInformation => SolenoidState == SolenoidState.SwitchedOff ? "Solenoid is OFF" : "Solenoid is ON";

        public Color BackgroundColor => SolenoidState == SolenoidState.SwitchedOff ? Color.Gray : Color.LimeGreen;

        public MainPageViewModel(
            IServiceClient serviceClient,
            IClientConfiguration clientConfiguration,
            ISolenoidClient solenoidClient)
        {
            _serviceClient = serviceClient;
            _solenoidClient = solenoidClient;
            _clientConfiguration = clientConfiguration;
            ToggleSolenoid = new Command(OnToggleSolenoid);
            ReloadConfig = new Command(OnReloadConfig);
            Task.Run(async () => await Initialize());
        }

        private async Task Initialize()
        {
            try
            {
                _clientConfiguration.ApiKey = await SecureStorage.GetAsync(API_KEY);
                _clientConfiguration.ServiceBaseUrl = await SecureStorage.GetAsync(SERVICE_BASE_URL);
                try
                {
                    await _serviceClient.ReloadConfiguration();
                }
                catch (Exception)
                {
                    // Possible that configuration is invalid
                }
            }
            catch (Exception)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        private async void OnReloadConfig()
        {
            try
            {
                await SecureStorage.SetAsync(API_KEY, _clientConfiguration.ApiKey);
                await SecureStorage.SetAsync(SERVICE_BASE_URL, _clientConfiguration.ServiceBaseUrl);
                try
                {
                    await _serviceClient.ReloadConfiguration();
                }
                catch (Exception)
                {
                    // Possible that configuration is invalid
                }
            }
            catch (Exception)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }

        private async void OnToggleSolenoid()
        {
            if (SolenoidState == SolenoidState.SwitchedOff)
            {
                await _solenoidClient.SwitchOn();
            }
            else
            {
                await _solenoidClient.SwitchOff();
            }
            SolenoidState = (await _solenoidClient.GetState()).SolenoidState;
        }
    }
}

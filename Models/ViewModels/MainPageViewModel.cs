

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using GetDeviceLocation.Services;

namespace GetDeviceLocation.Models.ViewModels;

    public partial class MainPageViewModel : ObservableObject
    {

    private readonly LocationSyncService _locationSyncService;
        [ObservableProperty]
        private double latitude;

        [ObservableProperty]
        private double longitude;

        [ObservableProperty]
        private bool isListening;

        [ObservableProperty]
        private string? listeningButtonText;
    public MainPageViewModel(LocationSyncService locationSyncService)
    {
        _locationSyncService = locationSyncService;
        WeakReferenceMessenger.Default.Register<DeviceLocation>(this, (sender, deviceLocation) =>
        {
            latitude = deviceLocation.Latitude;
            longitude = deviceLocation.Longitude;
        });

        listeningButtonText = "Start";
        }

    [RelayCommand]
    private void ChangeListeningMode()
    {
        if (!IsListening)
        {
            _ = _locationSyncService.Start();
            IsListening = true;
            ListeningButtonText = "stop";
        }
        else
        {
            _locationSyncService.Stop();
            IsListening = true;
            ListeningButtonText = "start";
        }
    }
    }




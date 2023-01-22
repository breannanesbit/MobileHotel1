using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HotelFinal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelFinal.Services;

namespace HotelMobileApp.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly HotelService service;
        public string Roomtype { get; set; }
        public MainViewModel(HotelService service)
        {
            this.service = service;
            Roomtype = "(pick your dates)";
        }
        public string Working { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Roomtype))]
        private List<RoomType> room;

  

        [ObservableProperty]
        private DateTime selectedStartDate;

        [ObservableProperty]
        private DateTime selectedEndDate;


        [RelayCommand]
        private async Task GetAllRoomTypes()
        {
            Room = await service.GetAvailableRoomTypesAsync(selectedStartDate, selectedEndDate);
            Roomtype = Room[0].RType;
        }

        [RelayCommand]
        private void Start()
        {
            Working= "working";
        }

    }
}

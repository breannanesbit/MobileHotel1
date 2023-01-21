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
        public MainViewModel(HotelService service)
        {
            this.service = service;
        }

        [ObservableProperty]
        private List<RoomType> room;

        [RelayCommand]
        private async Task GetAllRoomTypes()
        {
            Room = await service.GetAllRoomTypesAsync();
        }

    }
}

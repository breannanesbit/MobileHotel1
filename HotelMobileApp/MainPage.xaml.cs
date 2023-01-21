using HotelMobileApp.ViewModel;

namespace HotelMobileApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext= vm;
        }
    }
}
using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using MonkeyHubApp.ViewModels;
using Xamarin.Forms;

namespace MonkeyHubApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

           // var monkeyHubApiService = DependencyService.Get<IMonkeyHubApiService>();
            this.BindingContext = new ViewModels.MainViewModel(new MonkeyHubApiService());
        }
        protected override void OnAppearing()
        {
            (BindingContext as MainViewModel)?.LoadAsync();

            base.OnAppearing();
        }


    }
}

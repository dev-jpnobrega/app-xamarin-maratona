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

            var monkeyHubApiService = DependencyService.Get<IMonkeyHubApiService>();
            var facebookApiService = DependencyService.Get<IFacebookService>();

            this.BindingContext = new ViewModels.MainViewModel(monkeyHubApiService, facebookApiService);
        }
        protected override void OnAppearing()
        {
            (BindingContext as MainViewModel)?.LoadAsync();

            base.OnAppearing();
        }


    }
}

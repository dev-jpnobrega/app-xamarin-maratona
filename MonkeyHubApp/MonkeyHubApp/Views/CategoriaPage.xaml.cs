using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MonkeyHubApp.Models;
using MonkeyHubApp.ViewModels;

namespace MonkeyHubApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoriaPage : ContentPage
    {
        public CategoriaPage()
        {
            InitializeComponent();            
        }

        protected override void OnAppearing()
        {
            (BindingContext as CategoriaViewModel)?.LoadAsync();

            base.OnAppearing();
        }


    }
}

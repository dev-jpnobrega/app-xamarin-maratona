using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyHubApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainDetailPage : MasterDetailPage
    {
        MenuDraw _menu;

        public MainDetailPage()
        {
            InitializeComponent();
            _menu = new Views.MenuDraw();
                      
            Master = _menu;           
            Detail = new NavigationPage(new MainPage());

            _menu.ListMenu.ItemSelected += OnSelected;
        }

        private void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Models.MenuItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                _menu.ListMenu.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
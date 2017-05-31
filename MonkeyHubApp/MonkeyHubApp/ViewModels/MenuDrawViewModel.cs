
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using MonkeyHubApp.Models;

namespace MonkeyHubApp.ViewModels
{
    public class MenuDrawViewModel: BaseViewModel
    {
        private ObservableCollection<Models.MenuItem> _menuItens;

        public ObservableCollection<Models.MenuItem> MenuItens
        {
            get { return _menuItens; }
            set { SetProperty(ref _menuItens, value); }
        }

        private string _welcome;

        public string Welcome
        {
            get { return _welcome; }
            set { SetProperty(ref _welcome, value); }
        }


        public ImageSource ImageUser
        {
            get { return ImageSource.FromUri(new System.Uri(User.UrlPicture)); }
        }


        public MenuDrawViewModel()
        {
            Welcome = $"Bem Vindo {User.FirstName}";

            MenuItens = new ObservableCollection<Models.MenuItem>();

            MenuItens.Add(new Models.MenuItem()
            {
                Title = "Home",
                Icon =  "fa-home",
                TargetType = typeof(MainPage)
            });

            MenuItens.Add(new Models.MenuItem()
            {
                Title = "Pesquisar",
                Icon =  "fa-search",
                TargetType = typeof(Views.SearchPage)
            });
        }

    }
}

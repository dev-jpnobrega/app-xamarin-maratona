using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System;
using System.Reflection;
using Xamarin.Forms;
using System.Linq;

namespace MonkeyHubApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string prop = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(prop);

            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
        public async Task PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);
            var viewModelTypeName = viewModelType.Name;
            var viewModelWordLength = "ViewModel".Length;
            var viewTypeName = $"MonkeyHubApp.Views.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}Page";
            var viewType = Type.GetType(viewTypeName);

            var page = Activator.CreateInstance(viewType) as Page;

            var viewModel = Activator.CreateInstance(viewModelType, args);

            if (page != null)            
                page.BindingContext = viewModel;            

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }


        public async Task MessegerAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task MessegerAlert(string title, string message, string accept, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}

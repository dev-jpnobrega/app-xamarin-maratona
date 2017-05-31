
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;


using MonkeyHubApp.Models;
using MonkeyHubApp.Services;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private readonly IMonkeyHubApiService _iMonkeyHubApiService;
        private readonly IFacebookService _iFacebookService;


        public ObservableCollection<Tag> Results { get; set; }

        public Command SearchCommand { get; }
        public Command AboutCommand { get; }
        public Command<Tag> ShowCategoriaCommand { get; }

        public MainViewModel(IMonkeyHubApiService IMonkeyHubApiService, IFacebookService iFacebookService)
        {
            _iMonkeyHubApiService = IMonkeyHubApiService;
            _iFacebookService = iFacebookService;

            SearchCommand = new Command(ExecuteSearchCommand);
            AboutCommand = new Command(ExecuteAboutCommand);
            ShowCategoriaCommand = new Command<Tag>(ExecuteShowCategoriaCommand);

            Title = "Bem vindo " + User.FirstName;
           
            Results = new ObservableCollection<Tag>();
        }
        
        async void ExecuteAboutCommand()
        {
            await PushAsync<AboutViewModel>();
        }

        async void ExecuteSearchCommand()
        {
            await PushAsync<SearchViewModel>(_iMonkeyHubApiService);
        }
        
        async void ExecuteShowCategoriaCommand(Tag tag)
        {
            await PushAsync<CategoriaViewModel>(_iMonkeyHubApiService, tag);
        }


        public async Task LoadAsync()
        {         
            var tags = await _iMonkeyHubApiService.GetTagsAsync();

            Results.Clear();
            foreach (var tag in tags)
            {
                Results.Add(tag);
            }

            OnPropertyChanged(nameof(Results));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonkeyHubApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuDraw : ContentPage
    {
        public ListView ListMenu { get { return ListViewMenu; } }

        public MenuDraw()
        {
            InitializeComponent();
            this.BindingContext = new ViewModels.MenuDrawViewModel();
        }
    }
}
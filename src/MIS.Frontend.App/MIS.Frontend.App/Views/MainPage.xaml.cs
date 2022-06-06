using MIS.Frontend.App.ViewModels;
using Xamarin.Forms.Xaml;

namespace MIS.Frontend.App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage// : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
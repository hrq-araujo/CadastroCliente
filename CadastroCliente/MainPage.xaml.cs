using CadastroCliente.ViewModels;

namespace CadastroCliente
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel _viewModel;
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
            _viewModel = viewModel;
        }
    }

}

using CadastroCliente.ViewModels;

namespace CadastroCliente;

public partial class RegisterPageView : ContentPage
{
	RegisterPageViewModel _viewModel;
	public RegisterPageView(RegisterPageViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
		_viewModel = viewModel;
	}
}
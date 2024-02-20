using CadastroCliente.ViewModels;

namespace CadastroCliente;

public partial class UpdatePageView : ContentPage
{
	public UpdatePageView(UpdatePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
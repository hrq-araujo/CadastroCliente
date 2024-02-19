namespace CadastroCliente
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegisterPageView), typeof(RegisterPageView));
        }
    }
}

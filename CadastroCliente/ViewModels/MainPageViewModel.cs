using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CadastroCliente.Models;

namespace CadastroCliente.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> costumer; // mudar para <Costumer>:

        public MainPageViewModel()
        {
            costumer = new ObservableCollection<string>(); // <Costumer>

            Costumer basicCostumers = new Costumer();
            basicCostumers.Name = "Henrique";

            costumer.Add("teste"); //vai ser as bases de um costumer
        }


        [RelayCommand]
        async Task RegisterClicked()
        {
            Console.WriteLine("yeah");

            await Shell.Current.GoToAsync(nameof(RegisterPageView));
        }
    }
}

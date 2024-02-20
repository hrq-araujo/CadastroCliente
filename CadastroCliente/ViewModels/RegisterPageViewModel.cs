using CadastroCliente.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.ViewModels
{
    [QueryProperty(nameof(Costumer), nameof(Costumer))]
    [QueryProperty(nameof(MainPageViewModel), nameof(MainPageViewModel))]
    public partial class RegisterPageViewModel : ObservableObject
    {
        [ObservableProperty]
        Costumer costumer;

        [ObservableProperty]
        MainPageViewModel mainPageViewModel;

        [ObservableProperty]
        bool isDeleteButtonEnabled = true;

        [ObservableProperty]
        int cancelButtonColumnSpan = 1;

        public RegisterPageViewModel()
        {
            this.costumer = Costumer;


            if (Costumer == null )
            {
                isDeleteButtonEnabled = false;
                cancelButtonColumnSpan = 2;
            }
            else
            {
                isDeleteButtonEnabled = true;
                cancelButtonColumnSpan = 1;
            }
        }

        [RelayCommand]
        async Task Delete()
        {
            //Console.WriteLine(costumer.Name);
            //MainPageViewModel mainViewModel;
            //mainViewModel.costumers.Remove(costumer);
            Console.WriteLine(this.mainPageViewModel.Costumers.IndexOf(costumer));
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task GoBack()
        {
            //Console.WriteLine(costumer.Name);
            Console.WriteLine(this.mainPageViewModel.Costumers.IndexOf(costumer));
            await Shell.Current.GoToAsync("..");
        }
    }
}

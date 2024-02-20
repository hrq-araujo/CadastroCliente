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
    public partial class UpdatePageViewModel : ObservableObject
    {
        [ObservableProperty]
        Costumer costumer;

        [ObservableProperty]
        MainPageViewModel mainPageViewModel;

        [ObservableProperty]
        Entry nameEntry;

        [RelayCommand]
        async Task Delete()
        {
            mainPageViewModel.Costumers.Remove(costumer);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task Update()
        {
            int index = mainPageViewModel.Costumers.IndexOf(costumer);
            Costumer costumerUpdated = new Costumer
            {
                Name = nameEntry.Text
            };

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

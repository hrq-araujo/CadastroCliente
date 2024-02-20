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


        public UpdatePageViewModel()
        {
            
        }

        [RelayCommand]
        async Task Delete()
        {
            await GeneralHelper.ConfirmDeleteAlert();
            if (GeneralHelper.confirmDelete) 
            { 
                mainPageViewModel.Costumers.Remove(costumer);
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        async Task Update()
        {
            if (CheckIfEntryIsEmpty())
            {
                if (CheckIfNumberIsValid()) { 
                    UpdateCostumerList();
                    await Shell.Current.GoToAsync("..");
                }
                else
                    await GeneralHelper.InvalidInputAlert();
            }
            else
                await GeneralHelper.EmptyInputAlert();
        }

        [RelayCommand]
        async Task GoBack()
        {
            Console.WriteLine(mainPageViewModel.costumers[0].Name);
            await Shell.Current.GoToAsync("..");
        }

        private bool CheckIfEntryIsEmpty() => !String.IsNullOrEmpty(costumer.Name) && !String.IsNullOrEmpty(costumer.LastName) && !String.IsNullOrEmpty(costumer.Address);

        private bool CheckIfNumberIsValid()
        {
            if(costumer.Age >= 0 && costumer.Age < 130)
                return true;
            else
                return false;
        }

        private void UpdateCostumerList()
        {
            int index = mainPageViewModel.Costumers.IndexOf(costumer);
            mainPageViewModel.Costumers[index] = costumer;
        }
    }
}

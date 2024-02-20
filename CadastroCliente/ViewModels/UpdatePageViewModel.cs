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
            if (IsEntryEmpty() && IsNumberValid() && !EntryContainsNumber())
            {
                UpdateCostumerList();
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        async Task GoBack()
        {
            Console.WriteLine(mainPageViewModel.costumers[0].Name);
            await Shell.Current.GoToAsync("..");
        }

        #region ENTRY QUALITY METHODS
        private bool IsEntryEmpty() 
        { 
            if(!String.IsNullOrEmpty(costumer.Name) && !String.IsNullOrEmpty(costumer.LastName) && !String.IsNullOrEmpty(costumer.Address))
                return true;
            else {
                GeneralHelper.EmptyInputAlert();
                return false;
            }
        }

        private bool EntryContainsNumber()
        {
            if (costumer.Name.Any(char.IsDigit) || costumer.LastName.Any(char.IsDigit))
            {
                GeneralHelper.InvalidTextInputAlert();
                return true;
            }
            else
                return false;
        }

        private bool IsNumberValid()
        {
            if(costumer.Age >= 0 && costumer.Age < 130)
                return true;
            else 
            {
                GeneralHelper.InvalidNumericalInputAlert();
                return false;
            }
        }
        #endregion

        private void UpdateCostumerList()
        {
            int index = mainPageViewModel.Costumers.IndexOf(costumer);
            mainPageViewModel.Costumers[index] = costumer;
        }
    }
}

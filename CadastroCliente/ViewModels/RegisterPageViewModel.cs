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

    [QueryProperty(nameof(MainPageViewModel), nameof(MainPageViewModel))]
    public partial class RegisterPageViewModel : ObservableObject
    {
        [ObservableProperty]
        MainPageViewModel mainPageViewModel;

        [ObservableProperty]
        public string newName;

        [ObservableProperty]
        string newLastName;

        [ObservableProperty]
        int newAge;

        [ObservableProperty]
        string newAddress;

        Costumer newCostumer;

        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task Save()
        {
            if (IsEntryEmpty() && IsNumberValid() && !EntryContainsNumber())
            {
                newCostumer = new Costumer
                {
                    Name = newName,
                    LastName = newLastName,
                    Address = newAddress,
                    Age = newAge
                };
                mainPageViewModel.costumers.Add(newCostumer);

                await Shell.Current.GoToAsync("..");
            }
        }

        private bool IsEntryEmpty()
        {
            if (!String.IsNullOrEmpty(NewName) && !String.IsNullOrEmpty(NewLastName) && !String.IsNullOrEmpty(NewAddress))
                return true;
            else
            {
                GeneralHelper.EmptyInputAlert();
                return false;
            }
        }

        private bool EntryContainsNumber()
        {
            if (NewName.Any(char.IsDigit) || NewLastName.Any(char.IsDigit))
            {
                GeneralHelper.InvalidTextInputAlert();
                return true;
            }
            else
                return false;
        }

        private bool IsNumberValid()
        {
            if (NewAge >= 0 && NewAge < 130)
                return true;
            else
            {
                GeneralHelper.InvalidNumericalInputAlert();
                return false;
            }
        }
    }
}

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


        public RegisterPageViewModel()
        {
        }



        [RelayCommand]
        async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task Save()
        {
            if (CheckIfEntryIsEmpty())
            {
                if (CheckIfNumberIsValid())
                {
                    newCostumer = new Costumer 
                    {
                        Name = newName,
                        LastName= newLastName,
                        Address = newAddress,
                        Age = newAge
                    };
                    mainPageViewModel.costumers.Add(newCostumer);

                    await Shell.Current.GoToAsync("..");
                }
                else
                    await GeneralHelper.InvalidInputAlert();
            }
            else
                await GeneralHelper.EmptyInputAlert();
        }

        private bool CheckIfEntryIsEmpty() => !String.IsNullOrEmpty(newName) && !String.IsNullOrEmpty(newLastName) && !String.IsNullOrEmpty(NewAddress);

        private bool CheckIfNumberIsValid()
        {
            if (NewAge >= 0 && NewAge < 130)
                return true;
            else
                return false;
        }
    }
}

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
        public ObservableCollection<Costumer> costumers;

        public MainPageViewModel()
        {
            costumers = new ObservableCollection<Costumer>();
            AddBaseCostumers();
        }

        private void AddBaseCostumers()
        {
            costumers = new ObservableCollection<Costumer> {
                new Costumer
                {
                    Name = "Henrique",
                    LastName = "Araujo",
                    Age = 24,
                    Address = "Av Parana, 1627"
                },
                new Costumer
                {
                    Name = "Caroline",
                    LastName = "Pintinha",
                    Age = 23,
                    Address = "Av Campos Sales, 299"
                }
            };
        }

        [RelayCommand]
        async Task RegisterClicked()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPageView),
                new Dictionary<string, object>
                {
                    ["MainPageViewModel"] = this
                }
                );
        }

        [RelayCommand]
        async Task CostumerClicked(Costumer selectedCostumer)
        {
            if (selectedCostumer is null)
                return;
            else
            {
                await Shell.Current.GoToAsync(nameof(UpdatePageView),
                new Dictionary<string, object>
                {
                    ["Costumer"] = selectedCostumer,
                    ["MainPageViewModel"] = this
                }
                );
            }
        }
    }
}

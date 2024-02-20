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
        public ObservableCollection<string> costumerList;

        [ObservableProperty]
        public ObservableCollection<Costumer> costumers;

        private Costumer selectedCostumer;
        public Costumer SelectedCostumer
        {
            get
            {
                return selectedCostumer;
            }
            set
            {
                if(selectedCostumer != value)
                {
                    selectedCostumer = value;
                    OnPropertyChanged("SelectedCostumer");

                    if(SelectedCostumer != null)
                    {
                        UpdateCostumerNavigation(SelectedCostumer, this);
                    }
                }
            }
        }

        public MainPageViewModel()
        {
            costumers = new ObservableCollection<Costumer>();
            costumerList = new ObservableCollection<string>();
            AddBaseCostumers();
            UpdateList();
        }

        public void UpdateList()
        {
            foreach (Costumer c in costumers)
            {
                costumerList.Add(c.Name);
            }
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
            await Shell.Current.GoToAsync(nameof(RegisterPageView));
        }

        public async void UpdateCostumerNavigation(Costumer costumer, MainPageViewModel mainPageViewModel)
        {
            await Shell.Current.GoToAsync(nameof(RegisterPageView), 
            new Dictionary<string, object>
            {
                ["Costumer"] = costumer,
                ["MainPageViewModel"] = mainPageViewModel
            }
            );
        }


    }
}

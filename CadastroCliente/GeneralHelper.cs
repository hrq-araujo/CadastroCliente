using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente
{
    public static class GeneralHelper
    {
        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static async Task InvalidInputAlert()
        {
            await Shell.Current.CurrentPage.DisplayAlert(
                "Erro",
                "Você inseriu algum caractere inválido. Lembre-se que as entradas só aceitam números inteiros positivos.",
                "OK");
        }

        public static async Task EmptyInputAlert()
        {
            await Shell.Current.CurrentPage.DisplayAlert(
                "Erro",
                "Você esqueceu de preencher algum campo. Lembre-se que todos os campos devem ser preenchidos.",
                "OK");
        }

        public static bool confirmDelete { get; set; }
        public static async Task ConfirmDeleteAlert()
        {
            confirmDelete = await Shell.Current.CurrentPage.DisplayAlert(
                "Alerta!",
                "Você tem certeza que deseja excluir o registro deste cliente?",
                "Sim", "Não");
        }
    }
}

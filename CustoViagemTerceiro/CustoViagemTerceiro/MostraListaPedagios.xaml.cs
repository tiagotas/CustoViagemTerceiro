using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CustoViagemTerceiro.Model;

namespace CustoViagemTerceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostraListaPedagios : ContentPage
    {
        App PropriedadesApp;

        public MostraListaPedagios()
        {
            InitializeComponent();

            // Acessando as propriedades da classe App.
            PropriedadesApp = (App)Application.Current;


            // Abastecendo o ListView com o Array de Objetos da classe App
            lst_lista_pedagios.ItemsSource = PropriedadesApp.lista_pedagios;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Usando a Linq para somar o valor dos pedágios.
                double valor_total_pedagios = PropriedadesApp.lista_pedagios.Sum(item => item.Valor);


                // Usando string.Format para montar a mensagem para o usuário.
                string mensagem = string.Format(
                    "Custará {0} de pedágios.", 
                    valor_total_pedagios.ToString("C")
                );


                // Mostrando a mensagem.
                DisplayAlert("Valor dos Pedágios", mensagem, "OK");

            } catch(Exception ex)
            {
                DisplayAlert("Oooops", ex.Message, "OK");
            }
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Qual foi a linha que disparou o menu de contexto.
                MenuItem disparador = sender as MenuItem;

                // Qual item da lista estava dentro da linha.
                Pedagio pedagio_selecionado = (Pedagio)disparador.BindingContext;

                // Mensagem de Confirmação do usuário.
                bool confirm = await DisplayAlert("Tem Certeza?", "Remover o Pedágio?", "Sim", "Não");

                if(confirm)
                {
                    // Remove o item do Array de Objetos fazendo uma busca.
                    PropriedadesApp.lista_pedagios.RemoveAll(i => i.NumeroPedagio == pedagio_selecionado.NumeroPedagio);

                    // Hack
                    lst_lista_pedagios.ItemsSource = new List<Pedagio>();

                    // Recarregando a ListView com os novos valores do Array de Objetos.
                    lst_lista_pedagios.ItemsSource = PropriedadesApp.lista_pedagios;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oooops", ex.Message, "OK");
            }
        }
    }
}
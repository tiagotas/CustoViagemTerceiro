using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using CustoViagemTerceiro.Model;

namespace CustoViagemTerceiro
{
    public partial class MainPage : ContentPage
    {
        App PropriedadesApp;

        public MainPage()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new MostraListaPedagios());

            } catch(Exception ex)
            {
                DisplayAlert("Oooops", ex.Message, "OK");
            }
        }

        private async void Button_Limpar_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool confirm = await DisplayAlert("Tem Certeza?", "Limpar todos os campos?", "Sim", "Não");

                if(confirm)
                {              
                    txt_consumo.Text = "";
                    txt_destino.Text = "";
                    txt_distancia.Text = "";
                    txt_localizacao.Text = "";
                    txt_origem.Text = "";
                    txt_valor_combustivel.Text = "";
                    txt_valor_pedagio.Text = "";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Oooops", ex.Message, "OK");
            }
        }

        private void Button_Add_Pedagio_Clicked(object sender, EventArgs e)
        {
            try
            {
                // Criando o objeto pedágio que será adicionado à lista.
                Pedagio p = new Pedagio();
                p.NumeroPedagio = PropriedadesApp.lista_pedagios.Count + 1;
                p.Localizacao = txt_localizacao.Text;
                p.Valor = Convert.ToDouble(txt_valor_pedagio.Text);


                // Adicionando o pedágio recém criado à lista de pedágios
                PropriedadesApp.lista_pedagios.Add(p);

                DisplayAlert("Deu certo!", "Pedágio Adicionado na Lista", "OK");

                txt_localizacao.Text = "";
                txt_valor_pedagio.Text = "";

            } catch (Exception ex)
            {
                DisplayAlert("Oooops", ex.Message, "OK");
            }
        }

        private void Button_Calcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                double distancia = Convert.ToDouble(txt_distancia.Text);
                double consumo = Convert.ToDouble(txt_consumo.Text);
                double preco_combustivel = Convert.ToDouble(txt_valor_combustivel.Text);

                // Definindo o valor do gasto com combustivel.
                double gasto_combustivel = (distancia / consumo) * preco_combustivel;

                // Somando o valor de todos os pedágios com Sum (biblioteca LINQ).
                double gasto_pedagio = PropriedadesApp.lista_pedagios.Sum(i => i.Valor);

                // Soma do custo total da viagem.
                double gasto_total = gasto_combustivel + gasto_pedagio;

                string msg = string.Format(
                    "Você irá gastar na viagem entre {0} até {1}: \n - Custará {2} \n - Combustível {3} \n - Pedágio {4} ",
                    txt_origem.Text,
                    txt_destino.Text,
                    gasto_total.ToString("C"),
                    gasto_combustivel.ToString("C"),
                    gasto_pedagio.ToString("C")
                 );

                DisplayAlert("Custo da Viagem", msg, "OK");

            } catch (Exception ex)
            {
                DisplayAlert("Ooops!", ex.Message, "OK");
            }
        }
    }
}

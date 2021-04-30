using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustoViagemTerceiro
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
    }
}

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.Generic;
using CustoViagemTerceiro.Model;
using System.Globalization;

namespace CustoViagemTerceiro
{
    public partial class App : Application
    {
        public List<Pedagio> lista_pedagios = new List<Pedagio>();


        public App()
        {
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

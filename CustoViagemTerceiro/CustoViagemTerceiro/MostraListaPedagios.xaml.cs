using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustoViagemTerceiro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostraListaPedagios : ContentPage
    {
        public MostraListaPedagios()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }
}
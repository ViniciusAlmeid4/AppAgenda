using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAgenda.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : MasterDetailPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
        }

        private void btHome_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageHome());
            IsPresented = false;
        }

        private void btCadastrar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageCadastro());
            IsPresented = false;
        }

        private void btListar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageLista());
            IsPresented = false;
        }

        private void btSobre_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageMeusDados());
            IsPresented = false;
        }
    }
}
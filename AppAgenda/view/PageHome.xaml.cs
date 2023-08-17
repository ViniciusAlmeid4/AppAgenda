using AppAgenda.control;
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
    public partial class PageHome : ContentPage
    {
        public PageHome()
        {
            InitializeComponent();

            Refresh();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastro());
            p.IsPresented = true;
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageLista());
            p.IsPresented = true;
        }

        public void Refresh()
        {
            String nome = "";
            ControlDBAgenda dbAgenda = new ControlDBAgenda(App.DbPath);
            ListaNotas.ItemsSource = dbAgenda.Localizar(nome);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
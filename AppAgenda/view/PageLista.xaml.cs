using AppAgenda.control;
using AppAgenda.model;
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
    public partial class PageLista : ContentPage
    {
        public PageLista()
        {
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            String nome = "";
            if (txtNota.Text != null) nome = txtNota.Text;
            ControlDBAgenda dbAgenda = new ControlDBAgenda(App.DbPath);
            if (swFavorito.IsToggled)
            {
                ListaNotas.ItemsSource = dbAgenda.Localizar(nome, true);
            }
            else
            {
                ListaNotas.ItemsSource = dbAgenda.Localizar(nome);
            }
        }

        private void btLocalizar_Clicked(object sender, EventArgs e)
        {
            Refresh();
        }

        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelAgenda nota = (ModelAgenda)ListaNotas.SelectedItem;
            //Chamada da PageCadastrar
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastro(nota));
        }

        private void swFavorito_Toggled(object sender, ToggledEventArgs e)
        {
            Refresh();
        }
    }
}
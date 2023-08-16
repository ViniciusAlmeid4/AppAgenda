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
    public partial class PageCadastro : ContentPage
    {
        public PageCadastro()
        {
            InitializeComponent();
        }

        public PageCadastro(ModelAgenda mdlAgenda)
        {
            InitializeComponent();
            btSalvar.Text = "Alterar";
            txtCodigo.IsVisible = true;
            btExcluir.IsVisible = true;
            txtCodigo.Text = mdlAgenda.Id.ToString();
            txtNome.Text = mdlAgenda.Nome;
            txtNumero.Text = mdlAgenda.Celular;
            swFavoritos.IsToggled = mdlAgenda.Favorito;
        }

        private void btSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ModelAgenda agenda = new ModelAgenda();
                agenda.Nome = txtNome.Text;
                agenda.Celular = txtNumero.Text;
                agenda.Favorito = swFavoritos.IsToggled;  
                ControlDBAgenda dbAgenda = new ControlDBAgenda(App.DbPath);
                if (btSalvar.Text == "Inserir")
                {
                    dbAgenda.Inserir(agenda);
                    DisplayAlert("Resultado", dbAgenda.StatusMessage, "OK");
                }
                else
                {
                    //Alterar uma nota
                    agenda.Id = Convert.ToInt32(txtCodigo.Text);
                    dbAgenda.Alterar(agenda);
                    DisplayAlert("Nota alterado com sucesso", dbAgenda.StatusMessage, "OK");
                }
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageHome());
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private async void btExcluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Excluir registro", "Deseja excluir a nota atual?", "Sim", "Não");
            if (resp == true)
            {
                ControlDBAgenda dBAgenda = new ControlDBAgenda(App.DbPath);
                int id = Convert.ToInt32(txtCodigo.Text);
                dBAgenda.Excluir(id);
                DisplayAlert("Nota excluída com sucesso", dBAgenda.StatusMessage, "OK");
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageHome());
            }
        }

        private void btCancelar_Clicked_1(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageHome());
        }
    }
}
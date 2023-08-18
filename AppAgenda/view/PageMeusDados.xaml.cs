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
    public partial class PageMeusDados : ContentPage
    {
        public PageMeusDados()
        {
            InitializeComponent();
            ControlDBAgenda db = new ControlDBAgenda(App.DbPath);
            if (db.VerificaMeusDados() == true) 
            {
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageHome());

                var MeusDados = db.ListarMeusDados();


            }
        }

        private void imgCadastraMeuDado_Tapped(object sender, EventArgs e)
        {
            try
            {
                ModelMeusDados md = new ModelMeusDados();
                md.Nome = txtMeuNome.Text;
                md.Celular = txtMeuNome.Text;
                ControlDBAgenda dbAgenda = new ControlDBAgenda(App.DbPath);
                dbAgenda.InsereMeusDados(md);
                DisplayAlert("Resultado", dbAgenda.StatusMessage, "OK");
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageHome());
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void imgAlteraMeuDado_Tapped(object sender, EventArgs e)
        {
            ModelMeusDados md = new ModelMeusDados();
            md.Nome = txtMeuNome.Text;
            md.Celular = txtMeuNome.Text;
            ControlDBAgenda dbAgenda = new ControlDBAgenda(App.DbPath);
            md.Id = 1;
            dbAgenda.AlteraMeusDados(md);
            DisplayAlert("Nota alterado com sucesso", dbAgenda.StatusMessage, "OK");
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageHome());
        }
    }
}
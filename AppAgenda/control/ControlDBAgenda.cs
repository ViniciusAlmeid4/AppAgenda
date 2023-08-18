using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using AppAgenda.model;
using SQLitePCL;

namespace AppAgenda.control
{
    public class ControlDBAgenda
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public ControlDBAgenda(string dbPath)
        {
            try
            {
                if (dbPath == "") dbPath = App.DbPath;
                conn = new SQLiteConnection(dbPath);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            conn.CreateTable<ModelAgenda>();
        }

        public void Inserir(ModelAgenda agenda)
        {
            try
            {
                if (string.IsNullOrEmpty(agenda.Nome))
                    throw new Exception("Nome agenda não informado!");
                if (string.IsNullOrEmpty(agenda.Celular))
                    throw new Exception("Celular da agenda não informado!");
                int result = conn.Insert(agenda);
                if (result != 0)
                {
                    this.StatusMessage = string.Format("{0} registro adicionado: {1}", result, agenda.Nome);
                }
                else
                {
                    this.StatusMessage = string.Format("Registro não foi adicionado!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ModelAgenda> Listar()
        {
            List<ModelAgenda> lista = new List<ModelAgenda>();
            try
            {
                lista = conn.Table<ModelAgenda>().ToList();
                this.StatusMessage = "Listagem da Agenda";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }

        public void Alterar(ModelAgenda agenda)
        {
            try
            {
                if (string.IsNullOrEmpty(agenda.Nome))
                    throw new Exception("Nome agenda não informado!");
                if (string.IsNullOrEmpty(agenda.Celular))
                    throw new Exception("Celular da agenda não informado!");
                if (agenda.Id <= 0)
                    throw new Exception("Id não informado!");
                int result = conn.Update(agenda);
                StatusMessage = string.Format("{0} registro alterado!", result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public void Excluir(int id)
        {
            try
            {
                int result = conn.Table<ModelAgenda>().Delete(r => r.Id == id);
                StatusMessage = string.Format("{0} registro deletado!", result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public List<ModelAgenda> Localizar(string titulo)
        {
            List<ModelAgenda> lista = new List<ModelAgenda>();
            try
            {
                var resp = from p in conn.Table<ModelAgenda>() where p.Nome.ToLower().Contains(titulo.ToLower()) select p;
                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
            return lista;
        }

        public List<ModelAgenda> Localizar(string titulo, Boolean favorito)
        {
            List<ModelAgenda> lista = new List<ModelAgenda>();
            try
            {
                var resp = from p in conn.Table<ModelAgenda>() where p.Nome.ToLower().Contains(titulo.ToLower()) && p.Favorito == favorito select p;
                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
            return lista;
        }

        public ModelAgenda GetNota(int id)
        {
            ModelAgenda m = new ModelAgenda();
            try
            {
                m = conn.Table<ModelAgenda>().First(n => n.Id == id);
                StatusMessage = "Pessoa encontrada!";
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
            return m;
        }

        public void InsereMeusDados(ModelMeusDados md)
        {
            try
            {
                if (string.IsNullOrEmpty(md.Nome))
                    throw new Exception("Nome agenda não informado!");
                if (string.IsNullOrEmpty(md.Celular))
                    throw new Exception("Celular da agenda não informado!");
                int result = conn.Insert(md);
                if (result != 0)
                {
                    this.StatusMessage = string.Format("{0} registro adicionado: {1}", result, md.Nome);
                }
                else
                {
                    this.StatusMessage = string.Format("Registro não foi adicionado!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AlteraMeusDados(ModelMeusDados md)
        {
            try
            {
                if (string.IsNullOrEmpty(md.Nome))
                    throw new Exception("Nome agenda não informado!");
                if (string.IsNullOrEmpty(md.Celular))
                    throw new Exception("Celular da agenda não informado!");
                int result = conn.Update(md);
                StatusMessage = string.Format("{0} registro alterado!", result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        public bool VerificaMeusDados()
        {
            ModelMeusDados m = new ModelMeusDados();
            try
            {
                m = conn.Table<ModelMeusDados>().First(n => n.Id == 1);
                StatusMessage = "Pessoa encontrada!";
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
            if (m.Id == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ModelMeusDados> ListarMeusDados()
        {
            List<ModelMeusDados> lista = new List<ModelMeusDados>();
            try
            {
                lista = conn.Table<ModelMeusDados>().ToList();
                this.StatusMessage = "Listagem dos Meus Dados";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }
    }
}

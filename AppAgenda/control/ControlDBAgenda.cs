using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using AppAgenda.model;

namespace AppAgenda.control
{
    public class ControlDBAgenda
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public ControlDBAgenda(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath);
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
                    this.StatusMessage = string.Format("{0} registro adicionado:[Agenda: {1}]", result, agenda.Nome);
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
    }
}

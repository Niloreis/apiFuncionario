using ApiFuncionarios.Data.Contexts;
using ApiFuncionarios.Data.Entities;
using ApiProdutos.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiFuncionarios.Data.Repositories
{
    /// </summary>
    public class EmpresaRepository : IRepository<Empresa>
    {

        /// <summary>
        /// Repositório de dados para Categoria
        /// </summary>

        public void Add(Empresa entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Empresas.Add(entity);
                dataContext.SaveChanges();
            }

        }

        public void Delete(Empresa entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Empresas.Remove(entity);
                dataContext.SaveChanges();
            }

        }

        public List<Empresa> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Empresas
                    .OrderBy(e =>e.NomeFantasia )
                    .ToList();
            }

        }

        public Empresa GetById(Guid? id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Empresas
                    .Where(e => e.IdEmpresa == id)
                    .FirstOrDefault();
            }

        }

        public void Update(Empresa entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }

        }
    }


}
   

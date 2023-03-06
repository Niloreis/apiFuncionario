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
    public class FuncionarioRepository : IRepository<Funcionario>
    {
        public void Add(Funcionario entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Funcionarios.Add(entity);
                dataContext.SaveChanges();
            }

        }

        public void Delete(Funcionario entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Funcionarios.Remove(entity);
                dataContext.SaveChanges();
            }

        }

        public List<Funcionario> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Funcionarios
                    .Include(f => f.Nome)
                    .OrderBy(f => f.Matricula)
                    .ToList();
            }

        }

        public Funcionario GetById(Guid? id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Funcionarios
                    .Include(f => f.Empresa)
                    .Where(f => f.IdFuncionario == id)
                    .FirstOrDefault();
            }

        }

        public void Update(Funcionario entity)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Entry(entity).State = EntityState.Modified;
                dataContext.SaveChanges();
            }

        }
    }
}

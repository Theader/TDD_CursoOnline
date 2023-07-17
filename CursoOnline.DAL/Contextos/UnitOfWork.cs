using CursoOnline.DAL.Contextos;
using CursoOnline.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoOnline.Dados.Contextos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }
    }
}

using CadastroDeProdutos.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CadastroDeProdutos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}

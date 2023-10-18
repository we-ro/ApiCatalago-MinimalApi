﻿using ApiCatalago.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalago.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Categoria
        public DbSet<Produto>? Produtos { get; set; }
        public DbSet<Categoria>? Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Categoria>().HasKey(c => c.CategoriaId);

            mb.Entity<Categoria>().Property(c=> c.Nome)
                                  .HasMaxLength(100)
                                  .IsRequired();

            //Produto

            mb.Entity<Categoria>().Property(c => c.Descricao)
                .HasMaxLength(150)
                .IsRequired();
                
            mb.Entity<Produto>().HasKey(c => c.ProdutoId);

            mb.Entity<Produto>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
            mb.Entity<Produto>().Property(c => c.Descricao).HasMaxLength(150);
            mb.Entity<Produto>().Property(c => c.Imagem).HasMaxLength(50);
            
            mb.Entity<Produto>().Property(c=> c.Preco).HasPrecision(14,2);

            //Relaciomento

            mb.Entity<Produto>()
                .HasOne<Categoria>(c=> c.Categoria)
                .WithMany(p=> p.Produtos)
                .HasForeignKey(c => c.CategoriaId);

        }
    }
}

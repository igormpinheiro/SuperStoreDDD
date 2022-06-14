using Microsoft.EntityFrameworkCore;
using SuperStoreDDD.Domain.Core.Interfaces;
using SuperStoreDDD.Domain.Entities;

namespace SuperStoreDDD.Infra.Data.Context;

public class DataContext : DbContext, IUnitOfWork
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<CupomDesconto> CuponsDescontos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
        //    property().SetColumnType("varchar(100)");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataModificacao").CurrentValue = DateTime.Now;
                entry.Property("DataCadastro").IsModified = false;
                entry.Property("CriadoPor").IsModified = false;
            }
        }
        return await base.SaveChangesAsync() > 0;
    }

    public Task Rollback()
    {
        return Task.CompletedTask;
    }
}
using Microsoft.EntityFrameworkCore;

namespace SuperStoreDDD.Infra.Data.Context;

public class DataContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
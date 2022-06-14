using SuperStoreDDD.Domain.Core.Interfaces;
using SuperStoreDDD.Domain.Entities;
using SuperStoreDDD.Infra.Data.Context;
using SuperStoreDDD.Infra.Data.Repositories.Base;

namespace SuperStoreDDD.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto, int>
    {
        public ProdutoRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
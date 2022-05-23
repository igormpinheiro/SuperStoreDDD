using SuperStoreDDD.Domain.Core.Interfaces;
using SuperStoreDDD.Domain.Entities;
using SuperStoreDDD.Infra.Data.Context;
using SuperStoreDDD.Infra.Data.Repositories.Base;

namespace SuperStoreDDD.Infra.Data.Repositories
{
    public class CupomDescontoRepository : RepositoryBase<CupomDesconto, Guid>
    {
        public CupomDescontoRepository(IUnitOfWork unitOfWork, DataContext dbContext) : base(unitOfWork, dbContext)
        {
        }
    }
}
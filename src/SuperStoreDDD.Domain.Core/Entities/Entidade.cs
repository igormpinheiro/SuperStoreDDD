using SuperStoreDDD.Domain.Core.Entities.Base;

namespace SuperStoreDDD.Domain.Core.Entities
{
    public abstract class Entidade<IdType> : EntidadeBase<IdType> where IdType : struct
    {
    }
}
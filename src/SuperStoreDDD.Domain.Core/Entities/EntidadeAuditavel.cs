using SuperStoreDDD.Domain.Core.Entities.Base;

namespace SuperStoreDDD.Domain.Core.Entities
{
    public abstract class EntidadeAuditavel<IdType> : EntidadeBase<IdType> where IdType : struct
    {
        public string CriadoPor { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public string ModificadoPor { get; private set; }
        public DateTime DataModificacao { get; private set; }

        //public EntidadeAuditavel(string criadoPor, DateTime dataCriacao, string alteradoPor, DateTime dataAleracao) : base()
        public EntidadeAuditavel(string usuario) : base()
        {
            CriadoPor = usuario;
            DataCriacao = DateTime.Now;
            ModificadoPor = usuario;
            DataModificacao = DateTime.Now;
        }

        protected EntidadeAuditavel()
        { }
    }
}
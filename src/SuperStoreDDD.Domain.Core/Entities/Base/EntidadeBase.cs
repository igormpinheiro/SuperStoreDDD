using Flunt.Notifications;

namespace SuperStoreDDD.Domain.Core.Entities.Base
{
    public abstract class EntidadeBase<IdType> : Notifiable<Notification> where IdType : struct
    {
        public IdType Id { get; private set; }

        protected EntidadeBase(IdType id)
        {
            var typeId = typeof(IdType);
            if (typeId.IsValueType && typeId.IsPrimitive)
                Id = id;
            else
                AddNotification("Id", "Id inválido");
        }

        protected EntidadeBase()
        {
            Validar();
        }

        #region BaseBehaviours

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntidadeBase<IdType>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(EntidadeBase<IdType> a, EntidadeBase<IdType> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntidadeBase<IdType> a, EntidadeBase<IdType> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 93) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        protected abstract void Validar();

        #endregion BaseBehaviours
    }
}
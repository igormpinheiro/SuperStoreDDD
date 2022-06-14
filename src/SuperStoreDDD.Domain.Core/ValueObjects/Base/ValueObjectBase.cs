using Flunt.Notifications;

namespace SuperStoreDDD.Domain.Core.ValueObjectBases.Base
{
    /// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects
    /// https://enterprisecraftsmanship.com/posts/value-object-better-implementation/
    public abstract class ValueObjectBase : Notifiable<Notification>
    {
        public virtual void Validar()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            var other = (ValueObjectBase)obj;

            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }
                
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(ValueObjectBase a, ValueObjectBase b)
        {
            return EqualOperator(a, b);
        }

        public static bool operator !=(ValueObjectBase a, ValueObjectBase b)
        {
            return NotEqualOperator(a, b);
        }

        protected static bool EqualOperator(ValueObjectBase left, ValueObjectBase right)
        {
            if (left is null ^ right is null)
                return false;

            return left is null || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObjectBase left, ValueObjectBase right)
        {
            return !EqualOperator(left, right);
        }
    }
}
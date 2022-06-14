using Flunt.Notifications;
using Flunt.Validations;
using SuperStoreDDD.Domain.Core.Entities;
using SuperStoreDDD.Domain.Core.ValueObjects;

namespace SuperStoreDDD.Domain.Entities
{
    public class Cliente : Entidade<int>
    {
        public NomeCompleto Nome { get; private set; }
        public Email Email { get; private set; }
        public CPF CPF { get; set; }
        public Endereco Endereco { get; private set; }
        public bool Ativo { get; private set; }

        public Cliente(NomeCompleto nome, Email email, CPF CPF, Endereco endereco) : base()
        {
            this.Nome = nome;
            this.Email = email;
            this.CPF = CPF;
            this.Endereco = endereco;
            this.Ativo = false;
            //Validar();
        }

        protected override void Validar()
        {
            //if (Nome != null)
            //    AddNotifications(Nome.Notifications);
            //if (Email != null)
            //    AddNotifications(Email.Notifications);
            //if (Endereco != null)
            //    AddNotifications(Endereco.Notifications);
            //if (CPF != null)
            //    AddNotifications(CPF.Notifications);
            AddNotifications(new Contract<Notification>()
                .Requires()
                .IsNotNull(Nome, "Nome", "Nome deve ser informado.")
                .IsNotNull(Email, "Email", "Email deve ser informado.")
                .IsNotNull(Endereco, "Endereco", "Endereco deve ser informado.")
                .IsNotNull(CPF, "CPF", "CPF deve ser informado.")
            );
            if (IsValid)
            {
                AddNotifications(Nome.Notifications);
                AddNotifications(Email.Notifications);
                AddNotifications(Endereco.Notifications);
                AddNotifications(CPF.Notifications);
            }
        }
    }
}
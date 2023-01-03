using Amaris.Consolidacao.Identity.Dtos;

namespace Amaris.Consolidacao.Domain.Entities
{
    public class UserEntity
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; } = string.Empty;
        public virtual string Email { get; protected set; } = string.Empty;
        public virtual bool EmailConfirmed { get; protected set; }
        public virtual string PhoneNumber { get; protected set; } = string.Empty;

        public void ModelToEntity(User model)
        {
            Name = model.Name;
            Email = model.Email;
            PhoneNumber = model.PhoneNumber;
        }
    }
}

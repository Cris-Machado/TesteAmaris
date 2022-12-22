using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amaris.Consolidacao.Domain.Entities
{
    public class UserEntity
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Name { get; protected set; } = string.Empty;
        public virtual string Email { get; protected set; } = string.Empty;
        public virtual bool EmailConfirmed { get; protected set; }
        public virtual string Password { get; protected set; } = string.Empty;
        public virtual string PhoneNumber { get; protected set; } = string.Empty;
    }
}

using SinavProje.Entities.Abstract.Entities.Base;
using SinavProje.Entities.Concrete.Entities.Base;

namespace SinavProje.Entities.Concrete.Entities
{
    public class User:Entity, IEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}

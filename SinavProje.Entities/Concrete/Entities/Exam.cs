using System;
using SinavProje.Entities.Abstract.Entities;
using SinavProje.Entities.Abstract.Entities.Base;
using SinavProje.Entities.Concrete.Entities.Base;

namespace SinavProje.Entities.Concrete.Entities
{
    public class Exam : Entity, IEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateTime { get; set; }
        
    }
}

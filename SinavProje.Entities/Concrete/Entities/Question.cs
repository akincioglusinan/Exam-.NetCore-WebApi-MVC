using SinavProje.Entities.Abstract.Entities.Base;
using SinavProje.Entities.Concrete.Entities.Base;

namespace SinavProje.Entities.Concrete.Entities
{
    public class Question : Entity, IEntity
    {
        public int ExamId { get; set; }
        public int QNumber { get; set; }
        public string Q { get; set; }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string Answer { get; set; }
    }
}

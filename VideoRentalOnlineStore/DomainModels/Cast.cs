using DomainModels.Enums;

namespace DomainModels
{
    public class Cast : BaseClass
    {
        public string MovieId { get; set; }
        public string Name { get; set; }
        public Part Part { get; set; }
    }
}

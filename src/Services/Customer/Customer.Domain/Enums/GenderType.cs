using SharedKernel.SeedWork;

namespace Customer.Domain.Enums
{
    public class GenderType : Enumeration
    {
        public static DocumentType Male = new(1, nameof(Male));
        public static DocumentType Female = new(2, nameof(Female));

        public GenderType(short id, string name)
            : base(id, name) { }
    }
}
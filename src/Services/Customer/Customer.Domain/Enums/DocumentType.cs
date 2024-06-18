using SharedKernel.SeedWork;

namespace Customer.Domain.Enums
{
    public class DocumentType
        : Enumeration
    {
        public static DocumentType Dni = new(1, nameof(Dni));
        public static DocumentType Passport = new(2, nameof(Passport));
        public static DocumentType DIMEX = new(3, nameof(DIMEX));
        public static DocumentType SocialRasonNumber = new(4, nameof(SocialRasonNumber));

        public DocumentType(short id, string name)
            : base(id, name) { }
    }
}

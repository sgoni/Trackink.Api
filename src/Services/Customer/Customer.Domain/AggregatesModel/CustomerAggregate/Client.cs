using Customer.Domain.Enums;
using SharedKernel.SeedWork;

namespace Customer.Domain.AggregatesModel.CustomerAggregate
{
    public class Client : Entity, IAggregateRoot
    {
        public Client() { }

        public Client(string noDocument, string name, char gender, int documetTypeId, string mainPhone, string mobile, string email, bool isActive, Address address) : this()
        {

            NoDocument = noDocument.Replace('-', ' ').Trim();
            Name = name;
            Gender = gender == 'F' ? GenderType.Female.Name : GenderType.Male.Name;
            Phone = mainPhone;
            Mobile = mobile;
            Email = email;
            IsActive = isActive;

            switch (documetTypeId)
            {
                case 1:
                    DocumentTypeId = Enums.DocumentType.Dni.Id;
                    break;

                case 2:
                    DocumentTypeId = Enums.DocumentType.Passport.Id;
                    break;

                case 3:
                    DocumentTypeId = Enums.DocumentType.DIMEX.Id;
                    break;

                case 4:
                    DocumentTypeId = Enums.DocumentType.SocialRasonNumber.Id;
                    break;

                default:
                    break;
            }

            Address = address;  // Set address
        }

        public string NoDocument { get; set; }
        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }

        /// <summary>
        /// One to one relationship.
        /// Foreing key.
        /// </summary>
        public ParameterAggregate.Parameter DocumentType { get; set; }

        // Address is a Value Object pattern example persisted as EF Core 2.0 owned entity
        public Address Address { get; set; }

        public int GetDocumentType(int value)
        {
            int retVal = Enums.DocumentType.Dni.Id;

            switch (value)
            {
                case 1:
                    retVal = Enums.DocumentType.Dni.Id;
                    break;

                case 2:
                    retVal = Enums.DocumentType.Passport.Id;
                    break;

                case 3:
                    retVal = Enums.DocumentType.DIMEX.Id;
                    break;

                case 4:
                    retVal = Enums.DocumentType.SocialRasonNumber.Id;
                    break;

                default:
                    break;
            }

            return retVal;
        }
    }
}

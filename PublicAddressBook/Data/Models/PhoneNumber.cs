namespace PublicAddressBook.Data.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public static PhoneNumber Create(string number, bool isActive, Contact contact)
        {
            if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number) || contact == null)
            {
                return null;
            }
            else
            {
                return new PhoneNumber { Contact = contact, ContactId = contact.Id, IsActive = isActive, Number = number };
            }
        }
    }

}
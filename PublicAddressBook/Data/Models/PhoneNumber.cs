namespace PublicAddressBook.Data.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsActive { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
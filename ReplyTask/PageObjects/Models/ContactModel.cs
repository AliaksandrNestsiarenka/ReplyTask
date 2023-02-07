using ReplyTask.Enums;

namespace ReplyTask.PageObjects.Models
{
    public class ContactModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public List<ContactCategory> ContactCategories { get; set; } = new List<ContactCategory>();

        public ContactBusinessRole BusinessRole { get; set; } 
    }
}

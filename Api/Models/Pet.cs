using System.Collections.Generic;

namespace PetStore6.Api.Models
{
    public class Pet 
    {
        public long Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> PhotoUrls { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public string Status { get; set; }

        public Pet(long id, Category category, string name, IEnumerable<string> photoUrls, IEnumerable<Tag> tags, string status)
        {
            Id = id;
            Category = category;
            Name = name;
            PhotoUrls = photoUrls;
            Tags = tags;
            Status = status;
        }

        public static bool operator == (Pet left, Pet right)
        {
            bool comparison = true; 
            return comparison;
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !(left == right);
        }
    }
}

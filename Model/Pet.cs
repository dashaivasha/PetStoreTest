using System.Collections.Generic;

namespace PetStore6.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> PhotoUrls { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
        public string Status { get; set; }

        public Pet(int id, Category category, string name, IEnumerable<string> photoUrls, IEnumerable<Tag> tags, string status)
        {
            Id = id;
            Category = category;
            Name = name;
            PhotoUrls = photoUrls;
            Tags = tags;
            Status = status;
        }

        public override bool Equals(object? obj)
        {
            return obj is Pet pet &&
                   Id == pet.Id &&
                   EqualityComparer<Category>.Default.Equals(Category, pet.Category) &&
                   Name == pet.Name &&
                   EqualityComparer<IEnumerable<string>>.Default.Equals(PhotoUrls, pet.PhotoUrls) &&
                   EqualityComparer<IEnumerable<Tag>>.Default.Equals(Tags, pet.Tags) &&
                   Status == pet.Status;
        }
    }
}

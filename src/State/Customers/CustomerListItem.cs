using System.Collections.Immutable;
using RudderExample.Database;

namespace RudderExample.State.Customers
{
    public class CustomerListItem
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public ImmutableList<string> Tags { get; set; }

        public bool IsFetching { get; set; }
    }

    public static class CustomerListItemMappers
    {
        public static CustomerListItem MapToListItem(this CustomerEntity entity) =>
            new CustomerListItem
            {
                Id = entity.Id,
                Email = entity.Email,
                MobileNumber = entity.MobileNumber,
                Name = entity.Name,
                Tags = entity.Tags.ToImmutableList()
            };
    }
}
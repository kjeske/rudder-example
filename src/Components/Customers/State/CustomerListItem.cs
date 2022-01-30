using System.Collections.Generic;
using System.Linq;
using RudderExample.Database;

namespace RudderExample.Components.Customers.State;

public record CustomerListItem
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string MobileNumber { get; init; }
    public string Email { get; init; }
    public IReadOnlyList<string> Tags { get; init; }
    public bool IsFetching { get; init; }
}

public static class CustomerListItemMappers
{
    public static CustomerListItem MapToListItem(this CustomerEntity entity) => new()
    {
        Id = entity.Id,
        Email = entity.Email,
        MobileNumber = entity.MobileNumber,
        Name = entity.Name,
        Tags = entity.Tags.ToList()
    };
}
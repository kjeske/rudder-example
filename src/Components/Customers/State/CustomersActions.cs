namespace RudderExample.Components.Customers.State;

public static class CustomersActions
{
    public record FetchItems
    {
        public record Request;
        public record Success(CustomerListItem[] Items);
    }

    public record Remove(string Id)
    {
        public record Request(string Id);
        public record Success(string Id);
    }

    public record Add(string Name, string Email, string MobileNumber, string Tags)
    {
        public record Request;
        public record Success(CustomerListItem Item);
        public record Failure(string Error);
    }

    public struct AddDialog
    {
        public record Show;
        public record Hide;
    }
}
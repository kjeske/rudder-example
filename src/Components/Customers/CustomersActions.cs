using RudderExample.State;
using RudderExample.State.Customers;

namespace RudderExample.Components.Customers
{
    public static class CustomersActions
    {
        public struct FetchItems
        {
            public struct Invoke { }

            public struct Request { }

            public struct Success
            {
                public CustomerListItem[] Items { get; set; }
            }
        }

        public static class Remove
        {
            public struct Invoke
            {
                public string Id { get; set; }
            }

            public struct Request
            {
                public string Id { get; set; }
            }

            public struct Success
            {
                public string Id { get; set; }
            }
        }

        public static class Add
        {
            public struct Invoke
            {
                public string Name { get; set; }

                public string Email { get; set; }

                public string MobileNumber { get; set; }

                public string Tags { get; set; }
            }

            public struct Request { }

            public struct Success
            {
                public CustomerListItem Item { get; set; }
            }

            public struct Failure
            {
                public string Error { get; set; }
            }
        }

        public struct AddDialog
        {
            public struct Show { }

            public struct Hide { }
        }
    }
}

using RudderExample.Tools;

namespace RudderExample.Components.Customers.AddCustomer
{
    public class AddCustomerForm : Form
    {
        public AddCustomerForm()
        {
            Name = Field("", NotEmpty);

            Email = Field("", NotEmpty, CorrectEmail);

            MobileNumber = Field("", NotEmpty);

            Tags = Field("");
        }

        public string Id { get; set; }

        public Field<string> Name { get; }

        public Field<string> Email { get; }

        public Field<string> MobileNumber { get; }

        public Field<string> Tags { get; }

        public CustomersActions.Add.Invoke MapToAddAction() => new CustomersActions.Add.Invoke
        {
            Name = Name.Value,
            Email = Email.Value,
            MobileNumber = MobileNumber.Value,
            Tags = Tags.Value ?? ""
        };
    }
}

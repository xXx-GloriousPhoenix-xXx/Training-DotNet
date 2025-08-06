using Basics.Classes;
namespace Basics.Services;

public static class CustomerHandler
{
    public static Customer GenerateTemplateCustomer(int identifier)
    {
        var postfix = $"{identifier}";
        var address = AddressHandler.GenerateTemplateAddress(identifier);
        var customer = new Customer(
            $"Name_{postfix}",
            $"{postfix}@gmail.com",
            address
        );
        return customer;
    }
}

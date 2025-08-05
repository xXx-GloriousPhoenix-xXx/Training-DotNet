using Basics.Classes;
namespace Basics.Services;

public static class AddressHandler
{
    public static Address GeneratePatternAddress(int index_1, int index_2)
    {
        var postfix = $"{index_1}_{index_2}";
        var address = new Address(
            $"Country_{postfix}",
            $"City_{postfix}",
            $"Street_{postfix}",
            (ushort)(index_1 + index_2 + 1)
        );
        return address;
    }
}

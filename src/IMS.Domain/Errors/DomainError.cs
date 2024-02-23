using IMS.Domain.Shared;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleToAttribute("IMS.UnitTests")]
namespace IMS.Domain.Errors;
internal static class DomainError
{
    internal static class Brand
    {
        internal static Error MaximumLengthExceeded(string property, int length) => 
            new("", $"'{property}' property exceeds maximum character length: {length}");

        internal static Error InvalidName = new("", "Specify a valid brand name");
    }

    internal static class Product
    {
        internal static Error MaximumLengthExceeded(string property, int length) =>
            new("", $"'{property}' property exceeds maximum character length: {length}");

        internal static Error InvalidQuantity = new("", "Product quantity can not be less than 0");

        internal static Error InvalidPrice = new("", "Product price can not be less than 0");

        internal static Error InvalidName = new("", "Specify a valid product name");
        internal static Error InvalidStatus = new("", "Select a valid status enum. Unknown=0;SecondHand=1;Refurbished=2;New=3");
    }

    internal static class Category
    {
        internal static Error MaximumLengthExceeded(string property, int length) =>
            new("", $"'{property}' property exceeds maximum character length: {length}");

        internal static Error InvalidName = new("", "Specify a valid category name");
    }
}

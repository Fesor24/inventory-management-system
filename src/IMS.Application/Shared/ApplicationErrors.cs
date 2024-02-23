using IMS.Domain.Shared;

namespace IMS.Application.Shared;
internal static class ApplicationErrors 
{
    internal static class Product
    {
        internal static Error NOTFOUND(Guid id) => new(ApplicationStatusCodes.NOT_FOUND,
            $"Product with Id: {id} not found");

        internal static Error BADREQUEST(string message) => 
            new(ApplicationStatusCodes.BAD_REQUEST, message);
    }

    internal static class Brand
    {
        internal static Error NOTFOUND(Guid id) => new(ApplicationStatusCodes.NOT_FOUND,
            $"Brand with Id: {id} not found");

        internal static Error BADREQUEST(string message) =>
            new(ApplicationStatusCodes.BAD_REQUEST, message);
    }

    internal static class Category
    {
        internal static Error NOTFOUND(Guid id) => new(ApplicationStatusCodes.NOT_FOUND,
            $"Category with Id: {id} not found");

        internal static Error BADREQUEST(string message) =>
            new(ApplicationStatusCodes.BAD_REQUEST, message);
    }
}

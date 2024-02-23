using System.Runtime.Serialization;

namespace IMS.Domain.Entities.ProductAggregates;
public enum ProductStatus
{
    [EnumMember(Value = "Unknown")]
    Unknown,
    [EnumMember(Value = "SecondHand")]
    SecondHand,
    [EnumMember(Value = "Refurbished")]
    Refurbished,
    [EnumMember(Value = "New")]
    New
}

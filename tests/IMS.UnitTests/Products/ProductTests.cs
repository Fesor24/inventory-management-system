using AutoFixture;
using AutoMapper;
using FluentAssertions;
using FluentAssertions.Execution;
using IMS.Application.Features.Product.Queries.GetProduct;
using IMS.Application.Features.Product.Queries.GetProducts;
using IMS.Application.Mappings;
using IMS.Domain.Entities.ProductAggregates;
using IMS.Domain.Errors;
using IMS.Domain.Primitives;
using IMS.Infrastructure.Data.Specifications.ProductSpecifications;
using Moq;

namespace IMS.UnitTests.Products;
public class ProductTests
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Fixture _fixture;
    private readonly IMapper _mapper;

    public ProductTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _fixture = new Fixture();

        var mockMapper = new MapperConfiguration(mc =>
        {
            mc.AddMaps(typeof(ProductMappings).Assembly);
        }).CreateMapper().ConfigurationProvider;

        _mapper = new Mapper(mockMapper);
    }

    [Fact]
    public async Task GetProducts_ReturnProductList()
    {
        var products = _fixture.CreateMany<Product>(5).ToList();

        _unitOfWork.Setup(x => x.Repository<Product>()
        .GetAllAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(products);

        var request = new GetProductsRequest();

        var handler = new GetProductsRequestHandler(_unitOfWork.Object, _mapper);

        var res = await handler.Handle(request, default);

        using var _ = new AssertionScope();

        res.IsSuccess.Should().BeTrue();

        res.Value.Should().NotBeNullOrEmpty();

        res.Value.Count().Should().Be(5);
    }
}

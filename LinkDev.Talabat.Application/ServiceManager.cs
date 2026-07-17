using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Services;
using LinkDev.Talabat.Application.Common.Services;
using LinkDev.Talabat.Domain.Contracts.PersistenceLayer;

namespace LinkDev.Talabat.Application;

public class ServiceManager : IServiceManager
{
    #region Properties

    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly Lazy<IProductService> _productService;

    #endregion Properties

    public ServiceManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _productService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
    }

    // Note that : this property doesnot be intialized whether with the first access inside ctor
    public IProductService productService => _productService.Value; //automatic prop compiler will generate backing Field hidden private attribute
}
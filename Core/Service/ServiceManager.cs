using AutoMapper;
using Domain.Repositories;
using Service.Contracts;
using Services.LoggerService;
using Shared.DataTransferObjects;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {

        private readonly Lazy<IGraphicCardService> _graphicCardService;
        private readonly Lazy<IProcessorService> _processorService;


        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper,
            IDataShaper<GraphicCardDto> dataShaper)
        {
            _graphicCardService = new Lazy<IGraphicCardService>(() => new GraphicCardService(repositoryManager, logger, mapper, dataShaper));
            _processorService = new Lazy<IProcessorService>(() => new ProcessorService(repositoryManager, logger, mapper));
        }

        

        public IGraphicCardService GraphicCardService => _graphicCardService.Value;
        public IProcessorService ProcessorService => _processorService.Value;

    }
}

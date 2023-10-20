using AutoMapper;
using Shared.DataTransferObjects;
using Services.LoggerService;
using Service.Contracts;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.RequestFeatures;

namespace Services
{
    internal sealed class GraphicCardService : IGraphicCardService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public GraphicCardService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<GraphicCardDto> graphicCards, MetaData metaData)> GetAllGraphicCardsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var graphicCardsWithMetaData = await _repository.GraphicCard.GetAllGraphicCardsAsync(productParameters, trackChanges);
            var graphicCardsDto = _mapper.Map<IEnumerable<GraphicCardDto>>(graphicCardsWithMetaData);
            return (graphicCards: graphicCardsDto, metaData: graphicCardsWithMetaData.MetaData);
        }
        public async Task<GraphicCardDto> GetGraphicCardAsync(int id, bool trackChanges)
        {
            var graphicCard = await _repository.GraphicCard.GetGraphicCardAsync(id, trackChanges) ?? throw new ProductNotFoundException(id);
            var graphicCardDto = _mapper.Map<GraphicCardDto>(graphicCard);
            return graphicCardDto;
        }
    }

}

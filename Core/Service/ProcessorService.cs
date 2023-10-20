using AutoMapper;
using Domain.Exceptions;
using Domain.Repositories;
using Service.Contracts;
using Services.LoggerService;
using Shared.DataTransferObjects;

namespace Services
{
    internal sealed class ProcessorService : IProcessorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ProcessorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProcessorDto>> GetAllProcessorsAsync(bool trackChanges)
        {
            var processors = await _repository.Processor.GetAllProcessorsAsync(trackChanges);
            var processorsDto = _mapper.Map<IEnumerable<ProcessorDto>>(processors);
            return processorsDto;
        }
        public async Task<ProcessorDto> GetProcessorAsync(int id, bool trackChanges)
        {
            var processor = await _repository.Processor.GetProcessorAsync(id, trackChanges) ?? throw new ProductNotFoundException(id);
            var processorDto = _mapper.Map<ProcessorDto>(processor);
            return processorDto;
        }
    }
}

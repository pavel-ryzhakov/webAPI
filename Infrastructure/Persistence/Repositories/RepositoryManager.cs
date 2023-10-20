using Domain.Repositories;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager 
    { 
        private readonly RepositoryContext _repositoryContext; 
        private readonly Lazy<IGraphicCardRepository> _graphicCardrepository;
        private readonly Lazy<IProcessorRepository> _processorRepository;
        public RepositoryManager(RepositoryContext repositoryContext) 
        { 
            _repositoryContext = repositoryContext; 
            _graphicCardrepository = new Lazy<IGraphicCardRepository>(() => new GraphicCardRepository(repositoryContext));
            _processorRepository = new Lazy<IProcessorRepository>(() => new ProcessorRepository(repositoryContext)); 
        } 
        public IGraphicCardRepository GraphicCard  => _graphicCardrepository.Value; 
        public IProcessorRepository Processor => _processorRepository.Value;
        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}

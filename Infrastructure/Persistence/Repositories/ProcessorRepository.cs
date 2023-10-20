
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ProcessorRepository : RepositoryBase<Processor>, IProcessorRepository
    { 
        public ProcessorRepository (RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Processor>> GetAllProcessorsAsync(bool trackChanges) => 
            await FindAll(trackChanges).OrderBy(c => c.Price).ToListAsync();
        public async Task<Processor> GetProcessorAsync(int processorId, bool trackChanges) =>
            await FindByCondition(c => c.Id.Equals(processorId), trackChanges).SingleOrDefaultAsync();
    }
}

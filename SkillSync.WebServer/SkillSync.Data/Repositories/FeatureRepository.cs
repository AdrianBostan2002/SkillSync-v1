using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class FeatureRepository : RepositoryBase<Feature>, IFeatureRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public FeatureRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }
    }
}
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Project;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;

namespace SkillSync.Business.Services
{
    public class SkillCategoryService : ISkillCategoryService
    {
        private ISkillCategoryRepository _skillCategoryRepository;
        private readonly ICacheService _cacheService;
        private readonly IMapper _mapper;

        public SkillCategoryService(ISkillCategoryRepository skillCategoryService, ICacheService cacheService, IMapper mapper)
        {
            _skillCategoryRepository = skillCategoryService ?? throw new ArgumentNullException(nameof(skillCategoryService));
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<SkillCategoryDto>> GetWithAllDependenciesAsync()
        {
            var skillsCategoryDto = _cacheService.GetAllSkillCategories();

            if (skillsCategoryDto != null)
            {
                return skillsCategoryDto;
            }

            var skillsCategory = await _skillCategoryRepository.GetWithAllDependencies().ToListAsync();

            skillsCategoryDto = _mapper.Map<List<SkillCategoryDto>>(skillsCategory);

            _cacheService.AddSkillCategories(skillsCategoryDto);

            return skillsCategoryDto;
        }

        public async Task<List<FrequentlyAskedQuestionDto>> GetSkillCategoryFrequentlyAskedQuestionsAsync(Guid skillId)
        {
            var faqs = await _skillCategoryRepository.GetFrequentlyAskedQuestionsAsync(skillId);

            return _mapper.Map<List<FrequentlyAskedQuestionDto>>(faqs);
        }
    }
}
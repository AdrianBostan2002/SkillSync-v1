using AutoMapper;
using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Register;
using SkillSync.Domain.Exceptions.Register;
using SkillSync.Domain.Exceptions.Skill;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;

namespace SkillSync.Business.Services
{
    public class SkillService : ISkillService
    {
        private IUsersRepository _usersRepository;
        private IFreelancerRepository _freelancerRepository;
        private readonly ISkillRepository _skillRepository;

        private IMapper _mapper;

        public SkillService(IUsersRepository usersRepository, IFreelancerRepository freelancerRepository, ISkillRepository skillRepository, IMapper mapper)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _freelancerRepository = freelancerRepository ?? throw new ArgumentNullException(nameof(freelancerRepository));
            _skillRepository = skillRepository ?? throw new ArgumentNullException(nameof(skillRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<SkillDto> GetById(Guid id)
        {
            var skill = await _skillRepository.SingleByCondition(s => s.Id == id);

            if (skill == null)
            {
                throw new SkillNotFoundException();
            }

            var skillDto = _mapper.Map<SkillDto>(skill);

            return skillDto;
        }

        public async Task AddFreelancerSkills(string email, RegisterFreelancerSkillsRequest request)
        {
            var user = await _usersRepository.GetUserByEmailAsync(email);

            if (user == null)
            {
                throw new UserWasNotCreatedException();
            }

            var freelancer = await _freelancerRepository.GetByUserIdAsync(user.Id);

            if (freelancer == null)
            {
                throw new FreelancerWasNotCreatedException();
            }

            if (freelancer.FreelancerSkills == null)
            {
                freelancer.FreelancerSkills = new List<FreelancerSkills>();
            }

            foreach (var skill in request.Skills)
            {
                var mappedSkill = _mapper.Map<Skill>(skill);

                var newFreelancerSkill = new FreelancerSkills
                {
                    Freelancer = freelancer,
                    Skill = mappedSkill,
                    Experience = Domain.Enums.SkillExperienceLevel.LessThenOneYear
                };

                freelancer.FreelancerSkills.Add(newFreelancerSkill);
            }

            await _freelancerRepository.UpdateAsync(freelancer);
        }
    }
}
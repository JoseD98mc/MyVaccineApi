using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.UsersAllergy;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations
{
    public class UsersAllergyService : IUsersAllergyService
    {
        private readonly IBaseRepository<UsersAllergy> _usersAllergyRepository;
        private readonly IMapper _mapper;

        public UsersAllergyService(
            IBaseRepository<UsersAllergy> usersAllergyRepository,
            IMapper mapper)
        {
            _usersAllergyRepository = usersAllergyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsersAllergyResponseDto>> GetAll()
        {
            var usersAllergies = await _usersAllergyRepository
                .GetAll()
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<UsersAllergyResponseDto>>(usersAllergies);
        }

        public async Task<UsersAllergyResponseDto> GetById(int id)
        {
            var usersAllergies = await _usersAllergyRepository
                .FindByAsNoTracking(x => x.UserAllergyId == id)
                .FirstOrDefaultAsync();

            return _mapper.Map<UsersAllergyResponseDto>(usersAllergies);
        }

        public async Task<UsersAllergyResponseDto> Add(UsersAllergyRequestDto request)
        {
            var usersAllergy = new UsersAllergy
            {
                UserId = request.UserId,
                AllergyId = request.AllergyId
            };

            await _usersAllergyRepository.Add(usersAllergy);

            return _mapper.Map<UsersAllergyResponseDto>(usersAllergy);
        }

        public async Task<UsersAllergyResponseDto> Update(UsersAllergyRequestDto request, int id)
        {
            var usersAllergies = await _usersAllergyRepository
                .FindBy(x => x.UserAllergyId == id)
                .FirstOrDefaultAsync();

            usersAllergies.UserId = request.UserId;
            usersAllergies.AllergyId = request.AllergyId;

            await _usersAllergyRepository.Update(usersAllergies);

            return _mapper.Map<UsersAllergyResponseDto>(usersAllergies);
        }

        public async Task<UsersAllergyResponseDto> Delete(int id)
        {
            var usersAllergies = await _usersAllergyRepository
                .FindBy(x => x.UserAllergyId == id)
                .FirstOrDefaultAsync();

            await _usersAllergyRepository.Delete(usersAllergies);

            return _mapper.Map<UsersAllergyResponseDto>(usersAllergies);
        }
    }
}

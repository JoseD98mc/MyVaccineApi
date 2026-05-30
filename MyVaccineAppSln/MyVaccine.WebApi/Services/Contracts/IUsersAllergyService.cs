
using MyVaccine.WebApi.Dtos.UsersAllergy;

namespace MyVaccine.WebApi.Services.Contracts
{
    public interface IUsersAllergyService
    {
        Task<IEnumerable<UsersAllergyResponseDto>> GetAll();
        Task<UsersAllergyResponseDto> GetById(int id);
        Task<UsersAllergyResponseDto> Add(UsersAllergyRequestDto request);
        Task<UsersAllergyResponseDto> Update(UsersAllergyRequestDto request, int id);
        Task<UsersAllergyResponseDto> Delete(int id);

    }
}

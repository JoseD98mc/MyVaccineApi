using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Models;
using MyVaccine.WebApi.Repositories.Contracts;
using MyVaccine.WebApi.Services.Contracts;

namespace MyVaccine.WebApi.Services.Implementations;

public class AllergyService : IAllergyService
{
    private readonly IBaseRepository<Allergy> _allergyRepository;
    private readonly IMapper _mapper;

    public AllergyService(IBaseRepository<Allergy> allergyRepository, IMapper mapper)
    {
        _allergyRepository = allergyRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AllergyResponseDto>> GetAll()
    {
        var allergies = await _allergyRepository
            .GetAll()
            .AsNoTracking()
            .ToListAsync();

        return _mapper.Map<IEnumerable<AllergyResponseDto>>(allergies);
    }

    public async Task<AllergyResponseDto> GetById(int id)
    {
        var allergy = await _allergyRepository
            .FindByAsNoTracking(x => x.AllergyId == id)
            .FirstOrDefaultAsync();

        return _mapper.Map<AllergyResponseDto>(allergy);
    }

    public async Task<AllergyResponseDto> Add(AllergyRequestDto request)
    {
        var allergy = new Allergy
        {
            Name = request.Name
        };

        await _allergyRepository.Add(allergy);

        return _mapper.Map<AllergyResponseDto>(allergy);
    }

    public async Task<AllergyResponseDto> Update(AllergyRequestDto request, int id)
    {
        var allergy = await _allergyRepository
            .FindBy(x => x.AllergyId == id)
            .FirstOrDefaultAsync();

        allergy.Name = request.Name;

        await _allergyRepository.Update(allergy);

        return _mapper.Map<AllergyResponseDto>(allergy);
    }

    public async Task<AllergyResponseDto> Delete(int id)
    {
        var allergy = await _allergyRepository
            .FindBy(x => x.AllergyId == id)
            .FirstOrDefaultAsync();

        await _allergyRepository.Delete(allergy);

        return _mapper.Map<AllergyResponseDto>(allergy);
    }
}
  


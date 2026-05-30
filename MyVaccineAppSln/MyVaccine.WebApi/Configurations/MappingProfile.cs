using AutoMapper;
using MyVaccine.WebApi.Dtos.Allergy;
using MyVaccine.WebApi.Dtos.Dependent;
using MyVaccine.WebApi.Dtos.FamilyGroup;
using MyVaccine.WebApi.Dtos.UsersAllergy;
using MyVaccine.WebApi.Dtos.Vaccine;
using MyVaccine.WebApi.Dtos.VaccineCategory;
using MyVaccine.WebApi.Dtos.VaccineRecord;
using MyVaccine.WebApi.Models;

namespace MyVaccine.WebApi.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Allergy
            CreateMap<Allergy, AllergyResponseDto>();
            CreateMap<AllergyRequestDto, Allergy>();

            // Dependent
            CreateMap<Dependent, DependentResponseDto>();
            CreateMap<DependentRequestDto, Dependent>();

            // FamilyGroup
            CreateMap<FamilyGroup, FamilyGroupResponseDto>();
            CreateMap<FamilyGroupRequestDto, FamilyGroup>();
            CreateMap<FamilyGroupResponseDto, FamilyGroup>();

            // Vaccine
            CreateMap<Vaccine, VaccineResponseDto>();
            CreateMap<VaccineRequestDto, Vaccine>();

            // VaccineCategory
            CreateMap<VaccineCategory, VaccineCategoryResponseDto>();
            CreateMap<VaccineCategoryRequestDto, VaccineCategory>();

            // VaccineRecord
            CreateMap<VaccineRecord, VaccineRecordResponseDto>();
            CreateMap<VaccineRecordRequestDto, VaccineRecord>();

            // UsersAllergy
            CreateMap<UsersAllergy, UsersAllergyResponseDto>();
            CreateMap<UsersAllergyRequestDto, UsersAllergy>();
        }
    }
}

namespace MyVaccine.WebApi.Models
{
    public class UsersAllergy
    {
        public int UserAllergyId { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int AllergyId { get; set; }

        public Allergy Allergy { get; set; }
    }
}
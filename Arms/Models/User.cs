using System.ComponentModel.DataAnnotations.Schema;

namespace Arms.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string FatherName { get; set; }
        public int IsSoldier { get; set; }
        public string NationalId { get; set; }
        public string PersonnelId { get; set; }
        public string BirthDate { get; set; }
        public string LastElevationDate { get; set; }
        public int BadgeId { get; set; }
        public string BadgeTitle { get; set; }
        public int AddedDays { get; set; }
        public int Bounes { get; set; }
        public string Description { get; set; }
        public int MonthOfService { get; set; }
        public int IsDeleted { get; set; }
        //
        public string IdCode { get; set; } //shomare shenasname
        public string IdFrom { get; set; } // sadera az
        public int EducationId { get; set; }
        public string EducationTitle { get; set; }
        public int JobId { get; set; } // shoql sazmani
        public string JobTitle { get; set; } 
        public string LocationOfService { get; set; } // mahal khedmat
        public int ProficiencyId { get; set; } // taxasos
        public string ProficiencyTitle { get; set; }
        public string Mobile { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Sickness { get; set; }
        public int IsUncurable { get; set; } // la alaj
        public int IsHardToCure { get; set; } // sab ol alaj

        public int IsMartyrFamily { get; set; }
        public string EnteranceDate { get; set; }

        public string Sepah { get; set; }
        public string Hekmat { get; set; }
        //public string BloodType { get; set; }
        public string FitnessTestDate { get; set; }
        public string ShootingDate { get; set; }
        public string PayeshPlanDate { get; set; }

        [NotMapped]
        public string NotifChar { get; set; }
    }
}

namespace UserDB
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {

        [Key]
        
        public int? UserID { get; set; }


        [Column(Order = 0)]
        [StringLength(10)]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(10)]
        [Display(Name = "Surname")]
        [Required]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(10)]
        [Required]
        [Display(Name = "First Line of Address ")]
        public string FirstLineAddress { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Second Line of Address ")]
        public string SecondLineAddress { get; set; }

        [StringLength(10)]
        [Required]
        public string PostCode { get; set; }

        [Column(Order = 1)]
        [Display(Name = "Authorised to Trade")]
        [Required]
        public bool Active { get; set; }
        [Required]
        public bool Deleted { get; set; }

    }
}

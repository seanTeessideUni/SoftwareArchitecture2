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
        public string FirstName { get; set; }

        [StringLength(10)]
        public string Surname { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(10)]

        
        public string FirstLineAddress { get; set; }

        [StringLength(10)]
        public string SecondLineAddress { get; set; }

        [StringLength(10)]
        public string PostCode { get; set; }

        [Column(Order = 1)]
        public bool Active { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace onlineGrades.Core.Entity
{
    public class User
    {
        public User()
        {
            this.isActive = false;
        }
        public User(User user):base()
        {
            this.Nume = user.Nume;
            this.Prenume = user.Prenume;
            this.InitialaTata = user.InitialaTata;
            this.Email = user.Email;
            this.DataNasterii = user.DataNasterii;
            this.Mama = user.Mama;
            this.Tata = user.Tata;
            this.Nationalitate = user.Nationalitate;
            this.Cetatenie = user.Cetatenie;
            this.Username = user.Username;
            this.Password = user.Password;
            this.RegisterUUID = user.RegisterUUID;
            this.ResetUUID = user.ResetUUID;
        }

        [Required]
        [StringLength(20)]
        public String Nume { get; set; }
        [Required]
        [StringLength(20)]
        public string Username { get; set; }
        [Required]
        [StringLength(64)]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public String Prenume { get; set; }
        [Required]
        [StringLength(5)]
        public String InitialaTata { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public DateTime DataNasterii { get; set; }
        [Required]
        [StringLength(20)]
        public String Mama { get; set; }
        [Required]
        [StringLength(20)]
        public String Tata { get; set; }
        [Required]
        [StringLength(20)]
        public String Nationalitate { get; set; }
        [Required]
        [StringLength(20)]
        public String Cetatenie { get; set; }
        public Guid RegisterUUID { get; set; }
        public bool isActive { get; set; }
        public Guid ResetUUID { get; set; }

    }
}

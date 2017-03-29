using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace onlineGrades.Core.Entity
{
    [DataContract(IsReference = true)]

    public partial class User
    {
        public User()
        {
            this.userId = Guid.NewGuid();
            this.isActive = false;
        }
        public User(User user):base()
        {
            this.userId = user.userId;
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
            this.isActive = user.isActive;
        }
        [Required]
        [Key]
        [DataMember]
        public Guid userId { get; set; }


        [Required]
        [StringLength(20)]
        [DataMember]

        public String Nume { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]

        public string Username { get; set; }

        [Required]
        [StringLength(64)]
        [DataMember]

        public string Password { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]

        public String Prenume { get; set; }

        [Required]
        [StringLength(5)]
        [DataMember]

        public String InitialaTata { get; set; }

        [Required]
        [EmailAddress]
        [DataMember]

        public String Email { get; set; }

        [Required]
        [DataMember]

        public DateTime DataNasterii { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]

        public String Mama { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]

        public String Tata { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]

        public String Nationalitate { get; set; }

        [Required]
        [StringLength(20)]
        [DataMember]
        public String Cetatenie { get; set; }

        [DataMember]
        public Guid RegisterUUID { get; set; }

        [DataMember]
        public bool isActive { get; set; }
        [DataMember]
        public Guid ResetUUID { get; set; }

    }
}

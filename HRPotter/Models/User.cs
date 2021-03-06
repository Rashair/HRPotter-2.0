﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRPotter.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string B2CKey { get; set; }

        public string Name { get; set; }

        [Required]
        public virtual int RoleId { get; set; }
        public virtual Role Role { get; set; }
    }

    public class UserEditView : User
    {
        public UserEditView(User user)
        {
            this.Id = user.Id;
            this.B2CKey = user.B2CKey;
            this.Name = user.Name;
            this.Role = user.Role;
        }

        public IEnumerable<Role> Roles { get; set; }
    }

    public class Role
    {
        [Key]
        public int Id { get; set; } = 1;

        [MaxLength(100)]
        public string Name { get; set; }

        public static implicit operator string(Role role) => role.Name;

        public override bool Equals(object obj)
        {
            if (obj is Role role)
            {
                return this.Name.Equals(role.Name);
            }
            else if (obj is string name)
            {
                return this.Name.Equals(name);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }


        public override string ToString()
        {
            return Name;
        }
    }
}

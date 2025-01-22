using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Role { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? LastLogin { get; set; }

    public virtual ICollection<AdoptionQuestionnaire> AdoptionQuestionnaires { get; set; } = new List<AdoptionQuestionnaire>();

    public virtual ICollection<Owner> Owners { get; set; } = new List<Owner>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}

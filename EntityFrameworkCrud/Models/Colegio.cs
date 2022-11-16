using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EntityFrameworkCrud.Models
{
    public partial class Colegio : IEntityBase
    {
        public Colegio()
        {
            Curso = new HashSet<Curso>();
        }

        public int Id { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}

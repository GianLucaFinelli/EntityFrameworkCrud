using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EntityFrameworkCrud.Models
{
    public partial class Curso : IEntityBase
    {
        public int Id { get; set; }
        public int IdColegio { get; set; }
        public string Descripcion { get; set; }

        public virtual Colegio IdColegioNavigation { get; set; }
    }
}

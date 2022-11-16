using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EntityFrameworkCrud.Models
{
    public partial class Alumno : IEntityBase
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public string Nombre { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
    }
}

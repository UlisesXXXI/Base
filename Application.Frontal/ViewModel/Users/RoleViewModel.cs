using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Frontal.ViewModel.Users
{
    public class RoleViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public bool Activo { get; set; }

        #region Logica vista
        public bool EsNuevo { get { return Id == null; } }
        #endregion
    }
}
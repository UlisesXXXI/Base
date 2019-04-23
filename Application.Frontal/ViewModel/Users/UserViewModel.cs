using Application.bbdd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Frontal.ViewModel.Users
{
    public class UserViewModel
    {
        #region Constructor
        public UserViewModel()
        {
            Roles = new List<ApplicationRole>();
            EditRecord = false;
        }
        #endregion
        #region Properties
        [Required]
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public bool EditRecord { get; set; }
        #endregion

        public List<ApplicationRole> Roles { get; set; }


    }
}
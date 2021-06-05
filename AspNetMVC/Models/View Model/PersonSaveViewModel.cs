using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetMVC.Models.View_Model
{
    public partial class PersonSaveViewModel
    {

        public int BusinessEntityID { get; set; }

        [Required(ErrorMessage ="The Field is required.")]
        [StringLength(2,ErrorMessage ="Person type can not be more than 2 character.")]
        public string PersonType { get; set; }

        public bool NameStyle { get; set; }

        [Required(ErrorMessage = "The Field is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Field is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The Field is required.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "The Field is required.")]
        public string LastName { get; set; }

        public int EmailPromotion { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }
}
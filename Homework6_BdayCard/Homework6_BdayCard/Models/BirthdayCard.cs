using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Homework6_BdayCard.Models
{
    public class BirthdayCard
    {
        [Required(ErrorMessage = "Please enter From")]
        public string FromWho { get; set; }

        [Required(ErrorMessage = "Please enter To")]
        public string ToWho { get; set; }

        [Required(ErrorMessage = "Please enter Message")]
        public string Message {get;set;}
    }
}
using System.ComponentModel.DataAnnotations;

namespace MVC123.Models {

    public class CourseModel {
        //Properies

        [Required(ErrorMessage = "Ange en kurskod")]
        [Display(Name ="Kurskod:")]
        public string? coursecode { get; set; }

        [Required(ErrorMessage = "Ange ett kursnamn")]
        [Display(Name ="Kursnamn:")]
        public string? cname { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace MVC123.Models {

    public class ScheduleModel {
        //Properies
        [Required(ErrorMessage = "Ange ett namn på ditt träningstillfälle")]
        [Display(Name ="Vad ska du träna?")]
        public string? workoutName { get; set; }

        [Required(ErrorMessage = "Ditt tillfälle måste utföras på en veckodag")]
        [Display(Name ="Välj veckodag för till träningstillfälle")] 
        public string? dayOfWeek { get; set; }

        [Required(ErrorMessage = "Du måste välja en tidpunkt")]
        [Display(Name ="Välj vilken tid på dygnet")]
        public string? time { get; set; }

        [Range(1,5, ErrorMessage ="Du måste fylla i en svårighetsgrad mellan 1-5")]
        [Display(Name ="Svårighets grad, välj från 1 till 5")]
        public int degreeDifficulty { get; set; }
    

    }
}
using Microsoft.AspNetCore.Mvc;
using MVC123.Models;
using Newtonsoft.Json;

namespace MVC123.Controllers {

    public class HomeController : Controller {

        //Start
        public IActionResult Index(){
            return View();
        }

        //Om
        public IActionResult About(){
            return View();
        }

        //Kurser
        public IActionResult Courses(){
            return View();
        }

        [HttpPost] //Vid post metod används denna modell
        public IActionResult Courses(CourseModel model){
            if(ModelState.IsValid){
               //Läs in
               var JsonStr = System.IO.File.ReadAllText("courses.json");
               var JsonObj = JsonConvert.DeserializeObject<List<CourseModel>>(JsonStr);

               //Lägg till
               if(JsonObj != null) {
                   JsonObj.Add(model);
               }

               //Konvertera till json sträng och spara
               System.IO.File.WriteAllText("courses.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));
            }
            
            return View();
        }
    }
}
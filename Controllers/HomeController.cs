using Microsoft.AspNetCore.Mvc;
using MVC123.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Session;

namespace MVC123.Controllers {

    public class HomeController : Controller {

        //Start
        public IActionResult Index(){
            var JsonStr = System.IO.File.ReadAllText("schedule.json");
            var JsonObj = JsonConvert.DeserializeObject<List<ScheduleModel>>(JsonStr);

            string? s1 = HttpContext.Session.GetString("test1");
            string? add1 = HttpContext.Session.GetString("test2");

            string? empty = "Ditt träningsschema är tomt - Passa på att lägg in några träningstillfällen";
            if(JsonObj != null) {
                if(JsonObj.Count == 0){
                ViewBag.empty = empty;
            }
            }
            
            if(add1 == null){
                ViewBag.text = s1;
            }
            
            ViewBag.newcourse = add1;
            if(add1 != null){
                Thread.Sleep(3000);
                HttpContext.Session.Remove("test2"); 
                
            }

            //ViewBag.messagecourse = ViewBag.newcourse;

            return View(JsonObj);
        }

        //Om
        public IActionResult About(){

            var JsonStr = System.IO.File.ReadAllText("schedule.json");
            var JsonObj = JsonConvert.DeserializeObject<List<ScheduleModel>>(JsonStr);

            return View(JsonObj);
        }

        //Kurser
        public IActionResult AddWorkout(){

            var JsonStr = System.IO.File.ReadAllText("schedule.json");
            var JsonObj = JsonConvert.DeserializeObject<List<ScheduleModel>>(JsonStr);

            string? s2 = HttpContext.Session.GetString("test1");
            ViewData["Message"] = s2;

            return View();

            
        }

        [HttpPost] //Vid post metod används denna modell
        public IActionResult AddWorkout(ScheduleModel model){
            
            string? s4 = HttpContext.Session.GetString("test1");
            ViewData["Message"] = s4;
            if(ModelState.IsValid){
               //Läs in
               var JsonStr = System.IO.File.ReadAllText("schedule.json");
               var JsonObj = JsonConvert.DeserializeObject<List<ScheduleModel>>(JsonStr);
               string s3 = "";
               string added = "";
                
               //Lägg till
               if(JsonObj != null) {
                   
                   JsonObj.Add(model);
                   s3 = $"Träningstillfälle som du nyligen lagt till - {model.workoutName}, {model.dayOfWeek}ar kl {model.time}";
                   added = $"Träningstillfället {model.workoutName} har lagts till på {model.dayOfWeek}ar kl {model.time}";
                   HttpContext.Session.SetString("test1", s3);
                   HttpContext.Session.SetString("test2", added);
                   //ViewBag.newcourse = added; 

                   
               }

               //Konvertera till json sträng och spara
               
               System.IO.File.WriteAllText("schedule.json", JsonConvert.SerializeObject(JsonObj, Formatting.Indented));


               ModelState.Clear();
               
               return Redirect("Index"); 
              
            }
            
            return View();
            
        }
    }
}
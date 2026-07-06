using Microsoft.AspNetCore.Mvc;

using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //methode "naturally" call by router
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //retourn to the Index view (see routing in Program.cs)
                return View();
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "XlmFile", "DataAvis.xml");
                        OpinionList opinionList = new OpinionList();
                        var avis = opinionList.GetAvis(filePath);
                        return View(id, avis);
                    case "Form":
                        //TODO : call the Form view with data model empty
                        return View(id, new Avis());
                    default:
                        //retourn to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]
        public ActionResult ValidationForm(Avis avis)
        {
            if (avis.DateDebut >= new DateTime(2021, 01, 01))
            {
                ModelState.AddModelError("DateDebut", "La date doit être inférieure au 01/01/2021");
            }

            if (ModelState.IsValid)
            {
                return View("Validation", avis);
            }

            return View("Form", avis);
        }
    }
}
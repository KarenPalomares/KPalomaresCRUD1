using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class HospitalController : Controller
    {
        [HttpPost]
        public ActionResult Form(ML.Hospital hospital)
        {
            Dictionary<string, object> resultado = BL.Hospital.Add(hospital);
            bool result = (bool)resultado["Resultado"];
            if (result == true)
            {
                ViewBag.Message = "Hospital agregado";
                return ViewBag.Message = ("Modal");

            }
            else
            {
                ViewBag.Message = "El hospital no se pudo agregar";
                return ViewBag.result = ("Modal");

            }

        }
        [HttpGet]
        public ActionResult Form()
        {

            return View();
        }
    }
}

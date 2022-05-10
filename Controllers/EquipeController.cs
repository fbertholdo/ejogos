using EJOGOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EJOGOS.Controllers
{
    public class EquipeController : Controller
    {

        Equipe equipeModel = new Equipe();

        public IActionResult Index()
        {
            //Viewbag = Reserva de espaço para armazenar informações para recuperar na VIEW.

            //ViewBag = Tem a função de "carregar" as informações do Controller para a VIEW.


            ViewBag.Equipes = equipeModel.LerEquipes();


            return View();
        }
    }
}

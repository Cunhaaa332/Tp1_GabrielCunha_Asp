using System;
using AmigosDados;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apresentacao.Controllers
{
    public class AmigoController : Controller
    {
        private AmigoRepository AmigoRpository { get; set; }
        public AmigoController(AmigoRepository amigoRepository)
        {
            this.AmigoRpository = amigoRepository;
        }
        // GET: AmigoController
        [Route("Amigos/")]
        public ActionResult Index()
        {
            var amigos = this.AmigoRpository.Listar();
            return View(amigos);
        }

        [Route("Amigos/ListAmigosEmail")]
        public ActionResult ListAmigosEmail()
        {
            var amigos = this.AmigoRpository.Listar();
            return View(amigos);
        }
    }
}

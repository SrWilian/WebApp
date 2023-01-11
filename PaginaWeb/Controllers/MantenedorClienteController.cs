using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;

namespace PaginaWeb.Controllers
{
    public class MantenedorClienteController : Controller
    {
        // GET: MantenedorCliente
        public ActionResult ListarCliente()
        {
            List<EntCliente> lista = LogCliente.Instancia.ListarCliente();
            ViewBag.lista = lista;
            return View(lista);
        }
        [HttpGet]
        public ActionResult AgregarCliente()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarCliente( EntCliente Cli) {
            bool insertar = LogCliente.Instancia.AgregarCliente(Cli);
            try
            {
                if (insertar)
                {
                    return RedirectToAction("ListarCliente");
                }
                else
                {
                    return View(Cli);
                }
            }
            catch (Exception e)
            {

                return RedirectToAction("Error de registro del usuario /n", new { mesjExeption = e.Message });
            }
        
        }
    }
}
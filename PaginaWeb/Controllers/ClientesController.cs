using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaginaWeb.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarCliente()
        {

            List<EntClientes> lista = LogClientes.Instancia.ListarCliente();
            ViewBag.lista = lista;
            return View(lista);
        }
        [HttpGet]
        public ActionResult AgregarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCliente(EntClientes Cli)
        {
            bool insertar = LogClientes.Instancia.AgregarCliente(Cli);
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
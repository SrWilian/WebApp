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
    }
}
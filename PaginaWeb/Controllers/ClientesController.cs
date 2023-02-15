using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.ApiRUCDNI;
namespace PaginaWeb.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult ListarCliente()
        {

            List<EntClientes> lista = LogClientes.Instancia.ListarCliente();
            ViewBag.lista = lista;
            return View(lista);
        }
        [HttpGet]
        public ActionResult AgregarCliente()
        {
            
            List<EntProvincia> listaProvincia = LogProvincia.Instancia.ListarProvincia();
            ViewBag.listaProvincias = new SelectList(listaProvincia, "idProvincia", "desProvincia");
            //ViewBag.listaProvincias = lsProvincia;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCliente(EntClientes Cli, FormCollection frm)
        {
            bool insertar = LogClientes.Instancia.AgregarCliente(Cli);
            try
            {
                Cli.IdProvincia = new EntProvincia();
                Cli.IdProvincia.idProvincia = Convert.ToInt32(frm["cboProvincia"]);
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

        ///acomodar, alli quede estancado
        ///

        [HttpGet]
        public ActionResult ConsultarApi(EntClientes Client)
        {
            ApisPeru ApisPeru = new ApisPeru();
            //if (Client.RucDni.Length == 8)
            //{
                dynamic respuesta = ApisPeru.Get("https://dniruc.apisperu.com/api/v1/dni/" + "45633353" + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU");
                Client.RazonSocial = respuesta.nombres.ToString() + " " + respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
                //Client.TipoDoc =1;
                //Client.Ubigeo = "";
                //Client.Direccion = "";
                //Client.Region = "";
                //Client.Provincia = "";
                //Client.Distrito = "";
                //Client.Correo = "";
                //return View(respuesta);
                return RedirectToAction("AgregarCliente");
            //}
            //if (Client.RucDni.Length == 11)
            //{
            //    dynamic respuesta = ApisPeru.Get("https://dniruc.apisperu.com/api/v1/ruc/" + Client.RucDni + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU");
            //    Client.RazonSocial = respuesta.razonSocial.ToString();
            //    //Client.Direccion = respuesta.direccion.ToString();
            //    //Client.Ubigeo = respuesta.ubigeo.ToString();
            //    ////lblCondicion.Text = respuesta.condicion.ToString();
            //    ////lblEstado.Text = respuesta.estado.ToString();
            //    //Client.Region = respuesta.departamento.ToString();
            //    //Client.Provincia = respuesta.provincia.ToString();
            //    //Client.Distrito = respuesta.distrito.ToString();
            //    //Client.TipoDoc=6;
            //}

            //return View();
        }

    }
}
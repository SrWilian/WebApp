using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaLogica;
using PaginaWeb.ApiRUCDNI;

namespace PaginaWeb.Controllers
{
    public class MantenedorClienteController : Controller
    {
        // GET: MantenedorCliente
        public ActionResult ListarCliente(string NombreCliente)
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

        /*
        [HttpGet]
        public ActionResult EditarCliente(int IdCliente)
        {
            EntCliente Cli = new EntCliente();
            Cli = LogCliente.Instancia.BuscarIdCliente(IdCliente);

            return View(c);

        }
        [HttpPost]
        public ActionResult ActualizarCliente(entCliente c, FormCollection frm)
        {
            try
            {
                Boolean edita = logCliente.Instancia.ActualizarCliente(c);
                if (edita)
                {
                    return RedirectToAction("ListarCliente");

                }
                else
                {
                    return View(c);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("ActualizarCliente", new { mesjExceptio = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult EliminarCliente()
        {

            return View();
        }
        public ActionResult EliminarCliente(int IdCliente)
        {
            try
            {
                Boolean Deshabilita = logCliente.Instancia.EliminarCliente(IdCliente);
                if (Deshabilita)
                {
                    return RedirectToAction("ListarCliente");
                }
                else
                {
                    return View(IdCliente);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EliminarCliente", new { mesjExceptio = ex.Message });
            }
        }

        */



        //private void consultarCliente()
        //{
        //    try
        //    {
        //        if (Cli.dni.Text.Length == 11)
        //        {
        //            dynamic respuesta = ApisPeru.Get("https://dniruc.apisperu.com/api/v1/ruc/" + txtDNIRUC.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU");
        //            txtNombre.Text = respuesta.razonSocial.ToString();
        //            txtDireccion.Text = respuesta.direccion.ToString();
        //            lblUbigeo.Text = respuesta.ubigeo.ToString();
        //            lblCondicion.Text = respuesta.condicion.ToString();
        //            lblEstado.Text = respuesta.estado.ToString();
        //            lblRegion.Text = respuesta.departamento.ToString();
        //            lblProvincia.Text = respuesta.provincia.ToString();
        //            lblDistrito.Text = respuesta.distrito.ToString();

        //        }
        //        else if (txtDNIRUC.Text.Length == 8)
        //        {
        //            dynamic respuesta = ApisPeru.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtDNIRUC.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU");
        //            txtNombre.Text = respuesta.nombres.ToString() + " " + respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
        //            lblUbigeo.Text = "";
        //            lblCondicion.Text = "";
        //            lblEstado.Text = "";
        //            lblRegion.Text = "";
        //            lblProvincia.Text = "";
        //            lblDistrito.Text = "";

        //        }

        //        else
        //        {
        //            MessageBox.Show("Ingrese un número de documento válido.", "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        MessageBox.Show("Ingrese un número de documento válido.", "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
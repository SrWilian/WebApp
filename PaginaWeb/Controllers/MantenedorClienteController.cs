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

        
        [HttpGet]
        public ActionResult EditarCliente()
        {
         
            return View();

        }
        [HttpPost]
        public ActionResult EditarCliente(EntCliente Cli, FormCollection frm)
        {
            try
            {
                Boolean edita = LogCliente.Instancia.EditarCliente(Cli);
                if (edita)
                {
                    return RedirectToAction("ListarCliente");

                }
                else
                {
                    return View(Cli);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("ActualizarCliente", new { mesjExceptio = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult DeshabilitarCliente()
        {

            return View();
        }
        public ActionResult DeshabilitarCliente(int IdCliente)
        {
            try
            {
                Boolean Deshabilita = LogCliente.Instancia.DeshabilitarCliente(IdCliente);
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
                return RedirectToAction("DeshabilitarCliente", new { mesjExceptio = ex.Message });
            }
        }

        



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
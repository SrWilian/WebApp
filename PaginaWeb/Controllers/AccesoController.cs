using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaLogica;

using System.Data.SqlClient;
using System.Data;

namespace PRUEBAS_LOGIN.Controllers
{
    public class AccesoController : Controller
    {

        // GET: Acceso
        //modificado por eric-------------------------------------

        //public ActionResult Login()

        public ActionResult Acceso()
        {
            return View();
        }

       

        public ActionResult RegistrarUsuario()
        {
            return View();
        }


        public ActionResult Enter(string user, string password)
        {


        }
        /// <summary>
        /// hasta aaqui----------------------------------------------------
        /// 
        /// 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>

            [HttpPost]
        public ActionResult RegistrarUsuario(EntUsuario Usuario)
        {
            bool insertar = LogUsuario.Instancia.RegistrarUsuario(Usuario);

            try
            {
                if (insertar && Usuario.Clave == Usuario.ConfirmarClave)
                {
                    return RedirectToAction("ListarCliente");
                }

                else
                {
                    ViewData["Mensaje"] = "Las contraseñas no coinciden";
                    return View(Usuario);
                }
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction("RegistrarUsuario", new { mesjExceptio = ex.Message });
            }

        }
    }
}
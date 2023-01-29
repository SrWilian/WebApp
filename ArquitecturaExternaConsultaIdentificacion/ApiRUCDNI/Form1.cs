using PaginaWeb.ApiRUCDNI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArquitecturaExternaConsultaIdentificacion.ApiRUCDNI
{
    public partial class Form1 : Form
    {

        ApisPeru ApisPeru = new ApisPeru();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void consultarCliente()
        {
            try
            {
                if (txtDNIRUC.Text.Length == 11)
                {
                    dynamic respuesta = ApisPeru.Get("https://dniruc.apisperu.com/api/v1/ruc/" + txtDNIRUC.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU");
                    txtNombre.Text = respuesta.razonSocial.ToString();
                    txtDireccion.Text = respuesta.direccion.ToString();
                    lblUbigeo.Text = respuesta.ubigeo.ToString();
                    lblCondicion.Text = respuesta.condicion.ToString();
                    lblEstado.Text = respuesta.estado.ToString();
                    lblRegion.Text = respuesta.departamento.ToString();
                    lblProvincia.Text = respuesta.provincia.ToString();
                    lblDistrito.Text = respuesta.distrito.ToString();

                }
                else if (txtDNIRUC.Text.Length == 8)
                {
                    dynamic respuesta = ApisPeru.Get("https://dniruc.apisperu.com/api/v1/dni/" + txtDNIRUC.Text + "?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImxtdGltYW5hZ0BnbWFpbC5jb20ifQ.udFejq_ZQw4kqP6wfRGX1RaKaksh-lFwcqlM7p9Y1dU");
                    txtNombre.Text = respuesta.nombres.ToString() + " " + respuesta.apellidoPaterno.ToString() + " " + respuesta.apellidoMaterno.ToString();
                    lblUbigeo.Text = "";
                    lblCondicion.Text = "";
                    lblEstado.Text = "";
                    lblRegion.Text = "";
                    lblProvincia.Text = "";
                    lblDistrito.Text = "";

                }

                else
                {
                    MessageBox.Show("Ingrese un número de documento válido.", "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Ingrese un número de documento válido.", "Documento inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            consultarCliente();

        }

    }

   
}

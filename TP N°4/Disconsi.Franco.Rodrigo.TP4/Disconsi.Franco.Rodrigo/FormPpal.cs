using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Disconsi.Franco.Rodrigo
{
    public partial class FormPpal : Form
    {
        Correo correo;
        public FormPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
            PaqueteDAO.eventoSQL += this.ErrorSql;
        }

        /// <summary>
        /// Muestra toda la lista de paquetes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra si hubo un error al cargar en el servidor SQL.
        /// </summary>
        /// <param name="mensaje"></param>
        private void ErrorSql(string mensaje)
        {
            MessageBox.Show(mensaje, "ERROR SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Actualiza los estados de los paquetes.
        /// </summary>

        private void ActualizarEstados()
        {
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoIngresado.Items.Clear();

            foreach (Paquete p in correo.Paquetes)
            {

                if(p.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresado.Items.Add(p);
                }
                else if(p.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(p);
                }
                else
                {
                    lstEstadoEntregado.Items.Add(p);
                }
            }
        }

        /// <summary>
        /// Cierra el formulario y aborta los hilos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void FormPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.correo.Paquetes.Count > 0)
                this.correo.FinEntregas();
        }

        /// <summary>
        /// Muestra la información en el richtextbox y guarda en un txt
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(!(elemento is null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                try
                {
                    this.rtbMostrar.Text.GuardarString("Correo.txt");
                }
                catch (Exception)
                {
                    MessageBox.Show("Hubo un error guardando en el archivo");
                }
            }         
        }

        /// <summary>
        /// Pregunta si es necesario invocar al hilo principal y llama a ActualizarEstados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Agrega un paquete al Correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxTrackingID.Text);
            nuevoPaquete.InformaEstado += paq_InformaEstado;
            try
            {
                this.correo += nuevoPaquete;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.ActualizarEstados();
        }

        /// <summary>
        /// Muestra la información de un paquete Entregado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}

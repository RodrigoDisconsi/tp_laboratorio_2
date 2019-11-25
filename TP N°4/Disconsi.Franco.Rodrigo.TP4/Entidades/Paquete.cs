using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        string direccionEntrega;
        EEstado estado;
        string trackingID;
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        public string DireccionEntrega
        {
            get
            {
                return direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
        }

        /// <summary>
        /// Muestra el ID del paquete y la dirección de entrega.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).direccionEntrega);
        }

        /// <summary>
        /// Hace que el paquete pase por los 3 EEstado y lo guarda en una base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            for(int i = 0; i < 3; i++)
            {
                if (this.estado == EEstado.Entregado)
                    break;
                this.estado = (EEstado)i;
                this.InformaEstado.Invoke(this, null);
                System.Threading.Thread.Sleep(4000);
            }
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Hace público los datos del paquete.
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return string.Format(this.MostrarDatos(this) + $" estado: {this.estado}");
        }

        /// <summary>
        /// Dos paquetes son iguales si tienen el mismo TrackingID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.trackingID == p2.trackingID)
                return true;
            return false;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }


    }
}

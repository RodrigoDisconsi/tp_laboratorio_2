using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public delegate void DelegadoEstado(Paquete.EEstado estado);
    public class Paquete : IMostrar<Paquete>
    {
        string direccionEntrega;
        EEstado estado;
        string trackingID;
        public enum EEstado
        {
            Ingresado, EnViaje, Entregado
        }
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

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).direccionEntrega);
        }
        public void MockCicloDeVida()
        {
            for(int i = 0; i < 3; i++)
            {
                this.estado = (EEstado)i;
                this.InformaEstado.Invoke(this.estado);
                System.Threading.Thread.Sleep(4000);
            }
            //Guardar en SQL.
        }

        public override string ToString()
        {
            return string.Format(this.MostrarDatos(this) + $"Estado: {this.estado}");
        }

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

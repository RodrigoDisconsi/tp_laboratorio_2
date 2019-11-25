using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }

        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Cierra todos los hilos.
        /// </summary>

        public void FinEntregas()
        {
            foreach(Thread hilo in this.mockPaquetes)
            {
                hilo.Abort();
            }
        }

        /// <summary>
        /// Muestra los datos de la interfaz recibida
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>

        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder rtn = new StringBuilder();

            foreach (Paquete p in ((Correo)elemento).Paquetes)
            {
                rtn.AppendLine($"{p.TrackingID} para {p.DireccionEntrega} ({p.Estado.ToString()})");
            }

            return rtn.ToString();
        }

        /// <summary>
        /// Agrega un paquete a la lista, verificando que no se encuentre el mismo antes.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool esta = false;
            Thread hiloPaquete = new Thread(p.MockCicloDeVida);
            foreach(Paquete paquete in c.paquetes)
            {
                esta = paquete == p;
            }
                if(esta == true)
                {
                    throw new TrackingIdRepetidoException("El TrackingID ya existe.");
                }
            c.paquetes.Add(p);
            c.mockPaquetes.Add(hiloPaquete);
            hiloPaquete.Start();
            return c;
        }


    }
}

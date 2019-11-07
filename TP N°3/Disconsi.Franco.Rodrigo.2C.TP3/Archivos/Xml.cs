using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;


namespace Archivos
{
    public class Xml <T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using(XmlTextWriter writer = new XmlTextWriter("ArchivoXml", null))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
                }
                return true;
            }
            catch(Exception e)
            {
                throw new ArchivoException(e);
            }
        }

        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader("ArchivoXml"))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                }
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivoException(e);
            }
        }
    }
}

using System;
using System.Data;

namespace EjemploDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Estructura
            DataSet ds = new DataSet("ejemplobdd");
            DataTable dt = new DataTable("personas");

            ds.Tables.Add(dt);

            dt.Columns.Add("Id", typeof(long));
            dt.Columns.Add("Nombre", typeof(string));

            dt.PrimaryKey = new DataColumn[] { dt.Columns[0] };
            #endregion

            #region Datos
            dt.Rows.Add(1, "Javier");
            dt.Rows.Add(2, "Pepe");
            dt.Rows.Add(3, "Pedro");

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"{dr["Id"]}, {dr["Nombre"]}");
            }

            DataRow fila = dt.Rows.Find(2);

            fila["Nombre"] = "Juan";

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"{dr["Id"]}, {dr["Nombre"]}");
            }

            dt.Rows.Find(1).Delete();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine($"{dr["Id"]}, {dr["Nombre"]}");
            }
            #endregion

            #region Exportación e importación
            ds.WriteXml("ejemplobdd.xml");

            DataSet dsImportado = new DataSet();
            dsImportado.ReadXml("ejemplobdd.xml");

            foreach (DataRow dr in dsImportado.Tables["personas"].Rows)
            {
                Console.WriteLine($"{dr["Id"]}, {dr["Nombre"]}");
            }
            #endregion
        }
    }
}

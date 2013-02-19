using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
//using RedGate.SQLCompare.Engine;
//using ApexSql.Diff;
//using ApexSql.Diff.Structure;

namespace MundiAudit.ActualizadorApp.Definiciones
{

	public class ActualizadorBBDD
    {
        #region APEX
        ///// <summary>
        ///// Cadena de conexión a la BBDD donde se va a aplicar la actualizacion
        ///// </summary>
        //private SqlConnectionStringBuilder cadenaConexion;
        //public string CadenaConexion
        //{
        //    set
        //    {
        //        cadenaConexion = new SqlConnectionStringBuilder(value);
        //    }
        //}

        ///// <summary>
        ///// Cadena con las actualizaciones que se van a aplicar
        ///// </summary>
        //public string Actualizacion { get; set; }

        ///// <summary>
        ///// Crea un snapshot de la BBDD especificada
        ///// </summary>
        ///// <returns></returns>
        //public void GenerarSnapshot(string ruta)
        //{
        //    //using (Database db = new Database())
        //    //{
        //    //    ConnectionProperties connectionProperties = new ConnectionProperties(
        //    //        cadenaConexion.DataSource,
        //    //        cadenaConexion.InitialCatalog,
        //    //        cadenaConexion.UserID,
        //    //        cadenaConexion.Password);
        //    //    db.Register(connectionProperties, Options.Default);

        //    //    db.SaveToDisk(string.Format("{0}/{1}.snp", ruta, cadenaConexion.InitialCatalog));
        //    //}

        //    //Apex
        //    //ConnectionProperties connectionProperties = new ConnectionProperties(
        //    //        cadenaConexion.DataSource,
        //    //        cadenaConexion.InitialCatalog,
        //    //        cadenaConexion.UserID,
        //    //        cadenaConexion.Password);
        //    //Diff.GenerateSnapshot(connectionProperties, string.Format("{0}/{1}.axsnp", ruta, cadenaConexion.InitialCatalog), new ProgressReporter());
        //}

        //public void AplicarActualizacion()
        //{ }
        #endregion


    }
}

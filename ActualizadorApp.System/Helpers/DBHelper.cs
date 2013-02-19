using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MundiAudit.ActualizadorApp.Definiciones.Helpers
{
    public static class DBHelper
    {
        public static object ExecuteScalar(string CadenaConexion,string Consulta)
        {
            SqlConnection connection = new SqlConnection(CadenaConexion);
            connection.Open();
            SqlCommand comm = new SqlCommand(Consulta, connection);
            return comm.ExecuteScalar();            
        }
    }
}

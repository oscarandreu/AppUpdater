using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;


namespace MundiAudit.ActualizadorApp.Definiciones
{
	public static class HashHelper
	{

		public static string CalcularHashArchivo(string ruta)
		{
			string lResult;

			//Comprobación de seguridad
			if (!File.Exists(ruta)) return null;

			using (var oSHA1Hasher = new SHA1CryptoServiceProvider())
			{
				FileStream fs = null;
				byte[] arrbytHashValue;

				fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
				arrbytHashValue = oSHA1Hasher.ComputeHash(fs);
				fs.Flush();
				fs.Close();

				lResult = BitConverter.ToString(arrbytHashValue);

				lResult = lResult.Replace("-", string.Empty);
			}

			return lResult;
		}


	}
}

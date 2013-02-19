using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace MundiAudit.ActualizadorApp.Definiciones
{

    public class GestorArchivosIISFileSystem : IGestorArchivos
    {
        ConfiguracionActualizador Config;
        public GestorArchivosIISFileSystem(ConfiguracionActualizador Config)
        {
            this.Config = Config;
        }

        private string GetRutaRelativa(string ruta)
        {
            return PrepPath((PrepPath(PrepPath(Config.RutaRepositorio) + Config.NombreAplicacion) + ruta));
        }

        private string PrepPath(string ruta)
        {
            ruta = ruta.Replace("\\", "/");
            if (string.IsNullOrEmpty(ruta))
                return ruta;

            if (!ruta.EndsWith("/"))
                return ruta + "/";
            else
                return ruta;
        }

        private static string Request(string url)
        {
            url = "http://" + url.Trim().Replace("http://", "").Replace("//", "/");
            var request = WebRequest.Create(url);
            var proxy = new WebProxy();
            proxy.UseDefaultCredentials = true;
            request.Proxy.Credentials = proxy.Credentials;
            var response = request.GetResponse();
            string res = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return res;
        }

        private void Listar(string RutaRelativa, out string[] list)
        {
            string url = GetRutaRelativa(RutaRelativa);
            string res = Request(url);

            Regex expresion = new Regex(@"<br><br>(.*?)<br></pre>");
            Match match = expresion.Match(res);
            list = match.Groups[1].Value.Split(new string[] { "<br>" }, StringSplitOptions.RemoveEmptyEntries);
        }

        #region Miembros de IGestorArchivos

        public Stream CargarArchivo(string Fichero, int Version, ref long fileSize, ref long downladedBytes)
        {
            WebClient client = new WebClient();
            string rutarelativa = PrepPath(Version.ToString().PadLeft(10, '0')) + PrepPath(Fichero);
            string ruta = GetRutaRelativa(rutarelativa).TrimEnd('/');
            if (fileSize == 0)
                fileSize = ObtenerTamañoTotalDescarga(new List<string>() { Fichero }, Version);

            ruta = "http://" + ruta.Trim().Replace("http://", "").Replace("//", "/");
            Stream lectura = client.OpenRead(ruta);
            int readbytes = 0;
            byte[] buffer = new byte[512];
            MemoryStream ms = new MemoryStream();

            readbytes = lectura.Read(buffer, 0, buffer.Length);
            while (readbytes > 0)
            {
                ms.Write(buffer, 0, readbytes);

                if (fileSize > -1)
                    downladedBytes += readbytes;
                readbytes = lectura.Read(buffer, 0, buffer.Length);
            }

            ms.Position = 0;

            return ms;
        }

        public StreamReader CargarArchivoTexto(string Fichero, int Version)
        {
            long a = -1, b = -1;
            return new StreamReader(CargarArchivo(Fichero, Version, ref a, ref b));
        }

        public bool ExisteArchivo(string Fichero, int Version)
        {
            Fichero = Fichero.Replace(@"\", @"/");
            string[] sruta = Fichero.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            string filename = sruta[sruta.Length - 1];
            filename = filename.Replace(@"\", "").Replace(@"/", "");
            string ruta = string.Empty;
            for (int n = 0; n < sruta.Length - 1; n++)
                ruta += PrepPath(sruta[n]);

            var result = ObtenerListaFicheros(ruta, Version, false);

            foreach (string r in result)
                if (r.ToLower().Trim() == filename.ToLower().Trim())
                    return true;

            return false;

        }

        public string[] ObtenerListaDirectorios(string RutaRelativa)
        {
            if (RutaRelativa == null)
                RutaRelativa = string.Empty;

            string[] list;
            List<string> results;
            results = new List<string>();
            Listar(RutaRelativa, out list);

            foreach (string item in list)
            {
                if (item.Contains("&lt;dir&gt;")) //es un directorio
                {
                    var r = new Regex(@"<A[^>]*>(.*?)</A>").Match(item);
                    if (r.Groups.Count > 1 && r.Groups[1].Success)
                    {
                        results.Add(r.Groups[1].Value);
                    }
                }
            }

            return results.ToArray();
        }

        public long ObtenerTamañoTotalDescarga(List<string> archivos, int Version)
        {
            long total_bytes = 0;
            //sacamos los diferentes sub-directorios
            Dictionary<string, List<string>> lista = new Dictionary<string, List<string>>();

            foreach (string nfile in archivos)
            {
                string file = (nfile.TrimStart(new char[] { '\\', '/' }).Replace("\\", "/"));
                if (!file.ToLower().Trim().StartsWith("bin"))
                    file = "Bin/" + file;
                string[] splitted = file.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                string r = string.Empty;
                for (int n = 0; n < splitted.Length - 1; n++)
                    r += splitted[n] + "/";

                if (lista.ContainsKey(r))
                    lista[r].Add(splitted[splitted.Length - 1].ToLower().Trim());
                else
                    lista.Add(r, new List<string>() { splitted[splitted.Length - 1].ToLower().Trim() });
            }

            //para cada sub-directorio.
            foreach (var item in lista)
            {
                string ruta = PrepPath(Version.ToString().PadLeft(10, '0')) + PrepPath(item.Key);
                string[] listado;
                Listar(ruta, out listado);
                foreach (string listado_item in listado)
                {
                    var r = new Regex(@"<A[^>]*>(.*?)</A>").Match(listado_item);
                    //-
                    if (r.Success && item.Value.Contains(r.Groups[1].Value.ToLower().Trim()))
                    {
                        string[] campos = listado_item.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        for (int n = 0; n < campos.Length; n++)
                            if (campos[n].StartsWith("<"))
                                total_bytes += Convert.ToInt64(campos[n - 1]);

                    }
                }
            }

            return total_bytes;
        }

        public string[] ObtenerListaFicheros(string RutaRelativa, int Version, bool IncluirSubDirectorios)
        {
            string ruta = PrepPath(Version.ToString().PadLeft(10, '0')) + PrepPath(RutaRelativa);
            var lista = ObtenerListaFicherosRecursivo(ruta, IncluirSubDirectorios);
            for (int n = 0; n < lista.Count; n++)
                lista[n] = lista[n].Replace(ruta, "");
            lista.Reverse();
            return lista.ToArray();
        }

        private List<string> ObtenerListaFicherosRecursivo(string ruta, bool IncluirSubDirectorios)
        {
            string[] list;
            Listar(ruta, out list);
            List<string> result = new List<string>();

            foreach (string item in list)
            {
                var r = new Regex(@"<A[^>]*>(.*?)</A>").Match(item);

                if (item.Contains("&lt;dir&gt;"))
                {
                    if (r.Groups.Count > 1 && r.Groups[1].Success && IncluirSubDirectorios)
                        result.AddRange(ObtenerListaFicherosRecursivo(PrepPath(PrepPath(ruta) + r.Groups[1].Value), true));
                }
                else
                {
                    result.Add(PrepPath(ruta) + r.Groups[1].Value);
                }
            }

            return result;

        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Avaliacao.WorkinHub.Web.Helpers
{
    public sealed class FileHelper
    {
        public static bool IsValidFile(string path)
        {
            var file = ReadFile(path).Take(1).ToList();
            var item = file[0].Split('\t');
            if (item[0].Contains("Comprador"))
                return true;
            else
                return false;

        }

        public static IEnumerable<string> ReadFile(string path)
        {
            return File.ReadAllLines(path).ToList();
        }

        public static string CombinePath(string path, string fileName)
        {
            return Path.Combine(System.Web.HttpContext.Current.Server.MapPath(path),
                                Path.GetFileName(string.Format("{0}-{1}", DateTime.Now.ToString("ddMMyyyy-hhmmss"), fileName)));
        }
    }
}
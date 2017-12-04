using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DL1
{
    static class ConstantValue
    {
        public const string config_db = "config.json";

        public static string APP_PATH = string.Empty;
        static ConstantValue()
        {
            //get path
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var exePath = new UriBuilder(codeBase).Path;
            APP_PATH = Path.GetDirectoryName(exePath);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace HW_2_3_Chernysh.Logger
{
    internal class Json
    {

        public static string JsonLogger(Result log)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            var asJson = JsonSerializer.Serialize(log, options);

            return asJson;
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    class Ex1
    {

        public DataTable getProfStandarts(JObject json)
        {
            var profStandarts = json["content"]["section4"]["professionalStandards"].Select(p => p["content"].Value<string>());

            var dt = new DataTable();
            dt.Columns.Add("column1");

            foreach (var item in profStandarts)
            {
                dt.Rows.Add(item);
            }

            return dt;
        }
    }
}

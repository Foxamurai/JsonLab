using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    class Ex4
    {
        public DataTable getSubjectsEx4(JObject json, int termNumber) {
            var dt = new DataTable();
            dt.Columns.Add("Шифр");
            dt.Columns.Add("Название дисциплины");

            var subjects = json["content"]["section5"]["eduPlan"]["block1"]["subrows"].Where(s =>Boolean.Parse(s["terms"][termNumber-1].ToString()) == true);

            foreach (var item in subjects)
            {
                dt.Rows.Add(new object[] {
                    item["index"].Value<string>(),
                    item["title"].Value<string>()
                });
            }

            return dt;
        }
    }
}

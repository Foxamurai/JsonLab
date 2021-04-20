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
            var profStandarts = json["content"]["appendix2"]["profStandart"]["professionalArea"].Select(p => new
            {
                code = p["code"].Value<string>(),
                name = p["title"].Value<string>()
            });

            var dt = new DataTable();
            dt.Columns.Add("Код");
            dt.Columns.Add("Название");

            foreach (var item in profStandarts)
            {

                dt.Rows.Add(new object[] {
                    item.code,
                    item.name
                });
            }

            return dt;
        }
    }
}

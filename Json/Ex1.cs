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
            var appendix2Elements = json["content"]["appendix2"].Select(p => p);

            var dt = new DataTable();
            dt.Columns.Add("Код");
            dt.Columns.Add("Название");

            var profStandarts = new List<object>();

            foreach (var item in appendix2Elements)
            {

                dt.Rows.Add(new object[] {
                    item["profStandard"]["code"].Value<string>(),
                    item["profStandard"]["title"].Value<string>(),
                });
               
            }         
               
            return dt;
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    class Ex2
    {

        public DataTable getCompitencyIndicators(JObject json, string compCode) {
            var dt = new DataTable();
            dt.Columns.Add("Индикаторы достижений");

            var indicators = new List<string>();

            var compType = "";
            if (compCode.StartsWith("УК"))
            {
                compType = "universalCompetencyRows";                
            }
            else if (compCode.StartsWith("ОПК"))
            {
                compType = "commonCompetencyRows";                
            }

            var comp = json["content"]["section4"][compType].FirstOrDefault(c => c["competence"]["code"].Value<string>() == compCode);
            indicators.Add(comp["competence"]["title"].Value<string>());

            foreach (var item in comp["indicators"])
            {
                indicators.Add(item["content"].Value<string>());
            }

            foreach (var item in indicators)
            {
                dt.Rows.Add(new object[] {
                    item
                });
            }

            return dt;
        }
    }
}

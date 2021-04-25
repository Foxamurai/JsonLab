using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    class Ex3
    {
        public DataTable getSubjectInfo(JObject json, string subjName)
        {
            var dt = new DataTable();
            dt.Columns.Add("Параметр");
            dt.Columns.Add("Информация");

            var subject = json["content"]["section5"]["eduPlan"]["block1"]["subrows"].FirstOrDefault(s => s["title"].Value<string>() == subjName);

            var subjInfo = new Dictionary<String, String>();

            subjInfo[subject["index"].Value<string>()] = subject["title"].Value<string>();
            subjInfo["Цель"] = new string(subject["description"].Value<string>().Skip(3).TakeWhile(c => c != '.').ToArray());
            var competencies = "";
            foreach (var item in subject["competences"])
            {
                competencies += item["code"].Value<string>() + " ";
            }

            subjInfo["Компетенции"] = competencies;
            subjInfo["З.Е."] = subject["unitsCost"].Value<string>();
            var terms = "";
            var termNumber = 1;
            foreach (var item in subject["terms"])
            {                
                if (Boolean.Parse(item.ToString()))
                {
                    terms += termNumber + " ";
                }

                termNumber += 1;
            }
            subjInfo["Семестры"] = terms;

            foreach (var item in subjInfo.Keys)
            {
                dt.Rows.Add(new object[] {
                    item,
                    subjInfo[item]
                });
            }

            return dt;

        }
    }
}

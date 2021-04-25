using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    class Ex5
    {
        public DataTable getEducationalProccessEx5(JObject json, int course)
        {
            var dt = new DataTable();
            dt.Columns.Add("Вид обучения");
            dt.Columns.Add("Продолжительность");
            dt.Columns.Add("Количество недель");

            var edType = new Dictionary<string, string>();
            edType["Б1"] = "Теоретическое обучение";
            edType["Б2"] = "Практика";
            edType["Э"] = "Промежуточная аттестация";
            edType["К"] = "Каникулы";
            edType["У"] = "Учебная практика";
            edType["П"] = "Производственная практика";
            edType["НИР"] = "Научно-исследовательская работа";
            edType["Д"] = "Государственная итоговая аттестация";

            var weekActivity = json["content"]["section5"]["calendarPlanTable"]["courses"][course-1]["weekActivityIds"];

            var currentType = weekActivity[0];
            var weekCounter = 0;
            var startDate = DateTime.Parse("01.09.2020");
            var endDate = DateTime.Parse("01.09.2020");            

            foreach (var item in weekActivity)
            {
                if (item.Equals(currentType))
                {
                    weekCounter += 1;
                    endDate = endDate.AddDays(7);
                }
                else
                {
                    dt.Rows.Add(new object[] {
                        edType[currentType.ToString()],
                        startDate.ToShortDateString() + " - " + endDate.AddDays(-3).ToShortDateString(),
                        weekCounter
                    });

                    startDate = endDate.AddDays(-1);
                    currentType = item;
                    weekCounter = 1;
                }
            }

            return dt;
        }
    }
}

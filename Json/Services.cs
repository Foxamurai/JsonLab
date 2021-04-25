using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    class Services
    {        

        public string[] getCompetenciesEx2(JObject json) {
            var universalCompetencyRows = json["content"]["section4"]["universalCompetencyRows"];
            var cometencies = new List<string>();
            foreach (var item in universalCompetencyRows)
            {
                cometencies.Add(item["competence"]["code"].Value<string>());
            }

            var commonCompetencyRows = json["content"]["section4"]["commonCompetencyRows"];
            foreach (var item in commonCompetencyRows)
            {
                cometencies.Add(item["competence"]["code"].Value<string>());
            }

            return cometencies.ToArray();
        }


    }
}

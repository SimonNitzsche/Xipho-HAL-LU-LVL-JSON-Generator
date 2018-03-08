using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Xipho_HAL_LU_LVL_JSON_Generator {
    public static class GithubAPI {
        public static string apiURL = "https://api.github.com/";
        public static string apiRepoURL = apiURL + "repos/" + Properties.Resources.repoOwner + "/" + Properties.Resources.repoName;

        public static string[] getContributors() {
            string apiPath = apiRepoURL+"/contributors";

            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            string apiResponse = webClient.DownloadString(apiPath);
            JArray json = JArray.Parse(apiResponse);

            string[] output = new string[json.Count];
            for(int i = 0; i<json.Count; ++i) {
                output[i] = json[i]["login"].ToString();
            }

            return output; 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Discord_User_Info.Classes
{
    class Discord
    {
        public static string get_info_by_id(string id)
        {
            JObject obj;
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Set("Authorization", "Bot ODkwMDEyNzU4NzU2NzIwNjcx.YUpm-Q.1j1BVbLTl2zBZRjFMayvPRvzzQo");
                try
                {
                    string res = wc.DownloadString($"https://discord.com/api/v8/users/{id}");
                    obj = JObject.Parse(res);
                    obj.Add(new JProperty("status", "ok"));
                    return obj.ToString();
                }
                catch (Exception)
                {
                    obj = JObject.Parse("{\"status\": \"notok\"}");
                    return obj.ToString();
                }
            }
        }

        public static string get_info_by_token(string token)
        {
            JObject obj;
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Set("Authorization", token);
                wc.Headers.Set("Content-Type", "application/json");
                try
                {
                    byte[] res = wc.DownloadData($"https://discord.com/api/v6/users/@me");
                    string response = Encoding.ASCII.GetString(res);
                    obj = JObject.Parse(response);
                    obj.Add(new JProperty("token", token));
                    obj.Add(new JProperty("status", "ok"));
                    return obj.ToString();
                }
                catch (Exception)
                {
                    obj = JObject.Parse("{\"status\": \"notok\"}");
                    return obj.ToString();
                }
            }
        }
    }
}

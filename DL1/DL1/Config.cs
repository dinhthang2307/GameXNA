using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;

namespace DL1
{
    class Config : IDisposable
    {
        //~Config() { }
        private static Config _instance = null;
        public static Config Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Config();
                return _instance;
            }
        }
        public JObject jsonCfg = null;
        private Config()
        {

        }
        public void Load()
        {
            var path = $"{ConstantValue.APP_PATH}\\{ConstantValue.config_db}";
            var jsonText = File.ReadAllText(path);
            jsonCfg = JObject.Parse(jsonText);
           
        }
        public void Save()
        {
            var path = $"{ConstantValue.APP_PATH}\\{ConstantValue.config_db}";
            jsonCfg["scaleX"] = 1.2;
            File.WriteAllText(path, jsonCfg.ToString());
        }
        public string[] LoadUnitTextures(string unitName)
        {
            //buoi2-A 1:01:5
            //JToken tempTok = 
            //JArray unitArr = tempTok as JArray;
             JToken unitArr = jsonCfg["units"];
             JToken WalkingManArr = unitArr[unitName];
            string[] retVal = WalkingManArr.Select(v => v.ToString()).ToArray();
            return retVal;
        }
        
        public void Dispose()
        {
            jsonCfg = null;
            GC.Collect();
        }
    }
}

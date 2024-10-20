using System.IO;
using Newtonsoft.Json;

namespace MonsterDuel
{
    public class SaveData
    {
        public string Name { get; set; }
        public string SavedDate { get; set; }
        public string SavedTime { get; set; }
    }

    public static class SaveDataTools
    {
        public static void Save(string filepath, SaveData data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filepath, json);
        }

        public static SaveData Read(string filepath)
        {
            string json = File.ReadAllText(filepath);
            return JsonConvert.DeserializeObject<SaveData>(json);
        }
    }
}
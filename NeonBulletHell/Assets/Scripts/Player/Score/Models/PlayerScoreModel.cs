using Newtonsoft.Json;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.Networking;

public partial class PlayerScoreModel 
{
	[JsonProperty("HighScore")]
	public int HighScore;

	public static PlayerScoreModel FromJson(string path)
	{
			if(File.Exists(path))
			{
				string json = File.ReadAllText(path);
				return JsonConvert.DeserializeObject<PlayerScoreModel>(json);
			}
			else
			{
				PlayerScoreModel model = new PlayerScoreModel();
				string json = JsonConvert.SerializeObject(model);
				File.WriteAllText(path, json);
				return model;
			}
	}
}

public static class Serializable
{
    public static void SaveToJson(this PlayerScoreModel model, string path)
	{
			if(File.Exists(path))
			{
				File.Delete(path);
			}
			string json = JsonConvert.SerializeObject(model);
			File.WriteAllText(path, json);
	}
}

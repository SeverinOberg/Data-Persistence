using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private string savePath;
    public string username;

    private void Start()
    {
        savePath = Application.persistentDataPath + "/data-persistence-save.json";
    }

    [System.Serializable]
    public class SaveData
    {
        public string username;
        public int score;

        public SaveData(string username, int score)
        {
            this.username = username;
            this.score = score;
        }
    }

    public void Save(SaveData data)
    {
        SaveData saveData = Load();
        if (saveData != null && saveData.score > data.score)
        {
            return;
        }
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(savePath, json);
    }

    public SaveData Load()
    {
        if (!File.Exists(savePath))
        {
            return null;
        }

        string json = File.ReadAllText(savePath);

        SaveData data = JsonUtility.FromJson<SaveData>(json);

        return data;
    }
}

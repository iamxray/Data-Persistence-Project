using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int highScore;
    public string highScoreName;
    public string enterName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }


    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string enterName;
        public string highScoreName;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.enterName = enterName;
        data.highScoreName = highScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            enterName = data.enterName;
            highScoreName = data.highScoreName;
        }
    }
}

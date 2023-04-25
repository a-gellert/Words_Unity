using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;

public static class SaveLoad
{
    private static int lives_s = 0;
    private static int coins_s = 0;
    private static List<bool> levelStates_s;


    public static void SaveAll(int lives, int coins, List<bool> levelStates)
    {
        lives_s = lives;
        coins_s = coins;
        levelStates_s = levelStates;
        SaveGame();
    }
    public static void Preload()
    {
        LoadGame();
    }
    public static int LoadCoins()
    {
        return coins_s;
    }
    public static int LoadLives()
    {
        return lives_s;
    }
    public static List<bool> LoadLevelsState()
    {
        return levelStates_s;
    }

    private static void SaveGame()
    {
        SaveData data = new SaveData();
        data.savedCoins = coins_s;
        data.savedLives = lives_s;
        data.savedLevelState = levelStates_s;

        var json = JsonUtility.ToJson(data);

        FileStream file = File.Create(Application.persistentDataPath
            + "/data.ths");
        byte[] bytes = Encoding.ASCII.GetBytes(json);
        file.Write(bytes, 0, bytes.Length);
        file.Close();
        Debug.Log("Game data saved!");

    }

    private static void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
                     + "/data.ths"))
        {
            var bytes = File.ReadAllBytes(Application.persistentDataPath
                     + "/data.ths");
            string text = Encoding.ASCII.GetString(bytes);

            var json = JsonUtility.FromJson<SaveData>(text);
            coins_s = json.savedCoins;
            lives_s = json.savedLives;
            levelStates_s = json.savedLevelState;
        }
        else
        {
            lives_s = 5;
            coins_s = 0;
            levelStates_s = LevelManager.Instance.levelsState;
        }
        Debug.Log("Game data loaded!");

    }
}

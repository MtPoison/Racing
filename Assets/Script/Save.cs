using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour
{
    private string filePath;
    private int i;

    // Classe pour sauvegarder les scores
    [System.Serializable]
    private class ScoreData
    {
        public Dictionary<int, int> scores = new Dictionary<int, int>();
    }

    private ScoreData data;

    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "scoreData.json");

        if (IsFileCreated())
        {
            LoadScore();
        }
        else
        {
            data = new ScoreData();
            Debug.Log("Aucun fichier trouv�. Un nouveau fichier sera cr��.");
        }
    }

    public void SaveScore(int newScore)
    {
        i = PlayerPrefs.GetInt("MapChoice", 0);


        data.scores[i]= newScore;

        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(filePath, jsonData);

        Debug.Log($"Score sauvegard� pour Map {i} : {newScore}");
    }

    public int LoadScore()
    {
        if (IsFileCreated())
        {
            string jsonData = File.ReadAllText(filePath);
            data = JsonUtility.FromJson<ScoreData>(jsonData);

            i = PlayerPrefs.GetInt("MapChoice", 0);

            if (data.scores.ContainsKey(i))
            {
                Debug.Log($"Scores charg�s pour Map {i} : {string.Join(", ", data.scores[i])}");
                return data.scores[i];
            }
            else
            {
                Debug.LogWarning($"Aucun score trouv� pour Map {i}.");
                return 0;
            }
        }
        else
        {
            Debug.LogWarning("Tentative de chargement d'un fichier inexistant.");
            return 0;
        }
    }

    private bool IsFileCreated()
    {
        return File.Exists(filePath);
    }
}

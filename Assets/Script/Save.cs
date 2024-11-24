using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Save : MonoBehaviour
{
    [System.Serializable]
    public class CardData
    {
        public int cardID; 
        public int score;      
    }

    public class CardCollection
    {
        public List<CardData> cards = new List<CardData>();
    }
    private string savePath;
    private CardCollection cardCollection;

    void Start()
    {
        savePath = Application.persistentDataPath + "/cards.json";
        LoadData();
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(cardCollection, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Card data saved to " + savePath);
    }

    public void LoadData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            cardCollection = JsonUtility.FromJson<CardCollection>(json);
            Debug.Log("Card data loaded.");
        }
        else
        {
            cardCollection = new CardCollection();
            Debug.LogWarning("No save file found. Initializing new collection.");
        }
    }

    public void UpdateCardScore(int cardID, int newScore)
    {
        CardData card = cardCollection.cards.Find(c => c.cardID == cardID);

        if (card != null)
        {
            card.score = newScore;
        }
        else
        {
            cardCollection.cards.Add(new CardData { cardID = cardID, score = newScore });
        }

        SaveData(); 
    }

    public int GetCardScore(int cardID)
    {
        CardData card = cardCollection.cards.Find(c => c.cardID == cardID);
        return card != null ? card.score : 0; 
    }
}

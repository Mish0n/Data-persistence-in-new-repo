using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;


public class DataManager : MonoBehaviour
{
    
    public static DataManager Instance;
    public static string playerName;
    public TMP_InputField inputField;
    public GameObject textDisplay;
    public static int topScore;
    public static string topScorer;
    
    
    
    
    private void Awake()
    {
        if (Instance != null)
        {
        Destroy(gameObject);
        return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        
    }
    public void StoreName()
    {
        playerName = inputField.GetComponent<TMP_InputField>().text;
        textDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Elo " + playerName + ",byku.";
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
        
    }
    [System.Serializable]
    public class SaveScore
    {
        public int topScore;
        public string topScorer;
    }
    
    
    public static void SaveTopScore()
    {
        SaveScore data = new SaveScore();
        data.topScore = topScore;
        data.topScorer = topScorer;
        

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public static void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveScore data = JsonUtility.FromJson<SaveScore>(json);

            topScore = data.topScore;
            topScorer = data.topScorer;
        }
    }
    
}

//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;

//public class ScoreManager : MonoBehaviour
//{
//    private ScoreData sd;

//    void Awake()
//    {
//        var json = PlayerPrefs.GetString(key: "scores", defaultValue: "{}");
//        sd = JsonUtility.FromJson<ScoreData>(json);
//    }

//    public IEnumerable<Score> GetHighScores()
//    {
//        return sd.scores.OrderByDescending(keySelector: x :Score => x.score);
//    }

//    public void AddScore(Score score)
//    {
//        sd.scores.Add(score);
//    }

//    private void OnDestroy()
//    {
//        SaveScore();
//    }

//    public void SaveScore()
//    {
//        var json :string = JsonUtility.ToJson(sd);
//        PlayerPrefs.SetString("scores", json);
//    }
//}

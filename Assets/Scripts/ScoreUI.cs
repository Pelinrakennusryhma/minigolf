//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEditor.UI;
//using UnityEngine;

//public class ScoreUI : MonoBehaviour
//{
//    public RowUI rowUI;
//    public ScoreManager scoreManager;

//    void Start()
//    {
//        var scores :Score[] = scoreManager.GetHighScores().ToArray();
//        for (int i = 0; i < scores.Lenght; i++) 
//        {
//            var row = Instantiate(rowUI, transform).GetComponent<RowUI>();
//            row.rank.text = (i + 1).ToString();
//            row.name.text = scores[i].name();
//            row.score.text = scores[i].score.ToString();
//        }
//    }
//}

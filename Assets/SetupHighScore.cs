using UnityEngine;
using TMPro;

public class SetupHighScore : MonoBehaviour
{
    [SerializeField] TMP_Text rank;
    [SerializeField] TMP_Text txtname;
    [SerializeField] TMP_Text score;

    public void setupscore(string strRank, string strName, string strScore ) {
        rank.text = strRank;
        txtname.text = strName;
        score.text = strScore;
    
    }



}

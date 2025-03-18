using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using TMPro;


public class SubmitScore : MonoBehaviour
{

    [SerializeField] TMP_InputField ScoreText;
    [SerializeField] TMP_Text leaderboard;
    public void SubmitScoreToServer()
    {

        int playerScore = int.Parse(ScoreText.text);

        PlayFabClientAPI.UpdatePlayerStatistics(new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> {
            new StatisticUpdate {
                StatisticName = "HighScore",
                Value = playerScore
            }
        }
        }, result => OnStatisticsUpdated(result), FailureCallback);
    }

    private void OnStatisticsUpdated(UpdatePlayerStatisticsResult updateResult)
    {
        Debug.Log("Successfully submitted high score");
    }

    private void FailureCallback(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    //Get the players with the top 10 high scores in the game
    public void RequestLeaderboard()
    {
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 10
        }, result => DisplayLeaderboard(result), FailureCallback2);
    }


    private void FailureCallback2(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }



    private void DisplayLeaderboard(GetLeaderboardResult result)
    {

        leaderboard.text = "";
        Debug.Log("Leaderboard:" + result.Leaderboard.Count);
        foreach (var obj in result.Leaderboard.ToArray())
        {
            Debug.Log(obj.Position + ":" + obj.DisplayName + ":" + obj.StatValue);
            leaderboard.text += obj.Position + " " + obj.DisplayName + " " + obj.StatValue + "\n";
        }

    }



}

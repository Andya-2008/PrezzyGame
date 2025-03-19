using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayFabLogin : MonoBehaviour
{
    [SerializeField]  TMP_Dropdown ddCategory;
    [SerializeField] GameObject hs;
    [SerializeField] Transform scrollviewContent;
    public void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "1C2F07";
        }
        var request = new LoginWithCustomIDRequest { CustomId = "Freshmen", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginLeaderboard, OnLoginFailure);
        
        
    }

    public void Login() {
        string strCat = ddCategory.options[ddCategory.value].text;
        var request = new LoginWithCustomIDRequest { CustomId = strCat, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
        

    }

    private void OnLoginLeaderboard(LoginResult result)
    {
        Debug.Log("Congratulations, You're logged in!");
        RequestLeaderboard();
    }

    private void OnLoginSuccess(LoginResult result)
    {
        
        string strCat = ddCategory.options[ddCategory.value].text;
        Debug.Log("Congratulations, You're logged in as " + strCat + "!");
        PlayerPrefs.SetString("Association", strCat);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);

    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your login call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }


    public void RequestLeaderboard()
    {
        Debug.Log("Request Leaderboard");
        PlayFabClientAPI.GetLeaderboard(new GetLeaderboardRequest
        {
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 5
        }, result => DisplayLeaderboard(result), FailureCallback2);
    }


    private void FailureCallback2(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your API call. Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }



    private void DisplayLeaderboard(GetLeaderboardResult result)
    {
        Debug.Log("Leaderboard:" + result.Leaderboard.Count);
        foreach (var obj in result.Leaderboard.ToArray())
        {
            GameObject go = Instantiate(hs, scrollviewContent);
            Debug.Log(obj.Position + ":" + obj.DisplayName + ":" + obj.StatValue);
            go.GetComponent<SetupHighScore>().setupscore((obj.Position+1).ToString(), obj.DisplayName.ToString(), obj.StatValue.ToString());
            //leaderboard.text += obj.Position + " " + obj.DisplayName + " " + obj.StatValue + "\n";
        }

    }


}
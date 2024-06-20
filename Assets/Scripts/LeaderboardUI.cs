using System.Collections;
using System.Collections.Generic;
using Unity.Services.Leaderboards;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LeaderboardUI : MonoBehaviour
{
    public GameObject TextPrefab;
    public GameObject YourScore;

    async void Start()
    {
        var scoresResponse =
            await LeaderboardsService.Instance.GetScoresAsync(LeaderboardManager.LeaderboardId);

        var myScore = await LeaderboardsService.Instance.GetPlayerScoreAsync(LeaderboardManager.LeaderboardId);

        YourScore.GetComponent<LeaderText>().SetData(myScore.PlayerName, myScore.Score);

        for(int i = 0; i < 10 && i < scoresResponse.Total; i++)
        {
            var score = scoresResponse.Results[i];

            var instance = Instantiate(TextPrefab, transform);
            instance.GetComponent<LeaderText>().SetData(score.PlayerName, score.Score);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("Screen");
    }
}

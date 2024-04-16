using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LeaderboardManager : MonoBehaviour
{
    public const string LeaderboardId = "grab-the-health-potion-leaderboard-debug";
    string VersionId { get; set; }
    int Offset { get; set; }
    int Limit { get; set; }
    int RangeLimit { get; set; }
    List<string> FriendIds { get; set; }

    private static LeaderboardManager instance;

    bool failedLogin = false;
    async void Awake()
    {
        if (instance == null)
        { 
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject);
            return;
        }

        await UnityServices.InitializeAsync();
        await SignInAnonymously();
    }

    async Task SignInAnonymously()
    {
        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in as: " + AuthenticationService.Instance.PlayerId);
        };
        AuthenticationService.Instance.SignInFailed += s =>
        {
            failedLogin = true;
        };

        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void AddScore(int score)
    {
        if (failedLogin)
            return;

        var scoreResponse = await LeaderboardsService.Instance.AddPlayerScoreAsync(LeaderboardId, score);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }
}

using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CloudServices : MonoBehaviour
{
    public async Task RealizarLogin()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Sign in anonymously succeeded!");

            if (AuthenticationService.Instance.PlayerName == "" || AuthenticationService.Instance.PlayerName == null)
            {
                await AtualizarUserName("Player");
            }

            // Shows how to get the playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

        }
        catch
        {

        }
    }

    public async Task AtualizarUserName(string username)
    {
        await AuthenticationService.Instance.UpdatePlayerNameAsync(username);
    }

    public string GetUserName()
    {
        return AuthenticationService.Instance.PlayerName;
    }

    public async Task RegistrarNovaPontuacao(string nomeTabela, int pontuacao)
    {
        await LeaderboardsService.Instance.AddPlayerScoreAsync(nomeTabela, pontuacao);
    }

    public async Task<List<JogadorRanking>> GetRanking(string tabela)
    {
        var scoresResponse = await LeaderboardsService.Instance.GetScoresAsync(tabela);

        List<LeaderboardEntry> list = scoresResponse.Results;
        List<JogadorRanking> cards = new List<JogadorRanking>();

        foreach (LeaderboardEntry i in list)
        {
            JogadorRanking jogadorRanking = new JogadorRanking();
            jogadorRanking.posicao = i.Rank + 1;
            jogadorRanking.username = i.PlayerName;
            jogadorRanking.pontuacao = (int) i.Score;

            cards.Add(jogadorRanking);
        }

        return cards;
    }
}

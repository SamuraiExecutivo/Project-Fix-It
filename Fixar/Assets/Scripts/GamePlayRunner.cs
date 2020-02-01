using UnityEngine;

public class GamePlayRunner : MonoBehaviour
{
    public MiniGameInfo[] miniGames;
    MiniGameBase chosen;
    void Start()
    {
        Chose();
    }
    void Chose(){
        chosen=miniGames[Random.Range(0,miniGames.Length)].GetMiniGame();
        chosen.Create();
        chosen.Load();
    }
    void Update()
    {
        if(chosen!=null && !chosen.ended)chosen.Update();
    }
}

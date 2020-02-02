using UnityEngine.UI;
using UnityEngine;

public class GamePlayRunner : MonoBehaviour
{
    public MiniGameInfo[] miniGames;
    MiniGameBase chosen;
    public Slider slider;
    public Text counter;
    public Image win,lose;
    float timer;
    void Start()
    {
        Chose();
    }
    void Chose(){
        chosen?.Clear();
        chosen=miniGames[Random.Range(0,miniGames.Length)].GetMiniGame();
        chosen.Create();
        slider.value = slider.maxValue = chosen.timer;
        win.enabled=lose.enabled=false;
        timer=2;
    }
    void Update()
    {
        if(chosen!=null && !chosen.ended){
            chosen.Update();
            slider.value=chosen.timer;
            counter.text=(Mathf.RoundToInt(slider.value*100)/100f).ToString();
        }
        else{
            timer-=Time.deltaTime;
            win.enabled=chosen.state==MiniGameBase.State.won;
            lose.enabled=chosen.state==MiniGameBase.State.lost;
            slider.gameObject.SetActive(timer<=0);
            if(timer<=0){
                Chose();
            }
        }
    }
}

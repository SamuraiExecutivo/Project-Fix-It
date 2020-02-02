using UnityEngine;
using UnityEngine.UI;

public class GamePlayRunner : MonoBehaviour {
    
    public MiniGameInfo[] miniGames;
    public MiniGameInfo mainGame;
    MiniGameBase chosen;
    public Slider slider;
    public Text counter;
    public Image win, lose;
    float timer;
    int id;

    void Start () {
        chosen = mainGame.GetMiniGame ();
        chosen.Create ();
        slider.value = slider.maxValue = chosen.timer;
        win.enabled = lose.enabled = false;
        timer = 2;
    }

    void Chose () {
        chosen?.Clear ();
        int i = id;
        do id = Random.Range (0, miniGames.Length);
        while (id == i);
        chosen = miniGames[id].GetMiniGame ();
        chosen.Create ();
        slider.value = slider.maxValue = chosen.timer;
        win.enabled = lose.enabled = false;
        timer = 2;
    }

    void Update () {
        if (chosen != null && !chosen.ended) {
            chosen.Update ();
            slider.value = chosen.timer;
            counter.text = (Mathf.RoundToInt (slider.value * 100) / 100f).ToString ();
        } else {
            timer -= Time.deltaTime;
            win.enabled = chosen.state == MiniGameBase.State.won;
            lose.enabled = chosen.state == MiniGameBase.State.lost;
            slider.gameObject.SetActive (timer <= 0);
            if (timer <= 0) {
                Chose ();
            }
        }
    }
}
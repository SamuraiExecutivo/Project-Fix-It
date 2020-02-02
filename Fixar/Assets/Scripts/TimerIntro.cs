using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerIntro : MonoBehaviour {

    float timer;
    public GameObject planetex, jcboladex;

    void Awake () {
        timer = 0;
        planetex.SetActive(true);
        jcboladex.SetActive(false);
    }

    void Update () {
        timer += Time.deltaTime;
        
        if (timer >= 4.25) {
            planetex.SetActive(false);
            jcboladex.SetActive(true);
            if (timer >= 7.5) {
                jcboladex.SetActive(false);
                SceneManager.LoadScene (2);
            }
        }
    }
}
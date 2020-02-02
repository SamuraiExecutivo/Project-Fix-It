using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {

    public GameObject logo;
    float timer;

    void Start () {
        timer = 0;
        logo.SetActive (true);
    }

    void Update () {
        timer += Time.deltaTime;

        if (timer >= 2.8) {
            logo.SetActive (false);
            SceneManager.LoadScene (1);
        }
    }
}
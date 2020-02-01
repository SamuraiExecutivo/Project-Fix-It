using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeymapTest : MonoBehaviour {

    AudioSource keyMusic;

    void Keymap () {
        if (Input.GetKeyDown ("q")) {
            AudioManager.PlaySFX (0);
        }
        if (Input.GetKeyDown ("w")) {
            AudioManager.PlaySFX (1);
        }
        if (Input.GetKeyDown ("e")) {
            AudioManager.PlaySFX (2);
        }
        if (Input.GetKeyDown ("r")) {
            AudioManager.PlaySFX (3);
        }
        if (Input.GetKeyDown ("u")) {
            AudioManager.PlaySFX (4);
        }
        if (Input.GetKeyDown ("i")) {
            AudioManager.PlaySFX (5);
        }
        if (Input.GetKeyDown ("o")) {
            AudioManager.PlaySFX (6);
        }
        if (Input.GetKeyDown ("p")) {
            AudioManager.PlaySFX (7);
        }
    }

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        Keymap ();
    }
}
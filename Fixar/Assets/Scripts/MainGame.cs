using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MiniGameBase {

    float[] fixers = { 4, 4, 4, 4, 4 };
    bool[] hasFixers = { false, false, false, false, false };
    float[] objLife = { 20, 20, 20, 20, 20 };
    bool winCondition;

    public override void Create () {
        timer = 20;
        objects = new GameObject[sprites.Length];
        for (int i = 0; i < sprites.Length - 1; i++) {
            objects[i] = new GameObject ("object" + i);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];
            objects[i].transform.position = new Vector3 (i * 5 - 10, -3);
        }
    }

    public override void Update () {
        Keymap ();

        for (int i = 0; i < fixers.Length; i++) {
            hasFixers[i] = fixers[i] >= 1 ? true : false;
            fixers[i] += Random.Range (3f, 7f) * Time.deltaTime;
        }

        Timer ();
    }

    protected override void Timer () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            for (int i = 0; i < objLife.Length; i++) {
                if (objLife[i] >= 20) {
                    winCondition = true;
                } else {
                    winCondition = false;
                    break;
                }
            }
<<<<<<< HEAD
            if (winCondition) {
                SceneManager.LoadScene (2);
                End (State.won);
            } else End (State.lost);
=======
            if (winCondition) 
            End (State.won);
            else End (State.lost);
>>>>>>> parent of 983f713... Merge pull request #1 from SamuraiExecutivo/Yuri
        }
    }

    void ChristController () {

    }

    void Keymap () {

        if (Input.GetKeyDown ("up")) {
            if (hasFixers[0]) {
                AudioManager.PlaySFX (0);
                fixers[0] -= 1;
                objLife[0] += 1;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("down")) {
            if (hasFixers[1]) {
                AudioManager.PlaySFX (1);
                fixers[1] -= 1;
                objLife[1] += 1;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("left")) {
            if (hasFixers[2]) {
                AudioManager.PlaySFX (3);
                fixers[2] -= 1;
                objLife[2] += 1;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("right")) {
            if (hasFixers[3]) {
                AudioManager.PlaySFX (5);
                fixers[3] -= 1;
                objLife[3] += 1;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("space")) {
            if (hasFixers[4]) {
                AudioManager.PlaySFX (6);
                fixers[4] -= 1;
                objLife[4] += 1;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

    }

}
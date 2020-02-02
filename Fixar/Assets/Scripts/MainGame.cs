using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MiniGameBase {

    float[] fixers = { 4, 4, 4, 4, 4 };
    bool[] hasFixers = { false, false, false, false, false };
    float[] objLife = { 20, 20, 20, 20, 20 };
    bool winCondition;
    SpriteRenderer[] renderer;

    public override void Create () {
        timer = 20;
        objects = new GameObject[sprites.Length];
        for (int i = 0; i < sprites.Length - 3; i++) {
            objects[i] = new GameObject ("object" + i);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];
        }

        for (int i = 0; i < sprites.Length - 3; i++) {
            objects[i].transform.position = new Vector3 ((i % 5) * 5 - 10, -3, 50 + i * 2);
        }

        // for (int i = 0; i <= 5; i+=3) {
        //     renderer[i] = objects[i].AddComponent<SpriteRenderer>();
        //     renderer[i].sprite = sprites[i];
        //     renderer[i].transform.position = new Vector3 (i * 5 - 10, -4);
        // }
    }

    public override void Update () {
        Keymap ();
        BreakingRenderer ();

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
            if (winCondition) {
                End (State.won);
            } else End (State.lost);
        }
    }

    void ChristController () {

    }

    void BreakingRenderer () {
        for (int i = 0; i < objLife.Length; i++) {
            if (objLife[i] >= 20) {
                objects[i].transform.position = new Vector3 ((i % 5) * 5 - 10, -3, 10);
                objects[i + 5].transform.position = new Vector3 ((i % 5) * 5 - 10, -3, 50 + i * 2);
                objects[i + 10].transform.position = new Vector3 ((i % 5) * 5 - 10, -3, 70 + i * 2);
            } else if (objLife[i] > 10) {
                objects[i].transform.position = new Vector3 ((i % 5) * 5 - 10, -3, 50 + i * 2);
                objects[i + 5].transform.position = new Vector3 ((i % 5) * 5 - 10, -3, 10);
                objects[i + 10].transform.position = new Vector3 ((i % 5) * 5 - 10, -3, 50 + i * 2);
            } else {
                objects[i].transform.position = new Vector3 ((i % 5) * 5 - 10, -3, 50 + i * 2);
                objects[i + 5].transform.position = new Vector3 ((i % 5) * 5 - 10, -3, 50 + i * 2);
                objects[i + 10].transform.position = new Vector3 ((i % 5) * 5 - 10, -3, 10);
            }
        }
    }

    void Keymap () {

        if (Input.GetKeyDown ("up")) {
            if (hasFixers[0]) {
                AudioManager.PlaySFX (0);
                fixers[0] -= 1;
                objLife[0] += 2;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("down")) {
            if (hasFixers[1]) {
                AudioManager.PlaySFX (1);
                fixers[1] -= 1;
                objLife[1] += 2;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("left")) {
            if (hasFixers[2]) {
                AudioManager.PlaySFX (3);
                fixers[2] -= 1;
                objLife[2] += 2;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("right")) {
            if (hasFixers[3]) {
                AudioManager.PlaySFX (5);
                fixers[3] -= 1;
                objLife[3] += 2;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("space")) {
            if (hasFixers[4]) {
                AudioManager.PlaySFX (6);
                fixers[4] -= 1;
                objLife[4] += 2;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGame : MiniGameBase {

    float[] fixers = { 4, 4, 4, 4, 4 };
    bool[] hasFixers = { false, false, false, false, false };
    float[] objLife = { 20, 20, 20, 20, 20 };
    bool winCondition;
    SpriteRenderer renderer;

    public override void Create () {
        timer = 20;
        objects = new GameObject[sprites.Length];
        for (int i = 0; i < sprites.Length - 3; i++) {
            objects[i] = new GameObject ("object" + i);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];
        }

        for (int i = 0; i < sprites.Length - 3; i++) {
            objects[i].transform.position = new Vector3 ((i % 5) * 5 - 10, -7, 50 + i * 2);
        }
        objects[15] = new GameObject ("JC");
        renderer = objects[15].AddComponent<SpriteRenderer> ();
        renderer.sprite = sprites[15];
        renderer.transform.position = new Vector3 (0, 0, 20);

    }

    public override void Update () {
        Keymap ();
        BreakingRenderer ();
        ChristController ();

        for (int i = 0; i < fixers.Length; i++) {
            hasFixers[i] = fixers[i] >= 1 ? true : false;
            fixers[i] += Random.Range (1f, 3f) * Time.deltaTime;
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
        renderer.sprite = sprites[(int) (3 * Time.time % 3 + 15)];
        Vector3 left, right, speed, vspeed;
        bool lerpDir = false;
        bool lerdVert = false;
        vspeed = new Vector3 (0, 1f);
        speed = new Vector3 (3f, 0);
        left = new Vector3 (-10, 0);
        right = new Vector3 (10, 0);

        if (objects[15].transform.position.x >= 9) lerpDir = false;
        if (objects[15].transform.position.x <= -9) lerpDir = true;

        if (objects[15].transform.position.y >= 4) lerdVert = false;
        if (objects[15].transform.position.y <= -1) lerdVert = true;

        if (lerpDir)
            objects[15].transform.position += speed * Time.deltaTime;
        else
            objects[15].transform.position -= speed * Time.deltaTime;

        if (lerdVert)
            objects[15].transform.position += vspeed * Time.deltaTime;
        else
            objects[15].transform.position -= vspeed * Time.deltaTime;
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
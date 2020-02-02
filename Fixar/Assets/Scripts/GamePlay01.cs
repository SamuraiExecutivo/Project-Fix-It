using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay01 : MiniGameBase {

    float fixers = 15;
    bool hasFixers;
    bool winCondition;

    public override void Create () {
        objects = new GameObject[sprites.Length];
        for (int i = 0; i < sprites.Length; i++) {
            objects[i] = new GameObject ("object" + i);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];
            objects[i].transform.localScale = Vector3.one * Random.Range (2, 4);
        }
        objects[0].transform.position = new Vector3 (0, 3);
        objects[1].transform.position = new Vector3 (0, -3);
        objects[2].transform.position = new Vector3 (-6, 0);
        objects[3].transform.position = new Vector3 (6, 0);

    }

    public override void Update () {
        Keymap ();
        hasFixers = fixers >= 1 ? true : false;
        fixers += 5 * Time.deltaTime;

        Timer ();

        if (objects[0].transform.localScale.x <= 0.1f && objects[1].transform.localScale.x <= 0.1f &&
            objects[2].transform.localScale.x <= 0.1f && objects[3].transform.localScale.x <= 0.1f)
            End (State.won);

    }

    protected override void Timer () {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            for (int i = 0; i < objects.Length; i++) {
                if (objects[i].transform.localScale.x < 0.2f) {
                    winCondition = true;
                } else {
                    winCondition = false;
                    break;
                }
            }

            if (winCondition) End (State.won);
            else End (State.lost);
        }
    }

    void Keymap () {

        if (hasFixers) {
            if (Input.GetKeyDown ("up") && objects[0].transform.localScale.x >= 0.1f) {
                AudioManager.PlaySFX (0);
                objects[0].transform.localScale -= new Vector3 (0.3f, 0.3f, 0.3f);
                fixers -= 1;
            }

            if (Input.GetKeyDown ("down") && objects[1].transform.localScale.x >= 0.1f) {
                AudioManager.PlaySFX (1);
                objects[1].transform.localScale -= new Vector3 (0.3f, 0.3f, 0.3f);
                fixers -= 1;
            }

            if (Input.GetKeyDown ("left") && objects[2].transform.localScale.x >= 0.1f) {
                AudioManager.PlaySFX (2);
                objects[2].transform.localScale -= new Vector3 (0.3f, 0.3f, 0.3f);
                fixers -= 1;
            }

            if (Input.GetKeyDown ("right") && objects[3].transform.localScale.x >= 0.1f) {
                AudioManager.PlaySFX (3);
                objects[3].transform.localScale -= new Vector3 (0.3f, 0.3f, 0.3f);
                fixers -= 1;
            }
        } else {
            if (Input.GetKeyDown ("up") || Input.GetKeyDown ("down") || Input.GetKeyDown ("left") || Input.GetKeyDown ("right"))
                AudioManager.PlaySFX (9);
        }

    }
}
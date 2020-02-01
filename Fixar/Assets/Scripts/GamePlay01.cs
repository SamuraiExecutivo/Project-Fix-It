using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay01 : MiniGameBase {

    float fixers = 4;
    bool hasFixers;
    bool winCondition;

    public override void Create () {
        objects = new GameObject[sprites.Length];
        for (int i = 0; i < sprites.Length; i++) {
            objects[i] = new GameObject ("object" + i);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];
            objects[i].transform.position = new Vector3 (Random.value * 4, -4 + Random.value % 2 * 8);
            objects[i].transform.localScale = Vector3.one * Random.value;
        }
    }

    public override void Update () {
        Keymap ();
        hasFixers = fixers >= 1 ? true : false;
        fixers += 5 * Time.deltaTime;

        Timer ();
        
        foreach (GameObject objeto in objects) {
            if (!(objeto.transform.localScale.x > 2f)) {
                winCondition = false;
            } else {
                winCondition = true;
                End (State.won);
            }
        }

    }

    void Keymap () {

        if (hasFixers) {
            if (Input.GetKeyDown ("up")) {
                AudioManager.PlaySFX (0);
                objects[0].transform.localScale += new Vector3 (0.2f, 0.2f, 0.2f);
                fixers -= 1;
            }

            if (Input.GetKeyDown ("down")) {
                AudioManager.PlaySFX (1);
                objects[1].transform.localScale += new Vector3 (0.2f, 0.2f, 0.2f);
                fixers -= 1;
            }

            if (Input.GetKeyDown ("left")) {
                AudioManager.PlaySFX (2);
                objects[2].transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
                fixers -= 1;
            }

            if (Input.GetKeyDown ("right")) {
                AudioManager.PlaySFX (3);
                objects[3].transform.localScale += new Vector3 (0.2f, 0.2f, 0.2f);
                fixers -= 1;
            }
        } else {
            if (Input.GetKeyDown ("up") || Input.GetKeyDown ("down") || Input.GetKeyDown ("left") || Input.GetKeyDown ("right"))
                AudioManager.PlaySFX (9);
        }

    }
}
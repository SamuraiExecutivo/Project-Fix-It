using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay01 : MiniGameBase {

    float fixers = 0;
    bool hasFixers;

    public override void Create () {
        objects = new GameObject[sprites.Length];
        for (int i = 0; i < sprites.Length; i++) {
            objects[i] = new GameObject ("object" + i);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];
            objects[i].transform.position = new Vector3 (i / 2 * 4, -4 + i % 2 * 8);
        }
    }

    public override void Update () {
        Keymap ();
        hasFixers = fixers >= 1 ? true : false;
        fixers += 1 * Time.deltaTime;
    }

    void Keymap () {

        if (hasFixers) {
            if (Input.GetKeyDown ("q")) {
                AudioManager.PlaySFX (0);
                objects[0].transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
                fixers -= 1;
            }

            if (Input.GetKeyDown ("w")) {
                AudioManager.PlaySFX (1);
                objects[1].transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
                fixers -= 1;
            }

            if (Input.GetKeyDown ("e")) {
                AudioManager.PlaySFX (2);
                objects[2].transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
                fixers -= 1;
            }

            if (Input.GetKeyDown ("r")) {
                AudioManager.PlaySFX (3);
                objects[3].transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
                fixers -= 1;
            }
        } else {
            if (Input.GetKeyDown ("q") || Input.GetKeyDown ("w") || Input.GetKeyDown ("e") || Input.GetKeyDown ("r"))
                AudioManager.PlaySFX (9);
        }

    }
}
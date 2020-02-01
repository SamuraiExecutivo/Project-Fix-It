using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay02 : MiniGameBase {

    bool winCondition;
    int objectMoving = 0;

    public override void Create () {
        objects = new GameObject[sprites.Length];
        for (int i = 0; i < sprites.Length; i++) {
            objects[i] = new GameObject ("object" + i);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];
            int ram = (int) Random.value * 4;
            // TODO ramdomizar posição
            objects[i].transform.position = new Vector3 (5 * i - 15, ram * i - 9);
            objects[i].transform.localScale = Vector3.one;
        }
    }

    public override void Update () {
        Keymap ();

        Timer ();

        int posY = (int) objects[0].transform.position.y;
        if ((objects[1].transform.position.y == posY) && (objects[2].transform.position.y == posY) && (objects[3].transform.position.y == posY)) {
            winCondition = true;
            End (State.won);
        } else {
            winCondition = false;
        }

    }

    void Keymap () {
        if (Input.GetKeyDown ("up")) {
            if (objects[objectMoving].transform.position.y < 15) {
                objects[objectMoving].transform.position += Vector3.up * 5;
                AudioManager.PlaySFX (0);
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("down")) {
            if (objects[objectMoving].transform.position.y > -5) {
                AudioManager.PlaySFX (1);
                objects[objectMoving].transform.position += Vector3.down * 5;
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("left")) {
            if (objectMoving > 0) {
                objectMoving--;
                AudioManager.PlaySFX (2);
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("right")) {
            AudioManager.PlaySFX (3);
            if (objectMoving < objects.Length) {
                objectMoving++;
                AudioManager.PlaySFX (2);
            } else {
                AudioManager.PlaySFX (9);
            }
        }

    }
}
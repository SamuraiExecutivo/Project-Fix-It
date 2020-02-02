using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay02 : MiniGameBase {

    bool winCondition;
    int objectMoving = 2;
    float[] posInit = {-5f, -1.5f, 2f, 5.5f };
    public GameObject selector;
    float posY;

    public override void Create () {
        selector = new GameObject ("selector");
        selector.AddComponent<SpriteRenderer> ().sprite = sprites[5];
        objects = new GameObject[sprites.Length];
        for (int i = 0; i < 5; i++) {
            objects[i] = new GameObject ("object" + i);
            int ram = (int) Random.Range (0f, 3f);
            objects[i].AddComponent<SpriteRenderer> ().sprite = sprites[i];

            if (i == 0) objects[i].transform.position = new Vector3 (3.5f * i - 7, posInit[0]);
            else if (i == 3) objects[i].transform.position = new Vector3 (3.5f * i - 7, posInit[2]);
            else objects[i].transform.position = new Vector3 (3.5f * i - 7, posInit[ram]);

            objects[i].transform.localScale = new Vector3 (1f, 1f);
        }
        selector.transform.position = objects[2].transform.position;
        selector.transform.localScale = new Vector3 (2f, 2f);
    }

    public override void Update () {
        Keymap ();
        selector.transform.position = objects[objectMoving].transform.position + Vector3.back;
        
        Timer ();

        if (state == State.lost) {
            Object.Destroy (selector);
        }

        posY = objects[0].transform.position.y;
        if ((objects[1].transform.position.y == posY) && (objects[2].transform.position.y == posY) &&
            (objects[3].transform.position.y == posY) && (objects[4].transform.position.y == posY)) {
            winCondition = true;
            End (State.won);
            Object.Destroy (selector);
        } else {
            winCondition = false;
        }

    }

    void Keymap () {
        if (Input.GetKeyDown ("up")) {
            if (objects[objectMoving].transform.position.y < posInit[3]) {
                objects[objectMoving].transform.position += Vector3.up * 3.5f;
                AudioManager.PlaySFX (0);
            } else {
                AudioManager.PlaySFX (9);
            }
        }

        if (Input.GetKeyDown ("down")) {
            if (objects[objectMoving].transform.position.y > posInit[0]) {
                AudioManager.PlaySFX (1);
                objects[objectMoving].transform.position += Vector3.down * 3.5f;
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
            if (objectMoving < objects.Length - 1) {
                objectMoving++;
                AudioManager.PlaySFX (3);
            } else {
                AudioManager.PlaySFX (9);
            }
        }

    }
}
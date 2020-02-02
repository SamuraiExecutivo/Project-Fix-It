using UnityEngine;

public class Quicky : MiniGameBase {
    int key, prevkey, damage = 10;
    SpriteRenderer renderer;
    public override void Create () {

        objects = new GameObject[2];

        objects[0] = new GameObject ("arrow");
        objects[0].AddComponent<SpriteRenderer> ().sprite = sprites[0];

        objects[1] = new GameObject ("building");
        renderer = objects[1].AddComponent<SpriteRenderer> ();
        renderer.sprite = sprites[1];
        prevkey = key = Random.Range (0, 4);
        objects[0].transform.rotation = Quaternion.Euler (0, 0, key * 90);
    }
    public override void Update () {
        if (KeyDown ()) {
            AudioManager.PlaySFX (key + 3);
            damage--;
            renderer.sprite = sprites[1 + ((10 - damage) / 5)];
            if (damage == 0) End (State.won);
            else {
                int i = key;
                do key = Random.Range (0, 4);
                while (key == i);
                objects[0].transform.rotation = Quaternion.Euler (0, 0, key * 90);
                prevkey = i;
            }
        }
        Timer ();
    }
    bool KeyDown () {
        switch (key) {
            case 0:
                return Input.GetKeyDown (KeyCode.UpArrow);
            case 1:
                return Input.GetKeyDown (KeyCode.LeftArrow);
            case 2:
                return Input.GetKeyDown (KeyCode.DownArrow);
            case 3:
                return Input.GetKeyDown (KeyCode.RightArrow);
            default:
                return false;
        }
    }
}
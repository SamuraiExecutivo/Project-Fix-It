using UnityEngine;

public class Quicky : MiniGameBase
{
    int  key,prevkey,damage=10;
    SpriteRenderer renderer;
    Vector3[] pos={new Vector3(0,5),new Vector3(-5,0),new Vector3(5,0),new Vector3(0,-5)};
    public override void Create(){
        objects=new GameObject[5];
        for (int i = 0; i < 4; i++)
        {
            objects[i]=new GameObject("arrow");
            objects[i].AddComponent<SpriteRenderer>().sprite=sprites[i];
            objects[i].transform.position=pos[i];
            objects[i].SetActive(false);
        }
        objects[4]=new GameObject("building");
        renderer=objects[4].AddComponent<SpriteRenderer>();
        renderer.sprite=sprites[5];
        prevkey=key=Random.Range(0,4);
    }
    public override void Update()
    {
        objects[key].SetActive(true);
        if(KeyDown()){
            damage--;
            renderer.sprite=sprites[4+((10-damage)/5)];
            if(damage==0)End(State.won);
            else{
                objects[key].SetActive(false);
                int i=key;
                do key=Random.Range(0,4);
                while(key==prevkey);
                prevkey=i;
            }
        }
        Timer();
    }
    bool KeyDown(){
        switch (key)
        {
            case 0:
                return Input.GetKeyDown(KeyCode.UpArrow);
            case 1:
                return Input.GetKeyDown(KeyCode.LeftArrow);
            case 2:
                return Input.GetKeyDown(KeyCode.RightArrow);
            case 3:
                return Input.GetKeyDown(KeyCode.DownArrow);
            default:
                return false;
        }
    }
}

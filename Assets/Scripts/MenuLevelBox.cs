using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuLevelBox : MonoBehaviour
{
    public float sizeChange = 50f; //[0, 100%]
    public bool scaled = false;
    public int levelNum;
    // Update is called once per frame

    public void Update(){
        if(EventSystem.current.IsPointerOverGameObject() && !scaled){
            this.GetComponent<RectTransform>().localScale /= sizeChange/100;
            scaled = true;
            if(Input.GetButtonDown("Fire1")){
                GameObject.FindGameObjectWithTag("Player").GetComponent<LevelController>().LoadSpecificScene(levelNum);
            }
        }
        else if(!EventSystem.current.IsPointerOverGameObject() && scaled){
            this.GetComponent<RectTransform>().localScale *= sizeChange/100;
            scaled = false;
        }
    }
}

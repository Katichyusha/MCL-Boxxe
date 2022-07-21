using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuLevelBox : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector2 defaultSize;
    private RectTransform rt;
    public float sizeChange = 50f; //[0, 100%]
    public bool over = false;
    public int levelNum;
    // Update is called once per frame

    public void Start(){
        rt = this.GetComponent<RectTransform>();
        defaultSize = new Vector2(1, 1);
    }

    public void Update(){
        if(over){
            this.OnPointerOver();
            LevelChange();
        }
        else{
            this.rt.localScale = defaultSize;
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData){
        if(eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.name == this.gameObject.name){
            this.over = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        this.over = false;
    }

    public void OnPointerOver(){
        this.rt.localScale = defaultSize / (sizeChange/100);
    }


    public void LevelChange(){
        if(Input.GetButtonDown("Fire1") & over){
                GameObject.FindGameObjectWithTag("Player").GetComponent<LevelController>().LoadSpecificScene(levelNum);
            }
    }
}

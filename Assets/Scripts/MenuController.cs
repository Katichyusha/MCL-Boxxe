using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour, IPointerEnterHandler
{
    public LevelMovement playerControls;
    public Canvas menu;
    public GameObject continueText;
    public bool textSelected;
    public int levelToContinueTo;


    private void Start(){
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelMovement>();
        playerControls.enabled = false;
        playerControls.rb.isKinematic = true;
        menu = GameObject.FindObjectOfType<Canvas>();

        if(PlayerPrefs.GetInt("level", 10) == 10){
            PlayerPrefs.SetInt("level", 0);
        }
        else{
            levelToContinueTo = PlayerPrefs.GetInt("level", 10);
;        }
    }
    
    public void Update(){
        if(textSelected && Input.GetButtonDown("Fire1")){
            LevelContinue();
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        if(eventData.pointerCurrentRaycast.gameObject.name == continueText.name){
            textSelected = true;
        }
        else textSelected = false;
    }

    public void LevelContinue(){
        GameObject.FindGameObjectWithTag("Player").GetComponent<LevelController>().LoadSpecificScene(levelToContinueTo);
    }

}

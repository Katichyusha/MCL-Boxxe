using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public LevelMovement playerControls;
    public Canvas menu;


    private void Start(){
        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<LevelMovement>();
        playerControls.enabled = false;
        menu = GameObject.FindObjectOfType<Canvas>();
    }

    private void Update(){
        if(Input.GetButtonDown("Fire1")){
            menu.GetComponentInChildren<Transform>().gameObject.SetActive(false);
            playerControls.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            this.enabled = false;
        }
        //if(Camera.main.ScreenPointToRay(Input.mousePosition)){
    }
}

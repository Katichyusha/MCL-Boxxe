using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBehaviour : MonoBehaviour
{
    public void FINISH(){
        this.GetComponent<Collider2D>().enabled = false;
    }
}

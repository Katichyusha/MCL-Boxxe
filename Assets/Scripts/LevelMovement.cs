using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float pushForce = 10f;
    public float maxForce = 50f;

    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        Time.timeScale = 1.0f;
    }

    private void Start(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector2 forceDir = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Vector2 forceLimited = forceDir*pushForce;
        forceLimited.x = Mathf.Clamp(forceLimited.x, -maxForce, maxForce);
        forceLimited.y = Mathf.Clamp(forceLimited.y, -maxForce, maxForce);
        rb.AddForce(forceLimited, ForceMode2D.Force);

        if(Input.GetButtonDown("Exit")){
            Application.Quit();
        }
    }

    public IEnumerator WaitUntilNextScene()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        this.GetComponent<LevelController>().NextScene();
    }
    public IEnumerator ReloadCurrentScene()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        this.GetComponent<LevelController>().ReloadScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("END"))
        {
            Debug.Log("Congrats");
            Time.timeScale = 0.5f;
            collision.gameObject.SendMessage("FINISH", SendMessageOptions.DontRequireReceiver);
            PlayerPrefs.SetInt("level", this.GetComponent<LevelController>().GetActiveScene().buildIndex);
            StartCoroutine(WaitUntilNextScene());
        }
        else if (collision.CompareTag("HAZARD"))
        {
            gameObject.GetComponent<LevelMovement>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponentInChildren<ParticleSystem>().Play();
            Time.timeScale = 0.1f;
            Debug.Log("Fell into hazard");
            StartCoroutine(ReloadCurrentScene());
        }
    }

}

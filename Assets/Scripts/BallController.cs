using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;
    public float smooth;
    public Text Text;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 targetvelocity = new Vector2(x * speed, rb2d.velocity.y);
        rb2d.velocity = Vector2.SmoothDamp(rb2d.velocity, targetvelocity, ref targetvelocity, Time.deltaTime * smooth);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name=="Obstacle") 
        {
            Text.gameObject.SetActive(true);
            Time.timeScale = 0;
        }  
    }
}

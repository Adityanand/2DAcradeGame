using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int i = 0;
    Animator Anim;
    public bool Grounded;
    public bool Dead;
    public float Walkspeed;
    public float RunSpeed;
    public float JumpForce;
    public float Offset;
    public GameObject LevelFailed;
    public GameObject LevelComplete;
    // Start is called before the first frame update
    void Start()
    {
        Walkspeed = 2;
        RunSpeed =5;
        Anim = GetComponent<Animator>();
        JumpForce = 100f;
        Offset = 50;
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        if(Horizontal>0)
        {
            if (this.transform.rotation.y < 0)
                transform.Rotate(Vector3.up*180);
            Anim.SetFloat("Walking", Horizontal);
            transform.Translate(Vector3.right * Walkspeed * Time.deltaTime);
        }
        if(Horizontal<0)
        {
            if (this.transform.rotation.y >= 0)
                transform.Rotate(Vector3.up*180);
            Anim.SetFloat("Walking", -Horizontal);
            transform.Translate(Vector3.right * Walkspeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Walkspeed = RunSpeed;
            Anim.SetBool("Running", true);
        }
        else
        {
            Walkspeed = 1;
            Anim.SetBool("Running", false);
        }
        if (Input.GetButtonDown("Jump")&& i<3)
        {
            Grounded = false;
            i++;
            if (!Anim.GetBool("Running")&& Horizontal!=0)
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (JumpForce+Offset/2));
                if (this.transform.rotation.y > 0)
                   this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * (RunSpeed+Offset/2f));
                else
                    this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * (RunSpeed+Offset/2f));
            }
            else if(Anim.GetBool("Running") && Horizontal!=0 )
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * (JumpForce+Offset));
                if (this.transform.rotation.y > 0)
                    this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * (RunSpeed+Offset));
                else
                    this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.left * (RunSpeed+Offset));
            }
            else
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * JumpForce);
            Anim.SetTrigger("Jump");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Water")
        {
            Dead = true;
            LevelFailed.SetActive(true);

        }
        if(collision.tag=="House")
        {
            Debug.Log("Hello");
            this.gameObject.SetActive(false);
            LevelComplete.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            Grounded = true;
            i = 0;
        }
        else
            Grounded = false;
    }
}

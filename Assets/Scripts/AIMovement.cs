using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;
    Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        Anim =GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetFloat("Walking", 1.0f);
        transform.Translate(Vector3.right * speed*Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlow : MonoBehaviour
{
    Transform Player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(5, .75f, -10);
        Player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!Player.GetComponent<PlayerController>().Dead)
        this.transform.position = Player.transform.position+offset;

    }
}

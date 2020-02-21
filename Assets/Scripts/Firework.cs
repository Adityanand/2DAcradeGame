using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    float posx;
    float posy;
    Vector3 offeset;
    Vector3 position;
    GameObject FireworkPosition;
    // Start is called before the first frame update
    void Start()
    {
        FireworkPosition = GameObject.FindGameObjectWithTag("MainCamera");
        StartCoroutine(FireworkPos());
    }

    IEnumerator FireworkPos()
    {
        posx = Random.Range(-5, 8);
        posy = Random.Range(-4, 8);
        offeset = new Vector3(posx, posy, 5);
        position = FireworkPosition.transform.position + offeset;
        this.transform.position = position;
        GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1);
        StartCoroutine(FireworkPos());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public float rotationSpeed;
    CoinManager CoinManager;
    ObjectPool Pool;

    // Start is called before the first frame update
    void Start()
    {
        Pool = ObjectPool.instance;
        rotationSpeed = 5;
        CoinManager = GameObject.FindGameObjectWithTag("CoinManager").GetComponent<CoinManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            CoinManager.CoinCollect();
          this.gameObject.SetActive(false);
          Pool.poolDictionary["Coin"].Enqueue(this.gameObject);
        }
        if(collision.tag=="Ground")
        {
            this.gameObject.SetActive(false);
            Pool.poolDictionary["Coin"].Enqueue(this.gameObject);
        }
    }
}

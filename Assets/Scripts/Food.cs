using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Food : MonoBehaviour
{
    

    private void Start()
    {
        Vector2 pos = new Vector2(Random.Range(-16, 17), Random.Range(-8, 9));
        transform.position = pos;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Yes");
            FoodReset.FD.isEat = true;
            Destroy(this.gameObject);
        }
    }
}

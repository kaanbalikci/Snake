using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
   
    private Vector2 rotate = Vector2.right;
    public float speed = 1f;
    void Start()
    {
        
        StartCoroutine(Move());
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.W) && rotate != Vector2.down)
        {
            rotate = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.S) && rotate != Vector2.up)
        {
            rotate = Vector2.down;
        }
        if (Input.GetKeyDown(KeyCode.A) && rotate != Vector2.right)
        {
            rotate = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.D) && rotate != Vector2.left)
        {
            rotate = Vector2.right;
        }
    }

    /*private void FixedUpdate()
    {
        
        this.transform.position = new Vector3(
            this.transform.position.x + rotate.x,
            this.transform.position.y + rotate.y,
            0.0f
            );
    }*/

    private IEnumerator Move()
    {
        while (true)
        {
            var position = transform.position;
            position += (Vector3)rotate;
            position.x = Mathf.RoundToInt(position.x);
            position.y = Mathf.RoundToInt(position.y);
            transform.position = position;

            yield return new WaitForSeconds(speed);
        }
        

    }
}

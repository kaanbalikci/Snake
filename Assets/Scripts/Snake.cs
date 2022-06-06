using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public List<Transform> Tails = new List<Transform>();

    public static Snake SNK;

    [SerializeField] private GameObject tail;
    [SerializeField] private GameObject gameOverUI;

    private Vector2 rotate = Vector2.right;
    public float speed = 0.05f;


    private void Awake()
    {
        SNK = this;
    }

    void Start()
    {
        Tails.Add(this.transform);
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
            for (int i = Tails.Count - 1; i > 0; i--)
            {
                Tails[i].position = Tails[i - 1].position;
                
            }
            
            var position = transform.position;
            position += (Vector3)rotate;
            position.x = Mathf.RoundToInt(position.x);
            position.y = Mathf.RoundToInt(position.y);
            transform.position = position;

            yield return new WaitForSeconds(speed);
        }
        

    }

    public void Grow()
    {
        var tailX = Instantiate(tail);
        
        Tails.Add(tailX.transform);
        if(Tails.Count > 2)
        {
            Tails[Tails.Count - 1].position = Tails[Tails.Count - 2].position;
        }
        

        Debug.Log("add");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Dead")
        {
            Debug.Log("HH");
            gameOverUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }


    public void GameOverButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverUI.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Application.Quit();

    }
}

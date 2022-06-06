using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodReset : MonoBehaviour
{
    

    public static FoodReset FD;

    public bool isEat;

    public int score = 0;

    [SerializeField] private Text scoreText;

    [SerializeField] private GameObject food;
   

    private void Awake()
    {
        FD = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(isEat == true)
        {

            score += 1;
            scoreText.text = "Score : " + score;
            Snake.SNK.Grow();
            var X = Instantiate(food, transform.position,Quaternion.identity);
            
            for (int i = Snake.SNK.Tails.Count - 1; i > 0; i--)
            {
                if(X.transform.position == Snake.SNK.Tails[i].position)
                {
                    X.transform.position = new Vector2(Random.Range(-16, 17), Random.Range(-8, 9));

                }          
                
            }
            isEat = false;
        }


    }


   



}

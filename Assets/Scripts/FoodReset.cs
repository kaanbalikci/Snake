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
            Instantiate(food, transform.position,Quaternion.identity);
            isEat = false;
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class clearLines : MonoBehaviour
{
    //?public static scoreManager instance;
    public TextMeshProUGUI scoreText;
    public GameObject scoreObj;
    public GameObject gameMgr;
    public GameObject[] observers = {null, null, null, null, null, null, null};
    public int clearAmount;

    public TextMeshProUGUI highScoreText;
    public GameObject highScoreObj;

    int score = 0;
    int highScore;
        
    private void Awake() {
        //?instance = this;
        score = 0;
        clearAmount = 0;
    }
    private void Start() {
        scoreText.text = "Score: "+score.ToString();
        highScoreObj.SetActive(false);
    }
    public void GameOver()
    {
        scoreObj.SetActive(false);
        highScoreObj.SetActive(true);
        highScoreText.text = "You got: "+score.ToString();

    }
    public void UpdateScore()
    {
        score+=100;
        scoreText.text = "Score: "+score.ToString();

    }
    private void Update() 
    {
        //cap = GameObject.Find("cap");
        /*
        //Debug.Log("Clear" +clearAmount);
        
            if(observers[i].GetComponent<SOMETHINGSHERE>().occupied){
                clearAmount +=1;
            }
            else
                clearAmount -=1;
        */
        for (int i = 0; i < 7; i++)
        {
            if(clearAmount >= 7)
            {
                clearAmount = 0;
                observers[i].GetComponent<SOMETHINGSHERE>().ClearLine();
            }
            if(Input.GetKeyDown(KeyCode.Return))
            {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
/*
    //recognising line stuff
    private Transform _transform;
    public int objectsInLine;
    public Transform[] stuffThatShouldBeDeleted;

    //scoring
    public GameObject tmp;
    public int score;

    void Start()
    {
        //TextMeshPro tmp = gameObject.GetComponent<TextMeshPro>();
        _transform = GetComponent<Transform>();
    }
    void ClearLine(int numberOfLines){
        for (int i = 0; i < length; i++)
        {   
            
            Destroy(stuffThatShouldBeDeleted[i].gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(_transform.position, direction, out RaycastHit hit, _detectionRadius, _blockMask))
        {
            for (int i = 0; i < length; i++)
            {
            stuffThatShouldBeDeleted[i] = hit.collider.GetComponent<Transform>();
            }
            if(hit.collider.GetComponent<Collider2D>().CompareTag("Pushable") && hit >= 7height of play area)
         //   {
        //        ClearLine(1);
         //       score += 100;
         //   }
                //delete prefab of all objects within the line
                //add 100 to score    
                
            //is there something here?
            //how many?
            
            
       // }
   // }*/
}

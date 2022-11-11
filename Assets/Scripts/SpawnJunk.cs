using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnJunk : MonoBehaviour
{
    public GameObject calc;
    public GameObject cap;
    private int chosenJunk;
    public GameObject gameMgr;
    public int junk;
    public int junkLimit = 15;
    private GameObject[] prefab = {null, null};

    public float timeRemaining = 10;
    public float resetTime = 6;
    //funny
    public Vector3 spwanPos;
    
    //
    void Start()
    {
        //prefab[0] = calc;
        //prefab[1] = cap;
        spwanPos = new Vector3(Random.Range(-6, -5), Random.Range(-2, 2),0);
        spwanPos.y -=0.5f;
        Spawn(spwanPos);
    }
    public int Spawn(Vector3 junkPos){
        //spawn in a random spot on the left side of the screen,
        //choose which type of junk to spawn
        prefab[0] = calc;
        prefab[1] = cap;
        
        if(Random.value < 0.5)
        {
            chosenJunk = 0;
        }
        else
            chosenJunk = 1;
        //Debug.Log("chosen" + chosenJunk);
        Instantiate(prefab[chosenJunk], junkPos, Quaternion.identity);
        prefab[chosenJunk].SetActive(true);
        junk+=1;
        return junk;
    }

    void Update()
    {
        spwanPos = new Vector3(Mathf.Round(Random.Range(-6, -5)), Mathf.Round(Random.Range(-2, 2)),0);
        
        if (chosenJunk == 0)
        {
            //gameMgr.GetComponent<pushableBlockScript>().ItsCalc();
            spwanPos.y -=0.5f;
            
            
        }
        else
        {
            //gameMgr.GetComponent<pushableBlockScript>().ItsCap();
            spwanPos.y -= 0f;
        }
        if (timeRemaining > 0)
        {

            timeRemaining -= Time.deltaTime;

        }
        else
        {
            Spawn(spwanPos);
            timeRemaining = resetTime - 0.01f;
        }
        if(junk >= junkLimit)
        {
            gameMgr.GetComponent<clearLines>().GameOver();
        }
        
        if(gameMgr.GetComponent<clearLines>().clearAmount >=7 && prefab[chosenJunk].GetComponent<Transform>().position.x == 6)
        {

            Destroy(prefab[chosenJunk]);
            junk -=1;
        }

    }
    
}

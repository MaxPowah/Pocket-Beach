using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOMETHINGSHERE : MonoBehaviour
{
    public GameObject gameMgr;
    private GameObject thereIsAnother;
    public bool occupied;
    // Start is called before the first frame update
    void Start()
    {
        occupied = false;
    }
    private void OnTriggerEnter(Collider other) {
        thereIsAnother = other.GetComponent<GameObject>();
        if(other.GetComponent<Collider>().CompareTag("Pushable"))
        {
            occupied = true;
        }
        else
            occupied = false;
        
    }
    public void ClearLine()
    {
        Debug.Log("so happy to be here");
        
        gameMgr.GetComponent<clearLines>().UpdateScore();
    }
    private void Update()
    {
        if(occupied)
            Debug.Log("true");
    }

}

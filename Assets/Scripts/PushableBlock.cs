using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlock : MonoBehaviour
{
    [SerializeField] private LayerMask _blockMask = 0;
    //[SerializeField] private float _speed = 3f;
    [SerializeField] private float _detectionRadius = 1.2f;
    public Vector3 _destination;
    //public float _speedMulitiplier = 1.5f;
    private bool _isBeingPushed = false;
    public Transform _transform;
    private RaycastHit hit;
    public Vector2 origin;
    public Vector3 nothing;
    public Transform player;
    public GameObject gameMgr;
    private bool madeIt;

    public float maxXpos = 7f;
    public float minXpos = -8f;
    public float maxYpos = 3.1f;
    public float minYpos = -2.51f;

    private void Start()
    {
        madeIt = false;

    }
    private void IncClearAmount(){
            int clearAmount=gameMgr.GetComponent<clearLines>().clearAmount +=2;
            Debug.Log("clearamount"+ clearAmount);
            if(clearAmount >= 7)
            {
                Debug.Log("DED - calc");
                Destroy(GetComponent<GameObject>());

            }

            madeIt = true;

    }

    public void Push(Vector3 direction)
    {
        //Debug.Log("ispush " + _isBeingPushed);
        if(!_isBeingPushed){
            //Debug.Log("not breing pushed");
            if(  CheckDirection(direction)){
                //Debug.Log("Push has been activated");
                _isBeingPushed = true;
                MOOOVE(nothing);
                /*
                _transform.position += direction;
                _speed = playerSpeed * _speedMulitiplier;
                */
                //Debug.Log("pshed the pshable");

            }
            else
            {
            MOOOVE(direction);
            //Debug.Log("direction failed");    
            }
        }
    }
    private void MOOOVE(Vector3 direction)
    {
        Vector3 tmp = _transform.position;
        tmp.x = Mathf.Round(tmp.x);
        _transform.position = tmp;
        _transform.position += direction;
        _isBeingPushed = false;
    }
    private bool CheckDirection(Vector3 direction){
        //Debug.DrawRay(_transform.position, direction,UnityEngine.Color.red, false);

        RaycastHit2D hit = Physics2D.Raycast(origin, direction,_detectionRadius, _blockMask);
        if(hit)
        {
            //Debug.Log("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOH");
            if(hit.collider.CompareTag("Wall")){
                return true;
            }
            return false;
        }
        else 
        //Debug.Log("I should really think about pushing right about now");
            return true;
    }
    private void Update() {
        origin.x = _transform.position.x;
        origin.y = _transform.position.y;
        if(_transform.position.x >= maxXpos){player.position-= new Vector3(1, 0,0);
            _transform.position -= new Vector3(1, 0,0);}
        if(_transform.position.x <= minYpos){player.position+= new Vector3(1, 0,0);
            _transform.position +=new Vector3(1, 0,0);}

        if(_transform.position.y > maxYpos){player.position -=new Vector3(0, 1,0);
            _transform.position -=new Vector3(0, 1,0);}
        if(_transform.position.y < minYpos){player.position +=new Vector3(0, 1,0);
            _transform.position +=new Vector3(0, 1,0);}
        if(_transform.position.x == 6 && madeIt == false)
        {
            IncClearAmount();
            //this.GetComponent<PushableBlock>().enabled = false;
        }       
        if(gameMgr.GetComponent<clearLines>().clearAmount >= 7)
        {
            Debug.Log("DED - cap");
            Destroy(GetComponent<GameObject>());
        }
 
        

        //Debug.Log("isbeingpushed: " + _isBeingPushed);
        //Debug.Log("dist"+Vector3.Distance(_transform.position, _destination));
        /*
        if(Vector3.Distance(_transform.position, _destination) == 0){
            Debug.Log("still");
            _destination = _transform.position;
            _isBeingPushed = false;
        }
        else
            Debug.Log("movin");
        
        //!är den här raden fel?--------------------------------------------------------------------------------------------------
        _transform.position = Vector3.MoveTowards(_transform.position, _destination, _speed * Time.deltaTime);
        */
        
    }
}

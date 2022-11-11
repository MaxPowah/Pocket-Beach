using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    //gridMovement
    [SerializeField] private LayerMask _blockMask;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _detectionRadius = 1f;
    private Vector3 _destination;
    public float _speedMulitiplier = 1f;
    private float distance;
    public Transform _transform;
    public GameObject player;
    public Vector2 origin;
    public GameObject gameMgr;



    void Start()
    {
        _transform = player.GetComponent<Transform>();

    }
    private bool CheckDirection(Vector3 direction){
        //check if something in the way
        //if so, stop player from moving there (return false)
            RaycastHit2D hit = Physics2D.Raycast(origin, direction, _detectionRadius, _blockMask);
            if(hit.collider != null)
            {
                //is it pushable?
                if(hit.collider.CompareTag("Pushable")){
                    //push if possible
                    PushableBlock _pushableBlock = hit.collider.GetComponent<PushableBlock>();
                    if(!_pushableBlock && gameMgr.GetComponent<clearLines>().clearAmount < 7)
                    {
                        //Debug.Log("huh?");
                        CapPushable _pushableCap = hit.collider.GetComponent<CapPushable>();
                        _pushableCap.Push(direction);
                        return false;
                    }
                    _pushableBlock.Push(direction);
                    //Debug.Log("pssssch");


                }
                else if(hit.collider.CompareTag("Wall")){
                    
                Debug.Log("A WALL");
                return false;
                }
                return false;

            }
            else
                return true;
        }
    void LiftBlock(Vector3 junkPos){
        //lift block over crabs
        //if junkpos.x < pos.x, squares to the right of you are clear, raycasthit from player to the junk, move junk to the right 
    }
    
    private void Update() {
        
        origin.x = _transform.position.x;
        origin.y = _transform.position.y;
        //Debug.Log("origin: " + origin);
        if(Vector3.Distance(_transform.position, _destination) < Mathf.Epsilon){
            #region Check Directions
            if (Input.GetAxis("Horizontal") < 0)
            {
                //check if direction is safe to go
                if(CheckDirection(Vector3.left))
                {
                _destination = _transform.position + Vector3.left;
                }  
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                if(CheckDirection(Vector3.right))
                {
                _destination = _transform.position + Vector3.right;
                }
            }
            //vertcal
            
            if (Input.GetAxis("Vertical") < 0)
            {
                //check if direction is safe to go
                if(CheckDirection(Vector3.down))
                {
                _destination = _transform.position + Vector3.down;
                }  
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                if(CheckDirection(Vector3.up))
                {
                _destination = _transform.position + Vector3.up;
                }
            }
            #endregion
        }
        else
        {
            _transform.position = Vector3.MoveTowards(_transform.position,_destination, _speed * Time.deltaTime);
        }
    }


}
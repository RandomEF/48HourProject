using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Pick : MonoBehaviour
{
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Vector3 pick;
    public LayerMask pickable;
    public Transform obj, camera, player;
    [SerializeField] private float maxDist = 10f;
    [SerializeField] private SpringJoint joint;

    void Awake(){
        lr = GetComponent<LineRenderer>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            StartPick();
        }else if(Input.GetMouseButtonUp(0)){
            StopPick();
        }
    }

    void StartPick(){
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDist, pickable)){
            pick = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = pick;

            float distanceFromPont = Vector3.Distance(player.position, pick);
            joint.maxDistance = distanceFromPont * 0.8f;
            joint.minDistance = distanceFromPont * 0.25f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
        }
    }

    void StopPick(){
    }

    /*
    [SerializeField] private Transform Dest;
    private bool mouseDown;
    [SerializeField] private int wait = 5;
    [SerializeField] private float maxSpeed = 10;
    [SerializeField] private Vector3 direction;
    [SerializeField] private Vector3 position;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 velocity;

    void Start(){
        rb = GetComponent<Rigidbody>();
    }

    void Update(){
        //rb.velocity.magnitude = velocity;
        velocity = rb.velocity;

        if (mouseDown == true){
            position = Dest.transform.position;
            direction = (Dest.transform.position - this.transform.position).normalized;
            
            Debug.DrawLine(this.position, Dest.transform.position, Color.blue, 0);
            velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            rb.AddForce(direction/10, ForceMode.VelocityChange);
            //this.transform.position = Dest.position;
            //transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
    }

        

    void OnMouseDown(){
        mouseDown = true;
        //GetComponent<Rigidbody>().useGravity = false;
        //this.transform.position = Dest.position;
        //this.transform.parent = GameObject.Find("Pick").transform;
    }

    void OnMouseUp(){
        mouseDown = false;
        this.transform.parent = null;
        StartCoroutine(waiter());
        //GetComponent<Rigidbody>().useGravity = true;
    }

    IEnumerator waiter(){
        yield return new WaitForSeconds(wait);
    }
    */
}

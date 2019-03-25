using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] //Show in UI even though its private
    private float speed;//Speed the ball should move in
    public GameObject particle;
    bool hasGameStarted; //Has the game started? If so start moving the ball
    public bool ballHasFallenOff; //Has the player fallen off the platform? If so set this to true
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //Default Values
        hasGameStarted = false;
        ballHasFallenOff = false;
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }

    // Update is called once per frame
    void Update()
    {
        //Only runs on initial load, starts moving the ball
        if (hasGameStarted == false){
            if (Input.GetMouseButtonDown(0)) {
                rb.velocity = new Vector3(speed, 0, 0);
                hasGameStarted = true;

                GameManager.singleton.StartGame();
            }
            
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);
        //Raycast between ball and platform, if it it returns false then player has fallen off
        if (!Physics.Raycast(transform.position, Vector3.down, 1f)){
            ballHasFallenOff = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.velocity = new Vector3(0,-50f,0);

            GameManager.singleton.EndGame();
        }

        //Player Controller Method
        playerControl();
    }

    //This method holds all the player controls
    void playerControl()
    {
        if (Input.GetMouseButtonDown(0) && (ballHasFallenOff != true)) {
            SwitchDirection();
        }
    }

    //Change the direction the ball is travelling in
    void SwitchDirection()
    {
        if (rb.velocity.z != 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if (rb.velocity.x != 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    //Destroy points object if player collects poiont
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Points") {
            Quaternion point = gameObject.transform.rotation;
            Vector3 pointUp = new Vector3(-90f, 0f, 0f);
            GameObject temp = Instantiate(particle, collider.gameObject.transform.position, point) as GameObject; 
            Destroy(collider.gameObject);
            Destroy(temp, 1f);
        }
    }
}

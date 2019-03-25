using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour{

    public GameObject player; //player object reference
    Vector3 cameraOffset; //Holds distance between the ball and the player
    public float smoothCameraRate;
    bool ballHasFallenOff;

    // Start is called before the first frame update
    void Start(){
        cameraOffset = player.transform.position - transform.position; //Calculating the distance between the ball and player initially to keep it same when following
        ballHasFallenOff = player.gameObject.GetComponent<Controller>().ballHasFallenOff;
    }

    // Update is called once per frame
    void Update(){
        if (player.gameObject.GetComponent<Controller>().ballHasFallenOff != true) {
            Follow();
        }
    }

    void Follow(){
        Vector3 cameraPosition = transform.position; //The position of the camera
        Vector3 targetPosition = player.transform.position - cameraOffset; //The position we want the camera to always be which is ball+offset i.e. always 5units above ball etc
        cameraPosition = Vector3.Lerp(cameraPosition, targetPosition, smoothCameraRate * Time.deltaTime);
        transform.position = cameraPosition;
    }
}

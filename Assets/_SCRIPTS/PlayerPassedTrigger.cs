using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPassedTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            Invoke("Fall", 2f);
        }
    }

    void Fall() {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;

        Destroy(transform.parent.gameObject, 2f);

    }
}

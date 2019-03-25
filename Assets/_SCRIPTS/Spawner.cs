using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject platformPrefab; //platform to spawn
    public GameObject pointsPrefab; //point object to spawn
    public GameObject player; //holds player reference

    Vector3 lastPos; //Holds previously spawned platforms position
    public float size; //This holds how much to move by
    public float time; //This holds how quick to spawn platforms

    // Start is called before the first frame update
    void Start()
    {
        lastPos = platformPrefab.transform.position;//The poistion of the prefabs position
        for (int i = 0; i < 10; i++) {
            SpawnPlatforms();
        }

        
    }

    public void StartSpawningPlatforms() {
        InvokeRepeating("SpawnPlatforms", 1f, time);
    }
    // Update is called once per frame
    void Update()
    {
        if (player.gameObject.GetComponent<Controller>().ballHasFallenOff == true) {
            CancelInvoke("SpawnPlatforms");
        }
    }

    //Randomly spawn platforms
    void SpawnPlatforms() {
        if(player.gameObject.GetComponent<Controller>().ballHasFallenOff == true){ return; } //do nothing if game is over

        int rand = Random.Range(1, 6);
        if (rand < 4) { SpawnX(); }
        else { SpawnZ(); }
    }
    //Spawn in the X direction
    void SpawnX() {

        Vector3 pos = lastPos; //get previous spawned coords
        pos.x += size; //make new spawn coord +size in the x direction
        lastPos = pos; //save these new coords 

        //Spawn next platform
        Instantiate(platformPrefab, pos, Quaternion.identity); //Quaternion.identity means use the rotation it already has

        int random = Random.Range(0, 6);
        if (random < 4){
            Instantiate(pointsPrefab, new Vector3(pos.x,pos.y + 1f, pos.z), pointsPrefab.transform.rotation);
        }

    }

    void SpawnZ() {
        Vector3 pos = lastPos; //get previous spawned coords
        pos.z += size; //make new spawn coord +size in the x direction
        lastPos = pos; //save these new coords 

        //Spawn next platform
        Instantiate(platformPrefab, pos, Quaternion.identity); //Quaternion.identity means use the rotation it already has

        int random = Random.Range(0, 6);
        if (random < 4){
            Instantiate(pointsPrefab, new Vector3(pos.x, pos.y + 1f, pos.z), pointsPrefab.transform.rotation);
        }
    }
}

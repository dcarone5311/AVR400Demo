using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public GameObject[] gemPrefabs;

    public GameObject particles;



    // Start is called before the first frame update
    void Start()
    {
        int num =  Random.Range(0, gemPrefabs.Length);
        GameObject stone = Instantiate(gemPrefabs[num]); //randomly select
        stone.transform.parent = transform;
        stone.name = "Stone1";
        GetComponent<Animator>().Rebind();
        GetComponent<Renderer>().enabled = false;

        particles.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Collected();
    }


    void Collected()
    {

        particles.SetActive(true);
        GetComponent<Animator>().SetTrigger("Collected");

        GetComponent<Collider>().enabled = false; //turn off collider
        GetComponent<AudioSource>().Play(); //play sound
        Destroy(gameObject, 1.2f); //allow time to play before destroying


    }

}

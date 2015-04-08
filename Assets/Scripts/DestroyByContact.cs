using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other) 
    {
        
        if (other.tag == "Boundary")
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation); // asteroid explodes

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation); // player explodes
            //gameController.GameOver();
        
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}

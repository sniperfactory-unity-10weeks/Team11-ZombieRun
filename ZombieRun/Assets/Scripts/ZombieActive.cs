using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieActive : MonoBehaviour
{
    public GameObject Zombie;
    ZombieMove zm;
    NavMeshAgent nma;

    // Start is called before the first frame update
    void Start()
    {
        Zombie.SetActive(false);
/*        zm = Zombie.GetComponent<ZombieMove>();
        zm.enabled = false;
        nma = Zombie.GetComponent<NavMeshAgent>();
        nma.enabled = false;*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Zombie.SetActive(true);
/*            nma.enabled = true;
            zm.enabled = true;*/
        }
    }
}

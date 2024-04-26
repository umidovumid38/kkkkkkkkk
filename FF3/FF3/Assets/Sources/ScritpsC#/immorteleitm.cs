using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class immorteleitm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMove>().StartisImmortal();
            Destroy(gameObject);
        }
    }

}

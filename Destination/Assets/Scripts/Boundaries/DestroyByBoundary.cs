using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

   /* private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("hey");
        Debug.Log(other.tag);
        if (other.tag != "OOB")
        {
            Destroy(other.gameObject);
            //TODO fix this for pooling other.gameObject.SetActive(false);
        }
    }*/

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag != "OOB")
        {
            other.gameObject.SetActive(false);
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        // Debug.Log("hey");
        //Debug.Log(other.tag);
        if (other.tag != "OOB")
        {
            Destroy(other.gameObject);

        }
        
    }
}

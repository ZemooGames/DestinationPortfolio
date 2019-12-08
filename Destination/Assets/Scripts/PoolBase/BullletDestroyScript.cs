using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullletDestroyScript : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
        Invoke("Destroy", 2f);
	}
	
	// Update is called once per frame
	void Destroy () {
        gameObject.SetActive(false);
	}

    private void OnDisable()
    {
        CancelInvoke();
    }
}

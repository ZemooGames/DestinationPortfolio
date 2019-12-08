using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : PoolObject {

	
	// Update is called once per frame
	void Update () {
        transform.localScale += Vector3.one * Time.deltaTime * 3;
        transform.Translate(Vector3.up * Time.deltaTime * 25);
	}

    public override void OnObjectReuse()
    {
        transform.localScale = Vector3.one;
    }
}

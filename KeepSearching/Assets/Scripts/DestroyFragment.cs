﻿using UnityEngine;

public class DestroyFragment : MonoBehaviour {

    public float minY = -2.5f;

	// Update is called once per frame
	void Update () {
        if (transform.position.y < minY)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreSize : MonoBehaviour
{
    public float minSize = 0.1f;
    public float ds = 1f;
    public float maxSize = 0.97f;

    private BallMover parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = gameObject.GetComponentInParent<BallMover>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float scale = parent.numCoins() < 1024 ? Mathf.Sqrt(parent.numCoins()) / 32f : 1;
        if (scale > 0)
        {
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}

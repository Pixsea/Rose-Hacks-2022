using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontRotate : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private float defaultXScale;

    // Start is called before the first frame update
    void Start()
    {
        defaultXScale = gameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.identity;

        if (rb.velocity.x > .01f)
        {
            gameObject.transform.localScale = new Vector3(defaultXScale * 1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }

        if (rb.velocity.x < -.01f)
        {
            gameObject.transform.localScale = new Vector3(defaultXScale * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
    }
}

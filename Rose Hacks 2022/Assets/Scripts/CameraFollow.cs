using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float followSpeed = 9f;
    [SerializeField]
    private float dampTime = .15f;

    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = gameObject.GetComponent<Camera>().WorldToViewportPoint(player.transform.position);
        Vector3 delta = player.transform.position - gameObject.GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}

using UnityEngine;
using System.Collections;

public class cameraTargetController : MonoBehaviour {
    public float speed;
    private Rigidbody2D myRigidbody;
    private Rigidbody2D playerRigidbody;
    private float difference;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerRigidbody = FindObjectOfType<playerController>().GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        difference = playerRigidbody.transform.position.x - transform.position.x;
        if (playerRigidbody.transform.position.x > 66.585f)
        {
            transform.position = new Vector3(-13.335f-difference, transform.position.y, 0f);
        }
        else if (playerRigidbody.transform.position.x < -15.9f)
        {
            transform.position = new Vector3(64.02f- difference, transform.position.y, 0f);
        }
        myRigidbody.velocity = new Vector3(speed, myRigidbody.velocity.y, 0f);

        if(difference > 4f)
        {
            speed = 10f;
        }
        else
        {
            speed = 6f;
        }
	}
}

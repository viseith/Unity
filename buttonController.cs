using UnityEngine;
using System.Collections;

public class buttonController : MonoBehaviour {
    public float bounceForce;
    public Sprite buttonPressedSprite;
    public bool buttonPressed;
    private SpriteRenderer mySpriteRenderer;
    private playerController myPlayer;
    public GameObject otherButton;
    private doorController myDoor;
    private AudioSource buttonSoundFX;
    // Use this for initialization
    void Start () {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myPlayer = FindObjectOfType<playerController>();
        myDoor = FindObjectOfType<doorController>();
        buttonSoundFX = GetComponent<AudioSource>();
        buttonPressed = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && myPlayer.isFalling && !buttonPressed)
        {
            mySpriteRenderer.sprite = buttonPressedSprite;
            myPlayer.GetComponent<Rigidbody2D>().velocity = new Vector3(myPlayer.GetComponent<Rigidbody2D>().velocity.x, bounceForce, 0f);
            otherButton.GetComponent<SpriteRenderer>().sprite = buttonPressedSprite;
            myDoor.UnlockDoor();
            buttonSoundFX.Play();
            buttonPressed = true;
        }
    }
}

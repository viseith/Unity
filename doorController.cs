using UnityEngine;
using System.Collections;

public class doorController : MonoBehaviour {
    public Sprite doorUnlockedSprite;
    public bool doorUnlocked;
    private SpriteRenderer mySpriteRenderer;
	// Use this for initialization
	void Start () {
        doorUnlocked = false;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void UnlockDoor()
    {
        doorUnlocked = true;
        mySpriteRenderer.sprite = doorUnlockedSprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MoveObject {

    public float minDelay = 0.2f;
    public float maxDelay = 1.0f;
    public RemotePlayer remotePlayer;

    // Use this for initialization
    protected override void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 mousePositionOnScreen = Input.mousePosition;
            mousePositionOnScreen.z = screenPosition.z;
            Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
            MoveToPos(mousePositionInWorld);
            float delay = Random.Range(minDelay, maxDelay);
            StartCoroutine(SendMsg(delay,mousePositionInWorld));
        }
     }

    protected IEnumerator SendMsg(float delayTime,Vector3 pos)
    {
        yield return new WaitForSeconds(delayTime);
        remotePlayer.MoveToPos(pos);
    }
}

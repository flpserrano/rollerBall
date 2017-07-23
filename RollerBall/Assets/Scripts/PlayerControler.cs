using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour {

	Rigidbody rb;
	public float velocity;
	int count;
	public Text points;
	public Text win;
	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		UpdateCount();
		win.gameObject.SetActive(false);
	}
	
	void FixedUpdate()
	{
		float horizontalMovement = Input.GetAxis("Horizontal");
		float verticalMovement = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(horizontalMovement,0,verticalMovement);
		rb.AddForce(movement*velocity);
	}

	public void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        count = count + 1;
        UpdateCount();
		if(count >= 12){
			win.gameObject.SetActive(true);
		}
    }

    private void UpdateCount()
    {
        points.text = "Score:" + count;
    }
}

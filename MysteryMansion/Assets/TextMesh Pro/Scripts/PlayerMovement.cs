using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody player;

    public LayerMask rooms;

    RoomData room;

    public void Awake() {
        rooms = 1 << LayerMask.NameToLayer("Rooms");
    }

    void Start () {
        //player = GameObject.Find("Player").GetComponent<Rigidbody>();
        var r = Physics.OverlapSphere(transform.position, 1f, rooms);
        room = r[0].GetComponent<RoomData>();
        room.EnterRoom();
	}
	
	
	void Update () {
		//if (Input.GetKeyDown)

	}
}

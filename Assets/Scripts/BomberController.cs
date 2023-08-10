using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberController : MonoBehaviour {

    [SerializeField] private float vMax = 10;
    [SerializeField] private BombService bombService;

    private Rigidbody rBody;

    private Vector3 vel;

    private void Awake() {
        rBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Input.GetButtonDown("DropBomb")) {
            //Player reposition logic must be added.
            bombService.DropBomb(transform.position);
        }
    }

    private void FixedUpdate() {
        vel.x = Input.GetAxisRaw("Horizontal");
        vel.z = Input.GetAxisRaw("Vertical");
        vel.y = 0;

        if (vel.magnitude >= 1) {
            vel = vel.normalized;
        }
        vel = vel * vMax;

        rBody.velocity = vel;
    }



}

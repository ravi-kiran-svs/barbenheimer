using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberController : MonoBehaviour, IBoomable {

    [SerializeField] private float vMax = 10;
    [SerializeField] private BombService bombService;

    private Rigidbody rBody;

    private Vector3 vel;

    private void Awake() {
        rBody = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Input.GetButtonDown("DropBomb")) {
            bombService.DropBomb(transform.position, GetComponent<Collider>());
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

    public void Boom() {
        Debug.Log("Player is BOOM");
    }
}
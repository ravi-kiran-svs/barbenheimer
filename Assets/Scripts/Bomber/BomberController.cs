using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberController : MonoBehaviour, IBoomable {

    [SerializeField] private float vMax = 10;
    private BombModel bombParams;

    private Rigidbody rBody;

    private Vector3 vel;

    private void Awake() {
        rBody = GetComponent<Rigidbody>();

        bombParams = new BombModel(3, 2, 3);
    }

    private void Update() {
        if (Input.GetButtonDown("DropBomb")) {
            BombService.Instance.DropBomb(transform.position, GetComponent<Collider>(), bombParams);
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

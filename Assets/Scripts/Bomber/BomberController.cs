using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberController : MonoBehaviour, IBoomable {

    [SerializeField] private BomberModel model;

    private Rigidbody rBody;

    private Vector3 vel;
    private int nBombs;

    private void Awake() {
        rBody = GetComponent<Rigidbody>();
        // should be called in Start??? - but works here
        nBombs = model.nBombMax;
    }

    private void Update() {
        if (Input.GetButtonDown("DropBomb")) {
            if (nBombs > 0) {
                bool bombDropSuccess = BombService.Instance.DropBomb(transform.position, GetComponent<Collider>(), model.bombModel, OnBombBoom);
                if (bombDropSuccess) {
                    nBombs--;
                }
            }
        }
        BomberService.Instance.BomberMovedTo(transform.position);
    }

    private void OnBombBoom() {
        nBombs++;
    }

    private void FixedUpdate() {
        vel.x = Input.GetAxisRaw("Horizontal");
        vel.z = Input.GetAxisRaw("Vertical");
        vel.y = 0;

        if (vel.magnitude >= 1) {
            vel = vel.normalized;
        }
        vel = vel * model.vMax;

        rBody.velocity = vel;
    }

    public void Boom() {
        Debug.Log("Player is BOOM");
    }
}

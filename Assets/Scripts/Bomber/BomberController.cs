using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberController : MonoBehaviour, IBoomable {

    [SerializeField] private BomberModel bomberStats;

    private Rigidbody rBody;

    private Vector3 vel;
    private int nBombs;

    private void Awake() {
        rBody = GetComponent<Rigidbody>();

        nBombs = bomberStats.nBombMax;
    }

    private void Update() {
        if (Input.GetButtonDown("DropBomb")) {
            if (nBombs > 0) {
                bool bombDropSuccess = BombService.Instance.DropBomb(transform.position, GetComponent<Collider>(), bomberStats.bombModel, OnBombBoom);
                if (bombDropSuccess) {
                    nBombs--;
                }
            }
        }
        BomberService.Instance.BomberMovedTo(transform.position);
    }

    public void ResetStats(BomberModel stats) {
        bomberStats = stats;

        // physics layer shit also in future
        nBombs = stats.nBombMax;
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
        vel *= bomberStats.vMax;

        rBody.velocity = vel;
    }

    public void Boom() {
        Debug.Log("Player is BOOM");
    }
}

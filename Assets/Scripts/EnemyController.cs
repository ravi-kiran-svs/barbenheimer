using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] float vMax = 3;

    private int layerMask;

    private Vector3 dir = VectorConstants.RIGHT;
    private Vector3 target = Vector3.zero;


    private void Awake() {
        layerMask = LayerMask.GetMask("Env", "Bomb");
    }

    private void Start() {
        SetTarget();
    }

    private void Update() {
        transform.position = transform.position + dir * vMax * Time.deltaTime;

        if (Vector3.Dot((target - transform.position), dir) <= 0) {
            SetTarget();
        }
    }

    private void SetTarget() {
        bool doesIntersect = Physics.Raycast(transform.position, dir, 1, layerMask);

        if (doesIntersect) {
            dir = -dir;
        }
        target = transform.position + dir;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField] float vMax = 3;
    [SerializeField] float chaosCutoff = 50;

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
            transform.position = target;
            SetTarget();
        }
    }

    private void SetTarget() {
        bool doesIntersect = Physics.Raycast(transform.position, dir, 1, layerMask);
        Debug.DrawRay(transform.position, dir, Color.white, 0.1f);

        Vector3 newDir = dir;
        if (doesIntersect) {
            if (Random.Range(0, 100) < chaosCutoff) {
                newDir = Quaternion.Euler(0, 90 + 180 * Random.Range(0, 2), 0) * dir;
                Debug.DrawRay(transform.position, newDir, Color.red, 0.1f);

                if (Physics.Raycast(transform.position, newDir, 1, layerMask)) {
                    newDir = -dir;
                }

            } else {
                newDir = -dir;
            }
        }

        dir = newDir;
        target = transform.position + dir;
    }

}

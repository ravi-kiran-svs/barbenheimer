using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IBoomable {

    [SerializeField] float vMax = 3;
    [SerializeField] float chaosCutoff = 50;

    private int layerMask;

    private Vector3 dir = Vector3.zero;
    private Vector3 target = Vector3.zero;


    private void Awake() {
        layerMask = LayerMask.GetMask("Env", "Bomb", "Expl");
    }

    private void Start() {
        SetNewTarget();
    }

    private void Update() {
        transform.position = transform.position + dir * vMax * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        IBoomable boomable = other.gameObject.GetComponent<IBoomable>();

        if (boomable != null) {
            boomable.Boom();
        }
    }

    public void Boom() {
        Destroy(gameObject);
    }

    private void SetNewTarget() {
        List<Vector3> availableDirs = GetAvailableDirections();
        if (availableDirs.Count == 0) {
            // I am trapped => Hence I don't move.
            dir = Vector3.zero;

        } else {
            // I have at least one way
            if (dir.magnitude == 0) {
                // I wasn't moving previously
                dir = availableDirs[Random.Range(0, availableDirs.Count)];

            } else {
                // I was moving previously
                if (availableDirs.Contains(dir)) {
                    // There is a way forward => Hence, I go forward

                    if (availableDirs.Count > 1 && Random.Range(0, 100) < chaosCutoff / 4) {
                        // if there are other ways and chaos is true

                        availableDirs.Remove(dir);
                        dir = availableDirs[Random.Range(0, availableDirs.Count)];

                    } else {
                        // chaos is false or no other way but back
                        //dir = dir;
                    }
                } else {
                    // There is no way forward
                    if (availableDirs.Contains(-dir)) {
                        // There is a way backward => Hence, I go backward

                        if (availableDirs.Count > 1 && Random.Range(0, 100) < chaosCutoff) {
                            // if there are other ways and chaos is true

                            availableDirs.Remove(-dir);
                            dir = availableDirs[Random.Range(0, availableDirs.Count)];

                        } else {
                            // chaos is false or no other way but back
                            dir = -dir;
                        }

                    } else {
                        // There is no way backward
                        dir = availableDirs[Random.Range(0, availableDirs.Count)];
                    }
                }
            }

            Debug.DrawRay(transform.position, dir, Color.white, 0.2f);
        }

        target = transform.position + dir;
        target.x = Mathf.RoundToInt(target.x);
        target.z = Mathf.RoundToInt(target.z);
        target.y = 0;

        StartCoroutine(WaitAndStart(1f / vMax));
    }

    private IEnumerator WaitAndStart(float t) {
        yield return new WaitForSeconds(t);
        transform.position = target;
        SetNewTarget();
    }

    private List<Vector3> GetAvailableDirections() {
        List<Vector3> dirs = new List<Vector3>();
        if (!Physics.Raycast(transform.position, VectorConstants.UP, 1, layerMask)) {
            dirs.Add(VectorConstants.UP);
        }
        if (!Physics.Raycast(transform.position, VectorConstants.RIGHT, 1, layerMask)) {
            dirs.Add(VectorConstants.RIGHT);
        }
        if (!Physics.Raycast(transform.position, VectorConstants.DOWN, 1, layerMask)) {
            dirs.Add(VectorConstants.DOWN);
        }
        if (!Physics.Raycast(transform.position, VectorConstants.LEFT, 1, layerMask)) {
            dirs.Add(VectorConstants.LEFT);
        }
        return dirs;
    }

}

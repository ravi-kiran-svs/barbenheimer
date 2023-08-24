using System.Collections.Generic;
using UnityEngine;

public class EnemyNavigation {

    private Vector3 dir = Vector3.zero;
    private Vector3 target = Vector3.zero;

    public Vector3 Dir { get { return dir; } }
    public Vector3 Target { get { return target; } }

    public void SetNewTarget(EnemyModel model, Vector3 p, int layerMask) {
        List<Vector3> availableDirs = GetAvailableDirections(p, layerMask);
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

                    if (availableDirs.Count > 1 && Random.Range(0, 100) < model.chaosCutoff / 4) {
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

                        if (availableDirs.Count > 1 && Random.Range(0, 100) < model.chaosCutoff) {
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

            Debug.DrawRay(p, dir, Color.white, 0.2f);
        }

        target = p + dir;
        target.x = Mathf.RoundToInt(target.x);
        target.z = Mathf.RoundToInt(target.z);
        target.y = 0;
    }

    private List<Vector3> GetAvailableDirections(Vector3 p, int layerMask) {
        List<Vector3> dirs = new List<Vector3>();
        if (!Physics.Raycast(p, VectorConstants.UP, 1, layerMask)) {
            dirs.Add(VectorConstants.UP);
        }
        if (!Physics.Raycast(p, VectorConstants.RIGHT, 1, layerMask)) {
            dirs.Add(VectorConstants.RIGHT);
        }
        if (!Physics.Raycast(p, VectorConstants.DOWN, 1, layerMask)) {
            dirs.Add(VectorConstants.DOWN);
        }
        if (!Physics.Raycast(p, VectorConstants.LEFT, 1, layerMask)) {
            dirs.Add(VectorConstants.LEFT);
        }
        return dirs;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombService : MonoBehaviour {

    [SerializeField] private ExplosionService explosionService;

    [SerializeField] private GameObject Bomb;

    private int layerMask;

    private string SolidWallTag = "SolidWall";
    private string BrickWallTag = "BrickWall";

    private void Awake() {
        layerMask = LayerMask.GetMask("Env");
    }

    public bool DropBomb(Vector3 p, Collider bomberCollider, BombModel bombParams) {
        p.x = Mathf.RoundToInt(p.x);
        p.z = Mathf.RoundToInt(p.z);
        p.y = 0;

        for (int i = 0; i < transform.childCount; i++) {
            if (p == transform.GetChild(i).position) {
                return false;
            }
        }

        gameObject.Instantiate(Bomb, p, Bomb.transform.rotation, transform, bomberCollider, this, bombParams);
        return true;
    }

    public void ExplodeBomb(Vector3 pos, float tExplosion, int radius) {
        int n_up = GetExplosionRadiusInDir(pos, VectorConstants.UP, radius);
        int n_right = GetExplosionRadiusInDir(pos, VectorConstants.RIGHT, radius);
        int n_down = GetExplosionRadiusInDir(pos, VectorConstants.DOWN, radius);
        int n_left = GetExplosionRadiusInDir(pos, VectorConstants.LEFT, radius);

        explosionService.Explode(pos, tExplosion, n_up, n_right, n_down, n_left);
    }

    public int GetExplosionRadiusInDir(Vector3 p, Vector3 dir, int r) {
        int n = 0;

        for (int i = 0; i < r; i++) {
            RaycastHit hit;
            bool doesIntersect = Physics.Raycast(p + i * dir, dir, out hit, 1, layerMask);

            if (!doesIntersect) {
                n++;

            } else {
                if (hit.collider.CompareTag(BrickWallTag)) {
                    n++;
                    break;

                } else if (hit.collider.CompareTag(SolidWallTag)) {
                    break;
                }
            }
        }

        return n;
    }

}

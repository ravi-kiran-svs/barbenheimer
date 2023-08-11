using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombService : MonoBehaviour {

    [SerializeField] private ExplosionService explosionService;

    [SerializeField] private GameObject Bomb;

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

    public void ExplodeBomb(Vector3 pos, float tExplosion, int n_up, int n_right, int n_down, int n_left) {
        explosionService.Explode(pos, tExplosion, n_up, n_right, n_down, n_left);
    }

}

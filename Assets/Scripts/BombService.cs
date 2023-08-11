using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombService : MonoBehaviour {

    [SerializeField] private GameObject Bomb;

    public void DropBomb(Vector3 p, Collider bomberCollider) {
        p.x = Mathf.RoundToInt(p.x);
        p.z = Mathf.RoundToInt(p.z);
        p.y = 0;

        gameObject.Instantiate(Bomb, p, Bomb.transform.rotation, transform, bomberCollider);
    }

}

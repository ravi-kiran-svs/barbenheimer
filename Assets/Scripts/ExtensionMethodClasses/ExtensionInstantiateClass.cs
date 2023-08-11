using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionInstantiateClass {

    public static Object Instantiate(this Object obj, Object prefab, Vector3 pos, Quaternion rot, Transform parent, Collider bomberCollider) {
        GameObject bomb = Object.Instantiate(prefab, pos, rot, parent) as GameObject;
        bomb.GetComponent<BombController>().bomberCollider = bomberCollider;
        return bomb;
    }

}

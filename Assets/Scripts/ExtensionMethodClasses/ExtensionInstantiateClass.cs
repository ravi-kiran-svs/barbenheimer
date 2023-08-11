using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionInstantiateClass {

    public static Object Instantiate(this Object obj, Object prefab, Vector3 pos, Quaternion rot, Transform parent, Collider bomberCollider, BombService bombService) {
        GameObject bomb = Object.Instantiate(prefab, pos, rot, parent) as GameObject;
        bomb.GetComponent<BombController>().bombService = bombService;
        bomb.GetComponent<BombController>().bomberCollider = bomberCollider;
        return bomb;
    }

    public static Object Instantiate(this Object obj, Object prefab, Vector3 pos, Quaternion rot, Transform parent, float t) {
        GameObject explosionElement = Object.Instantiate(prefab, pos, rot, parent) as GameObject;
        explosionElement.GetComponent<ExplosionElementController>().tExplosion = t;
        return explosionElement;
    }

}
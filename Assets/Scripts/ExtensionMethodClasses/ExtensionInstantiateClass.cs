using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionInstantiateClass {

    public static Object Instantiate(this Object obj, Object prefab, Vector3 pos, Quaternion rot, Transform parent,
        Collider bomberCollider, BombModel bombParams) {

        GameObject bomb = Object.Instantiate(prefab, pos, rot, parent) as GameObject;
        bomb.GetComponent<BombController>().bomberCollider = bomberCollider;
        bomb.GetComponent<BombController>().bombParams = bombParams;
        return bomb;
    }

    public static Object Instantiate(this Object obj, Object prefab, Vector3 pos, Quaternion rot, Transform parent, float t) {
        GameObject explosionElement = Object.Instantiate(prefab, pos, rot, parent) as GameObject;
        explosionElement.GetComponent<ExplosionElementController>().tExplosion = t;
        return explosionElement;
    }

    public static Object Instantiate(this Object obj, Object prefab, Vector3 pos, Quaternion rot, Transform parent, EnemyModel model) {
        GameObject enemy = Object.Instantiate(prefab, pos, rot, parent) as GameObject;
        enemy.GetComponent<EnemyController>().SetEnemyModel(model);
        return enemy;
    }

}

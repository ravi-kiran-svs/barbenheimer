using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionInstantiateClass {

    // Creating a Bomb
    public static GameObject Instantiate(this GameObject obj, GameObject prefab, Vector3 pos, Quaternion rot, Transform parent,
        Collider bomberCollider, BombModel bombParams) {

        GameObject bomb = GameObject.Instantiate(prefab, pos, rot, parent);
        bomb.GetComponent<BombController>().bomberCollider = bomberCollider;
        bomb.GetComponent<BombController>().bombParams = bombParams;
        return bomb;
    }

    // Creating an Explosion Element
    /*public static GameObject Instantiate(this GameObject obj, GameObject prefab, Vector3 pos, Quaternion rot, Transform parent, float t) {
        GameObject explosionElement = GameObject.Instantiate(prefab, pos, rot, parent);
        explosionElement.GetComponent<ExplosionElementController>().tExplosion = t;
        return explosionElement;
    }*/

    // Creating an Enemy
    public static GameObject Instantiate(this GameObject obj, GameObject prefab, Vector3 pos, Quaternion rot, Transform parent, EnemyModel model, Action onDeath) {
        GameObject enemy = GameObject.Instantiate(prefab, pos, rot, parent);
        enemy.GetComponent<EnemyController>().SetEnemyModel(model);
        enemy.GetComponent<EnemyController>().OnDeath += onDeath;
        return enemy;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectPoolio {

    private Queue<GameObject> pool = new Queue<GameObject>();

    public GameObjectPoolio(int n, GameObject prefab, Transform parent) {
        for (int i = 0; i < n; i++) {
            GameObject expl = GameObject.Instantiate(prefab, parent);
            expl.SetActive(false);
            pool.Enqueue(expl);
        }
    }

    public GameObject GetFromPool() {
        return pool.Dequeue();
    }

    public void AddIntoPool(GameObject go) {
        pool.Enqueue(go);
    }

}

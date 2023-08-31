using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionService : MonoSingleton<ExplosionService> {

    [SerializeField] private GameObject ExplosionElement;

    GameObjectPoolio pool;

    private void Start() {
        BomberModel bomberStats = LevelService.Instance.BomberBoyStats;
        int n = bomberStats.nBombMax * (1 + 4 * bomberStats.bombModel.radius);
        pool = new GameObjectPoolio(n, ExplosionElement, transform);
    }

    // instantiate extension can be removed
    public void Explode(Vector3 pos, float tExplosion, int n_up, int n_right, int n_down, int n_left) {
        //gameObject.Instantiate(ExplosionElement, pos, ExplosionElement.transform.rotation, transform, tExplosion);
        SpawnExpl(pos, tExplosion);

        for (int i = 1; i <= n_up; i++) {
            //gameObject.Instantiate(ExplosionElement, pos + i * VectorConstants.UP, ExplosionElement.transform.rotation, transform, tExplosion);
            SpawnExpl(pos + i * VectorConstants.UP, tExplosion);
        }

        for (int i = 1; i <= n_right; i++) {
            //gameObject.Instantiate(ExplosionElement, pos + i * VectorConstants.RIGHT, ExplosionElement.transform.rotation, transform, tExplosion);
            SpawnExpl(pos + i * VectorConstants.RIGHT, tExplosion);
        }

        for (int i = 1; i <= n_down; i++) {
            //gameObject.Instantiate(ExplosionElement, pos + i * VectorConstants.DOWN, ExplosionElement.transform.rotation, transform, tExplosion);
            SpawnExpl(pos + i * VectorConstants.DOWN, tExplosion);
        }

        for (int i = 1; i <= n_left; i++) {
            //gameObject.Instantiate(ExplosionElement, pos + i * VectorConstants.LEFT, ExplosionElement.transform.rotation, transform, tExplosion);
            SpawnExpl(pos + i * VectorConstants.LEFT, tExplosion);
        }
    }

    private void SpawnExpl(Vector3 p, float t) {
        GameObject expl = pool.GetFromPool();
        //GameObject expl = pool.Dequeue();
        expl.transform.position = p;
        expl.GetComponent<ExplosionElementController>().tExplosion = t;
        expl.GetComponent<ExplosionElementController>().OnExplFinish += OnExplFinish;
        expl.SetActive(true);

        expl.GetComponent<IPoolObject>().OnObjectPooled();
    }

    private void OnExplFinish(GameObject expl) {
        expl.GetComponent<ExplosionElementController>().OnExplFinish -= OnExplFinish;
        pool.AddIntoPool(expl);
        //pool.Enqueue(expl);
    }

}

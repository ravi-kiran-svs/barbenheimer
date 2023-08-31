using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionService : MonoSingleton<ExplosionService> {

    [SerializeField] private GameObject ExplosionElement;

    // related to Object Pooling
    private int nMaxExpls;

    private void Start() {
        BomberModel bomberStats = LevelService.Instance.BomberBoyStats;
        nMaxExpls = bomberStats.nBombMax * (1 + 4 * bomberStats.bombModel.radius);

        for (int i = 0; i < nMaxExpls; i++) {
            GameObject expl = Instantiate(ExplosionElement, transform);
            expl.SetActive(false);
        }
    }

    public void Explode(Vector3 pos, float tExplosion, int n_up, int n_right, int n_down, int n_left) {
        gameObject.Instantiate(ExplosionElement, pos, ExplosionElement.transform.rotation, transform, tExplosion);

        for (int i = 1; i <= n_up; i++) {
            gameObject.Instantiate(ExplosionElement, pos + i * VectorConstants.UP, ExplosionElement.transform.rotation, transform, tExplosion);
        }

        for (int i = 1; i <= n_right; i++) {
            gameObject.Instantiate(ExplosionElement, pos + i * VectorConstants.RIGHT, ExplosionElement.transform.rotation, transform, tExplosion);
        }

        for (int i = 1; i <= n_down; i++) {
            gameObject.Instantiate(ExplosionElement, pos + i * VectorConstants.DOWN, ExplosionElement.transform.rotation, transform, tExplosion);
        }

        for (int i = 1; i <= n_left; i++) {
            gameObject.Instantiate(ExplosionElement, pos + i * VectorConstants.LEFT, ExplosionElement.transform.rotation, transform, tExplosion);
        }
    }

}

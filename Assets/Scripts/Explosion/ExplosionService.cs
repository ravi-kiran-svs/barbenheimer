using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionService : MonoBehaviour {

    [SerializeField] private GameObject ExplosionElement;

    private Vector3 UP = new Vector3(0, 0, 1);
    private Vector3 RIGHT = new Vector3(1, 0, 0);
    private Vector3 DOWN = new Vector3(0, 0, -1);
    private Vector3 LEFT = new Vector3(-1, 0, 0);

    public void Explode(Vector3 pos, float tExplosion, int n_up, int n_right, int n_down, int n_left) {
        gameObject.Instantiate(ExplosionElement, pos, ExplosionElement.transform.rotation, transform, tExplosion);

        for (int i = 1; i <= n_up; i++) {
            gameObject.Instantiate(ExplosionElement, pos + i * UP, ExplosionElement.transform.rotation, transform, tExplosion);
        }

        for (int i = 1; i <= n_right; i++) {
            gameObject.Instantiate(ExplosionElement, pos + i * RIGHT, ExplosionElement.transform.rotation, transform, tExplosion);
        }

        for (int i = 1; i <= n_down; i++) {
            gameObject.Instantiate(ExplosionElement, pos + i * DOWN, ExplosionElement.transform.rotation, transform, tExplosion);
        }

        for (int i = 1; i <= n_left; i++) {
            gameObject.Instantiate(ExplosionElement, pos + i * LEFT, ExplosionElement.transform.rotation, transform, tExplosion);
        }
    }

}

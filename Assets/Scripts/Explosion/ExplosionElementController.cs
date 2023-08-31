using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionElementController : MonoBehaviour, IPoolObject {

    [HideInInspector] public float tExplosion;

    public event Action<GameObject> OnExplFinish;

    public void OnObjectPooled() {
        StartCoroutine(StartExplosionTimer(tExplosion));
    }

    private IEnumerator StartExplosionTimer(float t) {
        yield return new WaitForSeconds(t);
        OnObjectUnpooled();
    }

    public void OnObjectUnpooled() {
        OnExplFinish?.Invoke(gameObject);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        IBoomable boomable = other.gameObject.GetComponent<IBoomable>();

        if (boomable != null) {
            boomable.Boom();
        }
    }

}

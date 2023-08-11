using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionElementController : MonoBehaviour {

    [HideInInspector] public float tExplosion;

    private void Start() {
        StartCoroutine(StartExplosionTimer(tExplosion));
    }

    private IEnumerator StartExplosionTimer(float t) {
        yield return new WaitForSeconds(t);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        IBoomable boomable = other.gameObject.GetComponent<IBoomable>();

        if (boomable != null) {
            boomable.Boom();
        }
    }
}

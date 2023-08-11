using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    [SerializeField] private float timeToExplode = 3;
    [SerializeField] private float tExplosion = 3;

    [SerializeField] private Collider bombCollider;
    [SerializeField] private Collider bombTrigger;

    [HideInInspector] public BombService bombService;
    [HideInInspector] public Collider bomberCollider;

    private void Start() {
        Physics.IgnoreCollision(bomberCollider, bombCollider, true);

        StartCoroutine(StartBombTimer(timeToExplode));
    }

    private void OnTriggerExit(Collider other) {
        Physics.IgnoreCollision(bomberCollider, bombCollider, false);
        bombTrigger.enabled = false;
    }

    private IEnumerator StartBombTimer(float t) {
        yield return new WaitForSeconds(t);
        Boom();
    }

    private void Boom() {
        bombService.ExplodeBomb(transform.position, tExplosion, 1, 1, 1, 1);
        Destroy(gameObject);
    }
}

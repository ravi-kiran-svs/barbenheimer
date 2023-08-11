using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour, IBoomable {

    [SerializeField] private Collider bombCollider;
    [SerializeField] private Collider bombTrigger;

    [HideInInspector] public BombService bombService;
    [HideInInspector] public Collider bomberCollider;

    [HideInInspector] public int radius = 1;
    [HideInInspector] public float timeToExplode = 3;
    [HideInInspector] public float tExplosion = 3;

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

    public void Boom() {
        bombService.ExplodeBomb(transform.position, tExplosion, 1, 1, 1, 1);
        Destroy(gameObject);
    }
}

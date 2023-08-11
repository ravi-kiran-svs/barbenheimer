using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour, IBoomable {

    [SerializeField] private Collider bombCollider;
    [SerializeField] private Collider bombTrigger;

    [HideInInspector] public BombService bombService;
    [HideInInspector] public Collider bomberCollider;

    public BombModel bombParams;

    private void Start() {
        Physics.IgnoreCollision(bomberCollider, bombCollider, true);

        StartCoroutine(StartBombTimer(bombParams.timeToExplode));
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
        bombService.ExplodeBomb(transform.position, bombParams.tExplosion, bombParams.radius, bombParams.radius, bombParams.radius, bombParams.radius);
        Destroy(gameObject);
    }
}

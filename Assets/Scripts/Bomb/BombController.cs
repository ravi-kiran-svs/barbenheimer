using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour, IBoomable {

    [SerializeField] private Collider bombCollider;
    [SerializeField] private Collider bombTrigger;

    [HideInInspector] public Collider bomberCollider;

    public BombModel bombParams;

    public event Action OnBombBoom;

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
        BombService.Instance.ExplodeBomb(transform.position, bombParams.tExplosion, bombParams.radius);

        OnBombBoom?.Invoke();

        Destroy(gameObject);
    }
}

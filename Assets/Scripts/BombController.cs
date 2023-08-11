using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour {

    [SerializeField] private Collider bombCollider;
    [SerializeField] private Collider bombTrigger;

    [HideInInspector] public Collider bomberCollider;

    private void Start() {
        Physics.IgnoreCollision(bomberCollider, bombCollider, true);
    }

    private void OnTriggerExit(Collider other) {
        Physics.IgnoreCollision(bomberCollider, bombCollider, false);
        bombTrigger.enabled = false;
    }
}

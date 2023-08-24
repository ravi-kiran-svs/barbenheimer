using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IBoomable {

    [SerializeField] private EnemyModel enemyModel;
    private int layerMask;

    private EnemyNavigation nav = new EnemyNavigation();

    private void Awake() {
        // should be decided later lol
        layerMask = LayerMask.GetMask("Env", "Bomb", "Expl");

        // nav constructor
    }

    private void Start() {
        StartCoroutine(ResetTarget());
    }

    private void Update() {
        transform.position = transform.position + nav.Dir * enemyModel.vMax * Time.deltaTime;
    }

    public void SetEnemyModel(EnemyModel model) {
        enemyModel = model;
    }

    private void OnTriggerEnter(Collider other) {
        IBoomable boomable = other.gameObject.GetComponent<IBoomable>();

        if (boomable != null) {
            boomable.Boom();
        }
    }

    public void Boom() {
        Destroy(gameObject);
    }

    private IEnumerator ResetTarget() {
        nav.SetNewTarget(enemyModel, transform.position, layerMask);

        yield return new WaitForSeconds(1f / enemyModel.vMax);
        transform.position = nav.Target;
        StartCoroutine(ResetTarget());
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoSingleton<EnemyService> {

    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private EnemyModel[] enemyModels;

    public void SpawnEnemiesAt(List<Vector3> list) {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }

        // assuming we'll spawn 6 bidungas - This part must be complicated
        for (int i = 0; i < 6; i++) {

            int rand = Random.Range(0, list.Count);
            Vector3 p = list[rand];

            // instantiate with a model
            GameObject enemy = Instantiate(EnemyPrefab, p, EnemyPrefab.transform.rotation, transform);
            enemy.GetComponent<EnemyController>().SetEnemyModel(enemyModels[0]);
            list.RemoveAt(rand);
        }


    }

}

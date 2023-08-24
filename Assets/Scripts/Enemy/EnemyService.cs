using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : MonoSingleton<EnemyService> {

    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private EnemyModel[] enemyModels;

    // we need an array of ints = what the number of each enemy type
    private int[] enemyLayout = { 2, 2, 2 };

    // put it in start
    public void SpawnEnemiesAt(List<Vector3> list) {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }

        // This should be iterated in reverse
        // Difficult enemies should be spawned first
        for (int enemyType = 0; enemyType < enemyLayout.Length; enemyType++) {

            for (int i = 0; i < enemyLayout[enemyType]; i++) {
                int rand = Random.Range(0, list.Count);
                Vector3 p = list[rand];

                gameObject.Instantiate(EnemyPrefab, p, EnemyPrefab.transform.rotation, transform, enemyModels[enemyType]);
                list.RemoveAt(rand);
            }
        }


    }

}

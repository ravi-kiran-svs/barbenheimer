using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyTypes/Enemy", menuName = "ScriptableObjects/EnemyModel")]
public class EnemyModel : ScriptableObject {

    public EnemyType type = EnemyType.BIDUNGA;

    [Range(0, 10)]
    public float vMax = 3;

    [Range(0, 100)]
    public int chaosCutoff = 50;

    public bool wallPass = false;

    //public GO enemyView

}

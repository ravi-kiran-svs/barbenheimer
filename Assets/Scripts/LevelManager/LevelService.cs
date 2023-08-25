using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoSingleton<LevelService> {

    [SerializeField] int levelID = 1;

    private int[] enemiesLayout;
    public int[] EnemiesLayout { get { return enemiesLayout; } }

    private BomberModel bomberBoyStats;
    public BomberModel BomberBoyStats { get { return bomberBoyStats; } }

    protected override void Awake() {
        base.Awake();

        levelID = BomberStats.LevelNumber;

        enemiesLayout = EnemyLayout.GetEnemyLayout(levelID);

        bomberBoyStats = BomberStats.Stats;
    }
}

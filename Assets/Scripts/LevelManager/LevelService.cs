using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoSingleton<LevelService> {

    [SerializeField] int levelID = 1;

    private int[] enemiesLayout;
    public int[] EnemiesLayout { get { return enemiesLayout; } }

    private BomberModel bomberStats;
    public BomberModel BomberStats { get { return bomberStats; } }

    protected override void Awake() {
        base.Awake();

        // levelID = BomberStats.Level;

        enemiesLayout = EnemyLayout.GetEnemyLayout(levelID);

        //bomberStats = BomberStats.Stats;
        bomberStats = GetBomberStats();
    }

    private BomberModel GetBomberStats() {
        return new BomberModel(4, 1, new BombModel(), false, false, false);
    }
}

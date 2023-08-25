using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoSingleton<LevelService> {

    [SerializeField] int levelID = 1;

    private int[] enemyLayout;
    public int[] EnemyLayout { get { return enemyLayout; } }

    private BomberModel bomberStats;
    public BomberModel BomberStats { get { return bomberStats; } }

    protected override void Awake() {
        base.Awake();

        enemyLayout = GetEnemyLayout(levelID);
        //bomberStats = BomberStats.Stats;
        bomberStats = GetBomberStats();
    }

    // this shit in another static class
    private int[] GetEnemyLayout(int id) {
        if (id == 1) {
            return new int[] { 6, 0, 0 };

        } else if (id == 2) {
            return new int[] { 4, 2, 0 };

        } else if (id == 3) {
            return new int[] { 3, 3, 0 };

        } else if (id == 4) {
            return new int[] { 3, 2, 1 };

        } else if (id == 5) {
            return new int[] { 2, 2, 2 };

        } else {
            return new int[] { 0, 0, 0 };
        }
    }

    private BomberModel GetBomberStats() {
        return new BomberModel(4, 1, new BombModel(), false, false, false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelService : MonoSingleton<LevelService> {

    private int levelID = 1;

    private int[] enemiesLayout;
    public int[] EnemiesLayout { get { return enemiesLayout; } }

    private BomberModel bomberBoyStats;
    public BomberModel BomberBoyStats { get { return bomberBoyStats; } }

    [SerializeField] private bool resetLevel = true;

    protected override void Awake() {
        base.Awake();

        levelID = BomberStats.LevelNumber;
        enemiesLayout = EnemyLayout.GetEnemyLayout(levelID);
        bomberBoyStats = BomberStats.Stats;
    }

    private void Start() {
        if (resetLevel) {
            WallService.Instance.RegenerateBrickWalls(MapService.Instance.BrickWallSpots);
            EnemyService.Instance.RegenerateEnemies(enemiesLayout, MapService.Instance.EnemySpawnSpots);
            BomberService.Instance.ResetStats(bomberBoyStats);
        }

        BomberService.Instance.Bomber.OnDeath += OnBomberDied;
        EnemyService.Instance.OnAllEnemiesDied += OnAllEnemiesDied;
    }

    private void OnBomberDied() {
        Debug.Log("TRY AGAIN?");
    }

    private void OnAllEnemiesDied() {
        Debug.Log("NEXT LEVEL!");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberService : MonoSingleton<BomberService> {

    public event Action<Vector3> OnBomberMove;

    [SerializeField] private BomberController bomber;
    public BomberController Bomber { get { return bomber; } }

    /*private void Start() {
        BomberModel bomberStats = LevelService.Instance.BomberBoyStats;

        bomber.ResetStats(bomberStats);
    }*/

    private void Start() {
        bomber.OnDeath += OnBomberDied;
    }

    public void ResetStats(BomberModel bomberStats) {
        bomber.ResetStats(bomberStats);
    }

    public void BomberMovedTo(Vector3 p) {
        OnBomberMove?.Invoke(p);
    }

    private void OnBomberDied() {
    }

}

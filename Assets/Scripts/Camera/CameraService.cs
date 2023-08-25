using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraService : MonoSingleton<CameraService> {

    private float BomberPosX;
    public float MainCamTargetX { get { return BomberPosX; } }

    private void Start() {
        BomberService.Instance.OnBomberMove += OnBomberMove;
    }

    private void OnBomberMove(Vector3 p) {
        BomberPosX = p.x;
    }

}

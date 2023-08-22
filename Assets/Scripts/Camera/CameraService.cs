using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraService : MonoSingleton<CameraService> {

    // should be replaced by observer pattern
    [SerializeField] private Transform bomber;

    private float BomberPosX;
    public float MainCamTargetX { get { return BomberPosX; } }

    private void LateUpdate() {
        if (bomber) {
            BomberPosX = bomber.position.x;
        }
    }

}

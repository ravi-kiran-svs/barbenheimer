using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

    [SerializeField] private float minX;
    [SerializeField] private float maxX;

    [Range(0, 1)]
    [SerializeField] private float motionSmooth = 0.2f;

    private float vel;

    private void LateUpdate() {
        Vector3 p = transform.position;

        float x = CameraService.Instance.MainCamTargetX;
        x = Mathf.Clamp(x, minX, maxX);
        p.x = Mathf.SmoothDamp(p.x, x, ref vel, motionSmooth);

        transform.position = p;
    }

}

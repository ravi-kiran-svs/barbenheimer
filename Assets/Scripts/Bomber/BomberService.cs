using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberService : MonoSingleton<BomberService> {

    public event Action<Vector3> OnBomberMove;

    public void BomberMovedTo(Vector3 p) {
        OnBomberMove?.Invoke(p);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickWallController : MonoBehaviour, IBoomable {

    public void Boom() {
        Destroy(gameObject);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallService : MonoSingleton<WallService> {

    [SerializeField] private Transform SolidWalls;
    [SerializeField] private Transform BrickWalls;

    [SerializeField] private GameObject SolidWallPrefab;
    [SerializeField] private GameObject brickWallPrefab;

    public void RegenerateWalls(List<Vector3> stoneWallSpots, List<Vector3> brickWallSpots) {
        RegenerateStoneWalls(stoneWallSpots);
        RegenerateBrickWalls(brickWallSpots);
    }

    public void RegenerateStoneWalls(List<Vector3> list) {
        for (int i = 0; i < SolidWalls.childCount; i++) {
            Destroy(SolidWalls.GetChild(i).gameObject);
        }

        foreach (Vector3 p in list) {
            Instantiate(SolidWallPrefab, p, SolidWallPrefab.transform.rotation, SolidWalls);
        }
    }

    public void RegenerateBrickWalls(List<Vector3> list) {
        for (int i = 0; i < BrickWalls.childCount; i++) {
            Destroy(BrickWalls.GetChild(i).gameObject);
        }

        foreach (Vector3 p in list) {
            Instantiate(brickWallPrefab, p, brickWallPrefab.transform.rotation, BrickWalls);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapService : MonoSingleton<MapService> {

    // should be removed for singleton EnemyService
    [SerializeField] private GameObject enemyService;
    [SerializeField] private Texture2D image;

    private void Start() {
        //List<Vector3> stoneWallSpots = new List<Vector3>();
        List<Vector3> brickWallSpots = new List<Vector3>();
        List<Vector3> enemySpawnSpots = new List<Vector3>();

        for (int i = 0; i < image.width; i++) {
            for (int j = 0; j < image.height; j++) {
                Color c = image.GetPixel(i, j);

                if (c == MapColourConstants.WHITE) {
                    // Stone Walls
                    //stoneWallSpots.Add(new Vector3(i, 0, j));

                } else if (c == MapColourConstants.GREY) {
                    // Brick Walls
                    brickWallSpots.Add(new Vector3(i, 0, j));

                } else if (c == MapColourConstants.RED) {
                    // Enemy Spawns
                    enemySpawnSpots.Add(new Vector3(i, 0, j));
                }
            }
        }

        WallService.Instance.RegenerateBrickWalls(brickWallSpots);
    }

}

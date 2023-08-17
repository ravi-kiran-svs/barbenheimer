using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapService : MonoBehaviour {

    [SerializeField] private WallService wallService;
    [SerializeField] private GameObject enemyService;

    //remove edges - don't need them
    //the colours should be proper
    //image size should be a multiple of 2
    [SerializeField] private Texture2D image;

    private void Start() {
        List<Vector3> stoneWallSpots = new List<Vector3>();
        List<Vector3> brickWallSpots = new List<Vector3>();
        List<Vector3> enemySpawnSpots = new List<Vector3>();

        for (int i = 0; i < image.width; i++) {
            for (int j = 0; j < image.height; j++) {
                Color c = image.GetPixel(i, j);

                if (c == Color.white) {
                    // Stone Walls
                    stoneWallSpots.Add(new Vector3(i, 0, j));

                } else if (c == Color.red) {
                    // Enemy Spawns
                    enemySpawnSpots.Add(new Vector3(i, 0, j));

                } else if (c != Color.black) {
                    // Brick Walls
                    brickWallSpots.Add(new Vector3(i, 0, j));
                }
            }
        }

        //wallService.RegenerateWalls(stoneWallSpots, brickWallSpots);
        wallService.RegenerateBrickWalls(brickWallSpots);
    }

}

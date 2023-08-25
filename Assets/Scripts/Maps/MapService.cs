using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapService : MonoSingleton<MapService> {

    [SerializeField] private Texture2D image;

    private List<Vector3> stoneWallSpots = new List<Vector3>();
    private List<Vector3> brickWallSpots = new List<Vector3>();
    private List<Vector3> enemySpawnSpots = new List<Vector3>();

    public List<Vector3> StoneWallSpots { get { return stoneWallSpots; } }
    public List<Vector3> BrickWallSpots { get { return brickWallSpots; } }
    public List<Vector3> EnemySpawnSpots { get { return enemySpawnSpots; } }

    protected override void Awake() {
        base.Awake();

        //image randamization in future

        for (int i = 0; i < image.width; i++) {
            for (int j = 0; j < image.height; j++) {
                Color c = image.GetPixel(i, j);

                if (c == MapColourConstants.WHITE) {
                    // Stone Walls
                    stoneWallSpots.Add(new Vector3(i, 0, j));

                } else if (c == MapColourConstants.GREY) {
                    // Brick Walls
                    brickWallSpots.Add(new Vector3(i, 0, j));

                } else if (c == MapColourConstants.RED) {
                    // Enemy Spawns
                    enemySpawnSpots.Add(new Vector3(i, 0, j));
                }
            }
        }
    }

}

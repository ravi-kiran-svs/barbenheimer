using System;

[Serializable]
public class BombModel {

    public int radius = 1;
    public float tExplosion = 2;
    public float timeToExplode = 3;

    public BombModel() { }

    public BombModel(int r, float t1, float t2) {
        radius = r;
        tExplosion = t1;
        timeToExplode = t2;
    }

}

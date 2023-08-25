using System;

[Serializable]
public class BomberModel {

    public float vMax = 5;
    public int nBombMax = 1;
    public BombModel bombModel;

    public bool brickPass = false;
    public bool bombPass = false;
    public bool firePass = false;

    public BomberModel() { }

    public BomberModel(float v, int n, BombModel bomb, bool brickP, bool bombP, bool fireP) {
        vMax = v;
        nBombMax = n;
        bombModel = bomb;

        brickPass = brickP;
        bombPass = bombP;
        firePass = fireP;
    }

}

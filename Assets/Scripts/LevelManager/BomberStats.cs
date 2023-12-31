public static class BomberStats {

    public enum Power {
        FireUp = 1, BombUp = 2, SpeedUp = 3,
        BrickPass = 11, BombPass = 12, FirePass = 13
    }

    private static int level = 1;
    public static int LevelNumber { get { return level; } }

    private static BomberModel bomberStats = new BomberModel(4, 1, new BombModel(1, 2, 3), false, false, false);
    public static BomberModel Stats { get { return bomberStats; } }

    // when player finishes a level and choses a power
    public static void LevelUp(Power power) {
        level++;

        switch (power) {
            case Power.FireUp:
                UpgradeFireUp();
                break;

            case Power.BombUp:
                UpdgradeBombUp();
                break;

            case Power.SpeedUp:
                UpgradeSpeedUp();
                break;

            case Power.BrickPass:
                UpgradeBrickPass();
                break;

            case Power.BombPass:
                UpgradeBombPass();
                break;

            case Power.FirePass:
                UpgradeFirePass();
                break;
        }
    }

    // When player exits to the main menu.
    public static void Reset() {
        level = 1;
        bomberStats = new BomberModel(4, 1, new BombModel(), false, false, false);
    }

    // When player dies
    public static void RemoveAllSplPowers() {
        UpgradeBrickPass(false);
        UpgradeBombPass(false);
        UpgradeFirePass(false);
    }

    private static void UpgradeFireUp() {
        bomberStats.bombModel.radius++;
    }
    private static void UpdgradeBombUp() {
        bomberStats.nBombMax++;
    }
    private static void UpgradeSpeedUp() {
        bomberStats.vMax++;
    }

    private static void UpgradeBrickPass(bool upgrade = true) {
        bomberStats.brickPass = upgrade;
    }
    private static void UpgradeBombPass(bool upgrade = true) {
        bomberStats.bombPass = upgrade;
    }
    private static void UpgradeFirePass(bool upgrade = true) {
        bomberStats.firePass = upgrade;
    }

}

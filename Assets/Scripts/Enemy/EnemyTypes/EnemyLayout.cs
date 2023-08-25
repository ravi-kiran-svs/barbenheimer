public static class EnemyLayout {

    private static readonly int[][] enemyLayout = {
        new int[] { 0, 0, 0 },
        new int[] { 6, 0, 0 },
        new int[] { 4, 2, 0 },
        new int[] { 3, 3, 0 },
        new int[] { 3, 2, 1 },
        new int[] { 2, 2, 2 }
    };

    public static int[] GetEnemyLayout(int level) {
        //complicated logic here lol
        if (level > 0 && level <= 5) {
            return enemyLayout[level];
        }

        return enemyLayout[0];
    }

    public static void LOL() { }

    public static int III = 10;

}

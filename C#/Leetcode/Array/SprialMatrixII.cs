namespace LeetcodeSolutions.Array
{
    // Leetcode 59
    public class SprialMatrixGenerate
    {
        //public static void Main(string[] args)
        //{
        //    SprialMatrixGenerate matrix = new SprialMatrixGenerate();
        //    int[,] matrix1 = matrix.SpiralOrder(3);

        //    int[,] matrix2 = matrix.SpiralOrder(0);
        //}

        // Runtime = 66ms
        // Tx = O(n^2)
        // Sx = O(n^2)
        public int[,] SpiralOrder(int n)
        {
            int[,] matrix = new int[n, n];

            int Top = 0, Bottom = n - 1, Left = 0, Right = n - 1;
            int value = 1;
            int dir = 0;

            while (Top <= Bottom && Left <= Right)
            {
                if (dir == 0)
                {
                    for (int i = Left; i <= Right; i++, value++)
                        matrix[Top, i] = value;

                    Top++;
                    dir = 1;
                }
                else if (dir == 1)
                {
                    for (int i = Top; i <= Bottom; i++, value++)
                        matrix[i, Right] = value;

                    Right--;
                    dir = 2;
                }
                else if (dir == 2)
                {
                    for (int i = Right; i >= Left; i--, value++)
                        matrix[Bottom, i] = value;

                    Bottom--;
                    dir = 3;
                }
                else
                {
                    for (int i = Bottom; i >= Top; i--, value++)
                        matrix[i, Left] = value;

                    Left++;
                    dir = 0;
                }
            }

            return matrix;
        }
    }
}

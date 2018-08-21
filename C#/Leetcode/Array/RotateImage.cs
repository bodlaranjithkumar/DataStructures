namespace LeetcodeSolutions.Array
{
    // Leetcode 48 - https://leetcode.com/problems/rotate-image/
    // Submission Detail - https://leetcode.com/submissions/detail/135610878/
    // Clockwise
    public class RotateImage
    {
        // Input =
        //[
        //  [ 5, 1, 9,11],
        //  [ 2, 4, 8,10],
        //  [13, 3, 6, 7],
        //  [15,14,12,16]
        //]

        // Output = 
        //[
        //  [15,13, 2, 5],
        //  [14, 3, 4, 1],
        //  [12, 6, 8, 9],
        //  [16, 7,10,11]
        //]

        //i,j -> 0,0
        //5->0,0=i,j
        //11->0,3=j,n-1-i
        //16->3,3=n-1-i,n-1-j
        //15->3,0=n-1-j,i

        //i,j -> 0,1
        //1->0,1 = i,j
        //10->1,3= j,n-1-i
        //12->3,2 = n-1-i, n-1-j
        //13->2,0 = n-1-j,i


        // In-place array.
        // Symmetric Matrix
        public void RotateInPlace(int[,] input)
        {
            if (input?.Length > 0)
            {
                int n = input.GetLength(0);
                for (int i = 0; i < n / 2; i++)
                {
                    for (int j = i; j < n - 1 - i; j++)
                    {
                        int temp = input[i, j];
                        input[i, j] = input[n - 1 - j, i];
                        input[n - 1 - j, i] = input[n - 1 - i, n - 1 - j];
                        input[n - 1 - i, n - 1 - j] = input[j, n - 1 - i];
                        input[j, n - 1 - i] = temp;
                    }
                }
            }
        }

        //5	0        4 1 5
        //1	3    =>  6 3 0
        //4	6

        // j -> 0 to n
        // i -> 0 to m
        //5->0,0    => 0,2 = j, m-1-i
        //1->1,0    => 0,1
        //4->2,0    => 0,0

        //0->0,1    => 1,2
        //3->1,1    => 1,1
        //6->2,1    => 1,0

        //Works for both symmetric and asymmetric matrices
        // Tx = O(m*n)
        // Sx = O(n*m)
        public int[,] RotateOutPlace(int[,] input)
        {
            int m = input.GetLength(0);
            int n = input.GetLength(1);
            int[,] output = new int[n, m];

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < m; i++)
                {
                    output[j, m - 1 - i] = input[i, j];
                }
            }

            return output;
        }
    }
}

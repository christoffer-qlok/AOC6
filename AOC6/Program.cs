namespace AOC6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Part 1
            int[] times = { 49, 97, 94, 94 };
            int[] distances = { 263, 1532, 1378, 1851 };

            //Part 2
            long time = 49979494;
            long distance = 263153213781851;

            long margin = 1;

            for (int i = 0; i < times.Length; i++)
            {
                long[] res = SolveQuadraticEquation(-1, times[i], distances[i] * -1 - 1);
                long variations = res[1] - res[0] + 1;
                margin *= variations;
            }
            Console.WriteLine($"Part1: {margin}");

            var part2Res = SolveQuadraticEquation(-1, time, distance * -1 - 1);
            Console.WriteLine($"Part2: {part2Res[1] - part2Res[0] + 1}");
        }

        public static long[] SolveQuadraticEquation(double a, double b, double c)
        {
            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

                long min = (long)Math.Ceiling(Math.Min(root1, root2));
                long max = (long)Math.Floor(Math.Max(root1, root2));

                return new long[] { min, max };
            }
            else if (discriminant == 0)
            {
                double root = -b / (2 * a);
                long min = (long)Math.Ceiling(root);
                long max = (long)Math.Floor(root);
                if (min > max)
                {
                    throw new Exception("Bad roots");
                }

                return new long[] { min, max };
            }
            else
            {
                throw new Exception("Imaginary roots");
            }
        }
    }
}
namespace TeamWork.Field
{
    public class Point2D
    {
        public Point2D(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Equality operator that compares if 2 point2Ds are equal
        /// </summary>
        /// <param name="point">First point2D</param>
        /// <param name="point2">Second Point2D</param>
        /// <returns>If the points are equal</returns>
        public static bool operator ==(Point2D point, Point2D point2)
        {
            return point.X == point2.X && point.Y == point2.Y;
        }

        /// <summary>
        /// Diference operator that compares if 2 point2Ds are not equal
        /// </summary>
        /// <param name="point">First point2D</param>
        /// <param name="point2">Second Point2D</param>
        /// <returns>If the points are not equal</returns>
        public static bool operator !=(Point2D point, Point2D point2)
        {
            return point.X != point2.X || point.Y != point2.Y;
        }

        /// <summary>
        /// Substraction operator that decreases both X and Y of the first Point2D by the X and Y of the other Point2D
        /// </summary>
        /// <param name="point">First Point2D</param>
        /// <param name="point2">Second Point2D</param>
        /// <returns>Result Point2D</returns>
        public static Point2D operator -(Point2D point, Point2D point2)
        {
            int x = point.X - point2.X;
            int y = point.Y - point2.Y;
            return new Point2D(x, y);
        }

        /// <summary>
        /// Addition operator that increases both X and Y of the first Point2D by the X and Y of the other Point2D
        /// </summary>
        /// <param name="point">First Point2D</param>
        /// <param name="point2">Second Point2D</param>
        /// <returns>Result Point2D</returns>
        public static Point2D operator +(Point2D point, Point2D point2)
        {
            int x = point.X + point2.X;
            int y = point.Y + point2.Y;
            return new Point2D(x, y);
        }

        /// <summary>
        /// Multiplication operator that multiplies the X and Y values of the Point2D by given amount
        /// </summary>
        /// <param name="point">Point2D to increase</param>
        /// <param name="multiplier">Integer multiplier</param>
        /// <returns>Result point2D</returns>
        public static Point2D operator *(Point2D point, int multiplier)
        {
            int x = point.X * multiplier;
            int y = point.Y * multiplier;
            return new Point2D(x, y);
        }

        /// <summary>
        /// Multiplication operator that multiplies the X and Y values of the Point2D by given amount
        /// </summary>
        /// <param name="multiplier">Integer multiplier</param>
        /// <param name="point">Point2D to increase</param>
        /// <returns>Result point2D</returns>
        public static Point2D operator *(int multiplier,Point2D point)
        {
            int x = point.X * multiplier;
            int y = point.Y * multiplier;
            return new Point2D(x, y);
        }

        /// <summary>
        /// Check if the objects are equal
        /// </summary>
        /// <param name="obj">Object to check with</param>
        /// <returns></returns>
        public override bool Equals(object obj) 
        {
            Point2D s = obj as Point2D;
            if (s == null)
            {
                return false;
            }
            return (X == s.X) && (Y == s.Y);
        }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
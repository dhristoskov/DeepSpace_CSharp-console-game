using TeamWork.Field;

namespace TeamWork.Objects
{
    abstract public class Entity
    {
        private Point2D point = new Point2D(10, 15);
        private int speed;

        protected Entity()
        {
            this.Point = point;
            this.Speed = this.speed;
        }

        protected Entity(Point2D point)
        {
            this.Point = point;
            this.Speed = this.speed;
        }

        public Point2D Point
        {
            get {return this.point;}
            set {this.point = value;}
        }

        public int Speed { get; set; }
    }
}

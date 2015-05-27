using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TeamWork.Field;

namespace TeamWork
{
    public class GameObject : Entity, IGameObject, IEntity
    {
        public GameObject()
        {
            base.Speed = 3;
        }
        public GameObject(Point2D point)
            : base(point)
        {
            base.Speed = 1;
        }
        public override string ToString()
        {
            string output = string.Empty;
            output = "&&";
            return output;
        }
    }
}

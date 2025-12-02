using System;

namespace SmellyMarsRover
{
    public class Rover
    {
        private int _y;
        private int _x;
        private Direction _direction;

        public Rover(int x, int y, string direction)
        {
            SetDirection(direction);
            SetCoordinates(x, y);
        }

        private void SetCoordinates(int x, int y)
        {
            _y = y;
            _x = x;
        }

        private void SetDirection(string direction)
        {
            _direction = new Direction(direction);
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("l"))
                {
                    // Rotate Rover to the left
                    if (IsFacingNorth())
                    {
                        SetDirection("W");
                    }
                    else if (IsFacingSouth())
                    {
                        SetDirection("E");
                    }
                    else if (_direction.IsFacingWest())
                    {
                        SetDirection("S");
                    }
                    else
                    {
                        SetDirection("N");
                    }
                }
                else if (command.Equals("r"))
                {
                    // Rotate Rover to the right
                    if (IsFacingNorth())
                    {
                        SetDirection("E");
                    }
                    else if (IsFacingSouth())
                    {
                        SetDirection("W");
                    }
                    else if (_direction.IsFacingWest())
                    {
                        SetDirection("N");
                    }
                    else
                    {
                        SetDirection("S");
                    }
                }
                else
                {
                    // Displace Rover
                    var displacement1 = -1;

                    if (command.Equals("f"))
                    {
                        displacement1 = 1;
                    }

                    var displacement = displacement1;

                    if (IsFacingNorth())
                    {
                        SetCoordinates(_x, _y + displacement);
                    }
                    else if (IsFacingSouth())
                    {
                        SetCoordinates(_x, _y - displacement);
                    }
                    else if (_direction.IsFacingWest())
                    {
                        SetCoordinates(_x - displacement, _y);
                    }
                    else
                    {
                        SetCoordinates(_x + displacement, _y);
                    }
                }
            }
        }

        private bool IsFacingSouth()
        {
            return _direction._direction.Equals("S");
        }

        private bool IsFacingNorth()
        {
            return _direction._direction.Equals("N");
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Rover)obj);
        }

        protected bool Equals(Rover other)
        {
            return _y == other._y && _x == other._x && Equals(_direction, other._direction);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_y, _x, _direction);
        }

        public override string ToString()
        {
            return $"{nameof(_y)}: {_y}, {nameof(_x)}: {_x}, {nameof(_direction)}: {_direction}";
        }
    }

    internal class Direction
    {
        public readonly string _direction;

        public Direction(string direction)
        {
            _direction = direction;
            
        }

        protected bool Equals(Direction other)
        {
            return _direction == other._direction;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Direction)obj);
        }

        public override int GetHashCode()
        {
            return (_direction != null ? _direction.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return $"{nameof(_direction)}: {_direction}";
        }

        public bool IsFacingWest()
        {
            return this._direction.Equals("W");
        }
    }
}

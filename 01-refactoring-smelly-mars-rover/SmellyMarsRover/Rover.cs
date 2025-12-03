using System;

namespace SmellyMarsRover
{
    public class Rover
    {
        private Direction _direction;
        private Coordinates _coordinates;

        public Rover(int x, int y, string direction)
        {
            _direction = new Direction(direction);
            _coordinates = new Coordinates(x, y);
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("l"))
                {
                    // Rotate Rover to the left
                    if (_direction.IsFacingNorth())
                    {
                        _direction = new Direction("W");
                    }
                    else if (_direction.IsFacingSouth())
                    {
                        _direction = new Direction("E");
                    }
                    else if (_direction.IsFacingWest())
                    {
                        _direction = new Direction("S");
                    }
                    else
                    {
                        _direction = new Direction("N");
                    }
                }
                else if (command.Equals("r"))
                {
                    // Rotate Rover to the right
                    if (_direction.IsFacingNorth())
                    {
                        _direction = new Direction("E");
                    }
                    else if (_direction.IsFacingSouth())
                    {
                        _direction = new Direction("W");
                    }
                    else if (_direction.IsFacingWest())
                    {
                        _direction = new Direction("N");
                    }
                    else
                    {
                        _direction = new Direction("S");
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

                    if (_direction.IsFacingNorth())
                    {
                        _coordinates = _coordinates.DisplaceAlongYAxis(displacement);
                    }
                    else if (_direction.IsFacingSouth())
                    {
                        _coordinates = _coordinates.DisplaceAlongYAxis(-displacement);
                    }
                    else if (_direction.IsFacingWest())
                    {
                        _coordinates = _coordinates.DisplaceAlongXAxis(-displacement);
                    }
                    else
                    {
                        _coordinates = _coordinates.DisplaceAlongXAxis(displacement);
                    }
                }
            }
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
            return Equals(_direction, other._direction) && Equals(_coordinates, other._coordinates);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_direction, _coordinates);
        }

        public override string ToString()
        {
            return $"{nameof(_direction)}: {_direction}, {nameof(_coordinates)}: {_coordinates}";
        }
    }
}

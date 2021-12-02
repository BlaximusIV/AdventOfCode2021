namespace Day2
{
    public static class TravelSimulator
    {
        // The only directions given
        private const string up = nameof(up);
        private const string down = nameof(down);
        private const string forward = nameof(forward);

        public static int FindDistanceTravelled(List<(string direction, int magnitude)> pathDirections)
        {
            var horizontalRange = 0;
            var depth = 0;

            foreach (var step in pathDirections)
            {
                if (step.direction == up)
                    depth -= step.magnitude;

                else if (step.direction == down)
                    depth += step.magnitude;

                else
                    horizontalRange += step.magnitude;
            }

            return depth * horizontalRange;
        }

        public static int FindDistanceTravelledByAim(List<(string direction, int magnitude)> pathDirections)
        {
            var horizontalRange = 0;
            var depth = 0;
            var aim = 0;

            foreach (var step in pathDirections)
            {
                if (step.direction == up)
                    aim -= step.magnitude;

                else if (step.direction == down)
                    aim += step.magnitude;

                else // must be 'forward'
                {
                    horizontalRange += step.magnitude;
                    depth += step.magnitude * aim;
                }
            }

            return depth * horizontalRange;
        }
    }
}

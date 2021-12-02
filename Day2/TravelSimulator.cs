namespace Day2
{
    public static class TravelSimulator
    {
        public static int FindDistanceTravelled(List<(string direction, int magnitude)> pathDirections)
        {
            // The only directions given
            const string up = nameof(up);
            const string down = nameof(down);
            const string forward = nameof(forward);

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

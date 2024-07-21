namespace AP.ScoreSystem.UI
{
    public static class Formatter
    {
        private const int DEFAULT_DIGITS_PREPENDED = 7;

        public static string FormatPoints(int points, int digitsPrepended = DEFAULT_DIGITS_PREPENDED)
        {
            string format = $"{{0,{digitsPrepended}:D{digitsPrepended}}}";
            return string.Format(format, points);
        }
    }
}
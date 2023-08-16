namespace TinderSuitev3.Helpers
{
    public static class LocationHelper
    {
        public static bool IsValidLatitude(double latitude)
        {
            return latitude is >= -90 and <= 90;
        }

        public static bool IsValidLongitude(double longitude)
        {
            return longitude is >= -180 and <= 180;
        }
    }
}

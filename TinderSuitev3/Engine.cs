namespace TinderSuitev3
{
    public static class Engine
    {
        public static string ProcessEthnicity(byte[] imageBytes)
        {
            return EthnicityModel.Predict(new EthnicityModel.ModelInput()
            {
                ImageSource = imageBytes
            }).PredictedLabel;
        }
    }
}

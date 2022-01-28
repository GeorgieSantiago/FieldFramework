namespace Field.Survival
{
    public enum SurvivalExposure {
        ColdExposure,
        RainExposure,
        Exposure,
        Sheltered
    }

    public static class SurvivalExposureUtil {
        public static string GetExposureEventString(SurvivalExposure exposure)
        {
            return "FIELD_SURVIVAL_EVENT_EXPOSURE_" + exposure.ToString();
        }
    }
}
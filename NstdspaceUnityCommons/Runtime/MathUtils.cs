namespace Nstdspace.Commons
{
    public static class MathUtils
    {
        public static float Remap(float input, float fromMin, float fromMax, float toMin, float toMax)
        {
            float relativeInput = (input - fromMin) / (fromMax - fromMin);
            return toMin + relativeInput * (toMax - toMin);
        }
    }
}
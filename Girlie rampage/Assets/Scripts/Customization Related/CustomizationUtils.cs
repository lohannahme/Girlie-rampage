using System.Linq;

public static class CustomizationUtils
{
    public static bool TryGetValue(this CarAttribute[] list, string key, out float value)
    {
        foreach (CarAttribute attribute in list)
        {
            if (attribute.Key == key)
            {
                value = attribute.GetValue();
                return true;
            }
        }
        value = float.NaN;
        return false;
    }

    public static bool IsCompatible(this CarPartSO[] list, CarPartSO part)
    {
        foreach (CarPartSO listPart in list)
        {
            if (part.Incompatibility.Contains(listPart.Type))
            {
                return false;
            }
        }
        return true;
    }
}
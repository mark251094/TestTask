using System.Linq;

namespace TestTask.Common
{
    public static class Utils
    {
        public static string GetDifference<T>(T obj1, T obj2)
        {
            string returnVal = null;

            if (!obj1.GetType().GetNestedTypes().Any())
            {
                var fields = obj1.GetType().GetProperties();

                foreach (var field in fields)
                {
                    if (!field.GetValue(obj1).Equals(field.GetValue(obj2)))
                    {
                        returnVal += field.Name + " set from " + field.GetValue(obj1).ToString() + " to " + field.GetValue(obj2).ToString() + "\n";
                    }
                }
            }

            return returnVal;
        }
    }
}

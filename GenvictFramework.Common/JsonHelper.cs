using Newtonsoft.Json;

namespace GenvictFramework.Common
{
    public class JsonHelper<T>
    {
        /// <summary>
        /// json转换为对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ConvertToObj(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 对象转换为json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ConvertToStr(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
#region


#endregion

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using GitScraping.Domain.Bases;

namespace GitScraping.Domain.Utils
{
    public static class JsonUtilities
    {
        public static List<TTargetModel> GetListFromJson<TTargetModel>(Stream jsonStream)
            where TTargetModel : Entity
        {
            var reader = new StreamReader(jsonStream);
            var jsonString = reader.ReadToEnd();

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.Converters.Add(new JsonStringEnumConverter());

            var list = JsonSerializer.Deserialize<List<TTargetModel>>(jsonString, options);

            return list;
        }
    }
}
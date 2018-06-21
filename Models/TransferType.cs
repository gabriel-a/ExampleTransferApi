using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExampleTransferApi.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransferType
    {
        Policy,
        MergerOrAcquisition
    }
}
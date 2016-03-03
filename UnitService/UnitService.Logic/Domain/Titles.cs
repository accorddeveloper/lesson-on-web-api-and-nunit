namespace UnitService.Logic.Domain
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Titles : short
    {
        Mr = (short)0,

        Mrs = (short)1,

        Ms = (short)2,

        Miss = (short)3
    }
}
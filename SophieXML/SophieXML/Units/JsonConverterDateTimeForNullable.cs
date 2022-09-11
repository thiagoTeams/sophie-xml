using System;
using System.Globalization;

namespace SophieXML.Units
{
    // https://blog.magnusmontin.net/2020/04/03/custom-data-types-in-asp-net-core-web-apis/
    
	/// <summary>
	/// System.Text.Json
	/// </summary>
	public class JsonConverterDateTimeNullable : System.Text.Json.Serialization.JsonConverter<DateTime?>
	{
        const string formatPattern = "yyyy-MM-ddTHH:mm:ss";

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime?);
        }

        public override DateTime? Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
        {
            try
            {
                string dateString = reader.GetString();
                if (string.IsNullOrEmpty(dateString) || dateString.Length != 19) return null;

                //DateTime dateTime = DateTimes.Parse(dateString);
                DateTime dateTime = DateTimes.ParseExact(dateString, formatPattern);
                //DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                    dateTime.Hour, dateTime.Minute, dateTime.Second, DateTimeKind.Unspecified);
                //return dateTime;
            }
            catch (Exception ex)
            {
                Logs.debug("Exception Read Json DateTime: " + ex.StackTrace);
            }
            return null;
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, DateTime? value, System.Text.Json.JsonSerializerOptions options)
        {
            try
            {
                DateTime? dateTime = value as DateTime?;
                if (dateTime == null || !value.HasValue)
                {
                    //writer.WriteNull("");
                    writer.WriteStringValue("");
                }
                else
                {   
                    DateTime _dateTime = new DateTime(dateTime?.Year ?? 1900, dateTime?.Month ?? 01, dateTime?.Day ?? 01,
                                                      dateTime?.Hour ?? 0, dateTime?.Minute ?? 0, dateTime?.Second ?? 0, DateTimeKind.Unspecified);
                    writer.WriteStringValue(_dateTime.ToString(formatPattern));
                    //writer.WriteStringValue(_dateTime);
                }
            }
            catch (Exception ex)
            {
                Logs.debug("Exception Write Json DateTime: " + ex.StackTrace);
            }
        }

        //public override DateTime? Read(ref System.Text.Json.Utf8JsonReader reader, Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(reader.GetString())) return null;
        //        DateTime datetime;
        //        if (DateTime.TryParse(reader.GetString(), out datetime))
        //        {
        //            return datetime;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.debug("Exception: " + ex.StackTrace);
        //    }
        //    return null;
        //}

        //public override void Write(System.Text.Json.Utf8JsonWriter writer, DateTime? value, System.Text.Json.JsonSerializerOptions options)
        //{
        //	try
        //	{
        //		if (!value.HasValue)
        //		{
        //			writer.WriteStringValue("");
        //		}
        //		else
        //		{
        //			writer.WriteStringValue(value.Value);
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		Logs.debug("Exception: " + ex.StackTrace);
        //	}
        //}
    }



    /// <summary>
    /// Newtonsoft.Json
    /// </summary>
    public class NewtonsoftJsonConverterDateTimeNullable : Newtonsoft.Json.JsonConverter
	{
        const string format = "yyyy-MM-ddTHH:mm:ss";

        public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime?);
		}

		public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			try
            {
                string dateString = (reader.Value as DateTime?)?.ToString(format);
                if (string.IsNullOrEmpty(dateString) || (reader.Value as DateTime?)?.Kind == DateTimeKind.Utc) return null;

                //DateTime dateTime = DateTimes.Parse(dateString);
                DateTime dateTime = DateTimes.ParseExact(dateString, format);
                //DateTime dateTime = DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);

                return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                    dateTime.Hour, dateTime.Minute, dateTime.Second, DateTimeKind.Unspecified);
                //return dateTime;
            }
            catch (Exception ex)
			{
				Logs.debug("Exception Read NewtonsoftJson DateTime: " + ex.StackTrace);
            }
            return null;
		}

		public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
		{
			try
            {
                DateTime? dateTime = value as DateTime?;
                if (dateTime == null)
                {
                    //writer.WriteNull();
                    writer.WriteValue("");
                }
                else
                {
                    DateTime _dateTime = new DateTime(dateTime?.Year ?? 1900, dateTime?.Month ?? 01, dateTime?.Day ?? 01,
                                                      dateTime?.Hour ?? 0, dateTime?.Minute ?? 0, dateTime?.Second ?? 0, DateTimeKind.Unspecified);
                    writer.WriteValue(_dateTime.ToString(format));
                    //writer.WriteValue(_dateTime);
                }
			}
			catch (Exception ex)
			{
				Logs.debug("Exception Write NewtonsoftJson DateTime: " + ex.StackTrace);
			}
		}

        //public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        //{
        //    try
        //    {
        //        if (reader.Value == null) return null;
        //        DateTime datetime;
        //        if (DateTime.TryParse(reader.Value.ToString(), out datetime))
        //        {
        //            return datetime;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.debug("Exception: " + ex.StackTrace);
        //    }
        //    return null;
        //}

        //public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        //{
        //    try
        //    {
        //        DateTime? datetime = value as DateTime?;
        //        writer.Formatting = Newtonsoft.Json.Formatting.Indented;
        //        if (datetime == null)
        //        {
        //            writer.WriteNull();
        //        }
        //        else
        //        {
        //            writer.WriteValue(datetime);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Logs.debug("Exception: " + ex.StackTrace);
        //    }
        //}
    }


}

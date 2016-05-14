using BefunGen.Helper;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace BefunGen
{
	using ConfigDict = SerializableStringDictionary<SerializableStringDictionary<object>>;

	internal static class Program
	{

		private const string CONFIG_FILENAME = @"befuncompile.cfg.xml";
		private static ConfigDict config;

		[STAThread]
		private static void Main()
		{
			LoadConfig();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
		}

		private static void LoadConfig()
		{
			if (!File.Exists(CONFIG_FILENAME))
			{
				config = new ConfigDict();
				return;
			}

			try
			{
				var serializer = new XmlSerializer(typeof(ConfigDict));
				using (var stream = new FileStream(CONFIG_FILENAME, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					config = (ConfigDict)serializer.Deserialize(stream);
				}
			}
			catch (Exception)
			{
				config = new ConfigDict();
			}
		}

		private static SerializableStringDictionary<object> GetCallerConfig(object caller)
		{
			string callerName = caller.GetType().Name;

			if (! config.ContainsKey(callerName)) config[callerName] = new SerializableStringDictionary<object>();

			return config[callerName];
		}

		public static void SetConfigValue(object caller, string key, object value)
		{
			var dict = GetCallerConfig(caller);

			if (dict.ContainsKey(key) && dict[key] == value) return;

			dict[key] = value;


			var serializer = new XmlSerializer(typeof (ConfigDict));
			using (var stream = new StreamWriter(CONFIG_FILENAME))
			{
				serializer.Serialize(stream, config);
			}
		}

		public static T GetConfigValue<T>(object caller, string key, T defValue)
		{
			var dict = GetCallerConfig(caller);

			if (!dict.ContainsKey(key)) SetConfigValue(caller, key, defValue);

			var value = dict.GetValueOrDefault(key, null);
			if (value is T) return (T) value;

			return defValue;
		}
	}
}
using System;
using Microsoft.Win32;

namespace crgbtruerainbow
{
	class RegSettings
	{
		public const string REG_PATH = @"HKEY_CURRENT_USER\Software\TrueRainbow";
		public const string REG_PATH_HKCU = @"Software\TrueRainbow";
		public const string REG_VAL_WAVELENGTH = "WaveLength";
		public const string REG_VAL_WAVESPEED = "WaveSpeed";
		public const string REG_VAL_UPDATERATE = "UpdateRate";
		public const string REG_VAL_KEYMAP = "KeyMap";

		public int WaveLength { get; set; }
		public int WaveSpeed { get; set; }
		public int UpdateRate { get; set; }
		public int KeyMap { get; set; }

		public RegSettings()
		{
			WaveLength = 100;
			WaveSpeed = 50;
			UpdateRate = 40;
			KeyMap = Keyboard.KEYMAP_US;
		}

		// Load settings from registry, or create key/values if no settings exist.
		public void Load()
		{
			if (Registry.CurrentUser.OpenSubKey(REG_PATH_HKCU) == null)
				Registry.CurrentUser.CreateSubKey(REG_PATH_HKCU);

			if (!Exists(REG_VAL_WAVELENGTH))
				WriteValue(REG_VAL_WAVELENGTH, WaveLength);
			else
				WaveLength = (int)ReadValue(REG_VAL_WAVELENGTH);

			if (!Exists(REG_VAL_WAVESPEED))
				WriteValue(REG_VAL_WAVESPEED, WaveSpeed);
			else
				WaveSpeed = (int)ReadValue(REG_VAL_WAVESPEED);

			if (!Exists(REG_VAL_UPDATERATE))
				WriteValue(REG_VAL_UPDATERATE, UpdateRate);
			else
				UpdateRate = (int)ReadValue(REG_VAL_UPDATERATE);

			if (!Exists(REG_VAL_KEYMAP))
				WriteValue(REG_VAL_KEYMAP, KeyMap);
			else
				KeyMap = (int)ReadValue(REG_VAL_KEYMAP);
		}

		// Save settings to registry.
		public void Save()
		{
			WriteValue(REG_VAL_WAVELENGTH, WaveLength);
			WriteValue(REG_VAL_WAVESPEED, WaveSpeed);
			WriteValue(REG_VAL_UPDATERATE, UpdateRate);
			WriteValue(REG_VAL_KEYMAP, KeyMap);
		}

		protected object ReadValue(string value)
		{
			return Registry.GetValue(REG_PATH, value, null);
		}

		protected void WriteValue(string value, object data)
		{
			Registry.SetValue(REG_PATH, value, data);
		}

		protected bool Exists(string value)
		{
			return Registry.GetValue(REG_PATH, value, null) != null;
		}
	}
}

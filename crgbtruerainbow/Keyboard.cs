using System;
using System.Runtime.InteropServices;

namespace crgbtruerainbow
{
	class Keyboard
	{
		protected static IntPtr pKeyboard = new IntPtr(0);

		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern int ckrgb_init();
		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern void ckrgb_exit();

		[DllImport("libckrgb.dll", CallingConvention=CallingConvention.Cdecl)]
		protected static extern IntPtr ckrgb_get_keyboard(uint idx);
		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern uint ckrgb_get_keyboard_count();
		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern int ckrgb_set_keymap(IntPtr kb, int keymap);

		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern int ckrgb_claim_keyboard(IntPtr kb);

		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern int ckrgb_get_keyboard_width(IntPtr kb);
		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern int ckrgb_get_keyboard_height(IntPtr kb);

		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern int ckrgb_get_key_pos_keyboard(IntPtr kb, int key, out int x, out int y);

		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern int ckrgb_set_key_color(IntPtr kb, int key, byte r, byte g, byte b);
		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern int ckrgb_flush_buffer(IntPtr kb);

		[DllImport("libckrgb.dll", CallingConvention = CallingConvention.Cdecl)]
		protected static extern string ckrgb_get_error_description(int err);

		public const int KEYMAP_US = 0;
		public const int KEYMAP_UK = 1;
		public const int KEY_COUNT = 136;

		public static int Init()
		{
			int err = ckrgb_init();

			if (err > 0)
				return err;

			if (ckrgb_get_keyboard_count() == 0)
			{
				ckrgb_exit();
				return -1;
			}

			pKeyboard = ckrgb_get_keyboard(0);
			if (ckrgb_claim_keyboard(pKeyboard) > 0)
			{
				ckrgb_exit();
				return -2;
			}

			return 0;
		}

		public static void Exit()
		{
			ckrgb_exit();
		}

		public static int GetWidth()
		{
			if (!IsValid())
				return 0;

			return ckrgb_get_keyboard_width(pKeyboard);
		}

		public static int GetHeight()
		{
			if (!IsValid())
				return 0;

			return ckrgb_get_keyboard_height(pKeyboard);
		}

		public static int SetKeymap(int keymap)
		{
			if (!IsValid())
				return 0;

			return ckrgb_set_keymap(pKeyboard, keymap);
		}

		public static int GetKeyPos(int key, out int x, out int y)
		{
			if (!IsValid())
			{
				x = 0; y = 0;
				return -1;
			}

			return ckrgb_get_key_pos_keyboard(pKeyboard, key, out x, out y);
		}

		public static int SetColor(int key, byte r, byte g, byte b)
		{
			if (!IsValid())
				return -1;

			return ckrgb_set_key_color(pKeyboard, key, r, g, b);
		}

		public static int Flush()
		{
			if (!IsValid())
				return -1;

			return ckrgb_flush_buffer(pKeyboard);
		}

		public static bool IsValid()
		{
			return (pKeyboard.ToInt32() != 0) || (ckrgb_get_keyboard(0) == pKeyboard);
		}

		public static string GetErrorDesc(int err)
		{
			return ckrgb_get_error_description(err);
		}
	}
}

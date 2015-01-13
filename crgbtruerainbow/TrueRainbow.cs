using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace crgbtruerainbow
{
	class TrueRainbow
	{
		protected static NotifyIcon g_trayIcon         = null;
		protected static ContextMenu g_trayMenu        = null;

		protected static MenuItem g_menuItem_Preferences = null;
		protected static MenuItem g_menuItem_Resume      = null;
		protected static MenuItem g_menuItem_Pause       = null;
		protected static MenuItem g_menuItem_Exit        = null;

		protected static RegSettings m_settings = null;
		protected static PreferencesForm g_preferences = null;

		protected static RainbowWorker g_worker = null;
		protected static Thread g_workThread    = null;

		protected static volatile Mutex g_mutex = new Mutex();

		[STAThread]
		public static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Check if another process is already running.
			// Multiple keyboard light sources could overload the keyboard!
			if (System.Diagnostics.Process.GetProcessesByName(
				System.IO.Path.GetFileNameWithoutExtension(
				System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1)
			{
				ErrorMsg("True Rainbow is already running.");
				return;
			}

			// Initialize libckrgb.
			int err = Keyboard.Init();
			switch (err)
			{
				case 0: break;
				default:
					ErrorMsg("Problem initializing libckrgb (Error code " + err + ": " + Keyboard.GetErrorDesc(err));
					return;
				case -1:
					ErrorMsg("Could not find a Corsair RGB keyboard. Exiting...");
					return;
				case -2:
					ErrorMsg("Could not claim Corsair RGB keyboard. Is it busy? Exiting...");
					return;
			}

			// Set up tray context menu.
			g_trayMenu = new ContextMenu();
			g_menuItem_Resume = g_trayMenu.MenuItems.Add("Resume", OnResume);
			g_menuItem_Pause = g_trayMenu.MenuItems.Add("Pause", OnPause);
			g_trayMenu.MenuItems.Add("-");
			g_menuItem_Preferences = g_trayMenu.MenuItems.Add("Preferences", OnPreferences);
			g_trayMenu.MenuItems.Add("-");
			g_menuItem_Exit = g_trayMenu.MenuItems.Add("Exit", OnExit);

			g_trayMenu.Popup += new EventHandler(delegate (object sender, EventArgs e) {
				g_menuItem_Resume.Enabled = g_worker.IsPaused();
				g_menuItem_Pause.Enabled = !g_worker.IsPaused();
			});

			// Create icon for tray.
			g_trayIcon = new NotifyIcon();
			g_trayIcon.Text = "CorsairRGB True Rainbow";
			g_trayIcon.ContextMenu = g_trayMenu;
			g_trayIcon.DoubleClick += OnPreferences;

			// Build worker thread.
			g_worker = new RainbowWorker();
			g_workThread = new Thread(g_worker.Run);

			// Load/create and apply settings.
			m_settings = new RegSettings();
			m_settings.Load();
			ApplySettings();

			RefreshIcon();

			// Start rainbows!
			g_workThread.Start();
			Application.Run();
		}

		public static void ErrorMsg(string msg)
		{
			// A very pretty error message.
			MessageBox.Show(msg, "True Rainbow - Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public static RainbowWorker GetRainbowWorker()
		{
			return g_worker;
		}

		public static void ApplySettings()
		{
			if (MutexLock())
			{
				// Send settings data to the worker thread.
				g_worker.SetLength(((float)m_settings.WaveLength / 100.0f) * RainbowWorker.DEFAULT_LENGTH);
				g_worker.SetSpeed(((float)m_settings.WaveSpeed / 100.0f) * RainbowWorker.DEFAULT_SPEED);
				g_worker.SetUpdateRate(1000.0f / (float)m_settings.UpdateRate);
				g_worker.SetKeymap(m_settings.KeyMap);

				MutexUnlock();
			}
		}

		public static RegSettings GetSettings()
		{
			return m_settings;
		}

		public static void RefreshIcon()
		{
			if (g_worker.IsPaused())
				g_trayIcon.Icon = Icon.FromHandle(Properties.Resources.rainbow_p.GetHicon());
			else
				g_trayIcon.Icon = Icon.FromHandle(Properties.Resources.rainbow.GetHicon());

			g_trayIcon.Visible = true;
		}

		public static bool MutexLock()
		{
			return g_mutex.WaitOne();
		}

		public static void MutexUnlock()
		{
			g_mutex.ReleaseMutex();
		}

		protected static void OnPreferences(object sender, EventArgs e)
		{
			if (g_preferences == null)
			{
				// Build preferences form.
				g_preferences = new PreferencesForm();
			}

			g_preferences.Show();
		}

		protected static void OnResume(object sender, EventArgs e)
		{
			g_worker.Resume();
			RefreshIcon();
		}

		protected static void OnPause(object sender, EventArgs e)
		{
			g_worker.Pause();
			RefreshIcon();
		}

		protected static void OnExit(object sender, EventArgs e)
		{
			g_trayIcon.Dispose();

			g_worker.Stop();
			g_workThread.Join();

			if (Keyboard.IsValid())
				Keyboard.Exit();

			Application.Exit();
		}
	}
}

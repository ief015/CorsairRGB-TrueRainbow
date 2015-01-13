using System;
using System.Diagnostics;
using System.Threading;

namespace crgbtruerainbow
{
	class RainbowWorker
	{
		public const float DEFAULT_LENGTH = 1.0f;
		public const float DEFAULT_SPEED = -1.0f;
		public const float DEFAULT_UPDATERATE = 25.0f; // 40 FPS

		protected volatile bool m_running;
		protected volatile bool m_pause;

		protected volatile float m_speed;
		protected volatile float m_length;
		protected volatile float m_updateRate;

		private Stopwatch m_timer = new Stopwatch();

		public RainbowWorker()
		{
			m_running = false;
			m_pause = false;

			m_speed = DEFAULT_LENGTH;
			m_length = DEFAULT_SPEED;
			m_updateRate = DEFAULT_UPDATERATE;
		}

		// Run worker loop.
		public void Run()
		{
			m_running = true;
			m_pause = false;

			m_timer.Restart();

			while (m_running)
			{
				if (!m_pause && Keyboard.IsValid() && TrueRainbow.MutexLock())
				{
					int x, y;
					float r, g, b;
					float h;
					float WIDTH  = (float)Keyboard.GetWidth(),
					      HEIGHT = (float)Keyboard.GetHeight();

					// For every key we will set hue based on its X position.
					for (int i = 0; i < Keyboard.KEY_COUNT; ++i)
					{
						// Grab position of key on keyboard.
						Keyboard.GetKeyPos(i, out x, out y);

						// Find appropriate hue.
						h = ((x / WIDTH) / m_length) + ((float)m_timer.Elapsed.TotalSeconds * m_speed);
						FromHSL(h, 1.0f, 0.5f, out r, out g, out b);

						// Set key colour.
						Keyboard.SetColor(i,
							(byte)(r * 255),
							(byte)(g * 255),
							(byte)(b * 255));
					}

					// Flush the light buffer to the keyboard!
					Keyboard.Flush();

					TrueRainbow.MutexUnlock();
				}

				// Let the keyboard and CPU rest for a bit...
				Sleep(m_updateRate);
			}
		}

		// High precision Sleep function.
		protected void Sleep(float milliseconds)
		{
			System.Threading.Thread.Sleep(new TimeSpan((long)(milliseconds * TimeSpan.TicksPerMillisecond)));
		}

		// Resume animating.
		public void Resume()
		{
			m_pause = false;
			m_timer.Start();
		}

		// Stop animating.
		public void Pause()
		{
			m_pause = true;
			m_timer.Stop();
		}

		// Is the animation paused?
		public bool IsPaused()
		{
			return m_pause;
		}

		// Exit running.
		public void Stop()
		{
			m_running = false;
		}

		// Set speed of rainbow scrolling.
		// Value of 1.0 = 1 second to fully scroll across keyboard.
		// Use negative value to scroll in opposite direction
		public void SetSpeed(float speed)
		{
			m_speed = speed;
		}

		// Set spectrum length.
		// Value of 1.0 = Length of keyboard.
		public void SetLength(float length)
		{
			m_length = length;
		}

		// Set interval between updates in milliseconds.
		public void SetUpdateRate(float milliseconds)
		{
			m_updateRate = milliseconds;
		}

		public void SetKeymap(int keymap)
		{
			Keyboard.SetKeymap(keymap);
		}

		// Get speed value.
		public float GetSpeed()
		{
			return m_speed;
		}

		// Get spectrum length value.
		public float GetLength()
		{
			return m_length;
		}

		// Get interval between updates in milliseconds.
		public float GetUpdateRate()
		{
			return m_updateRate;
		}
		
		/*
		public static void FromHSL_OLD(float h, float s, float l, out float r, out float g, out float b)
		{
			if (h < 0.0f)
				h = 1 - (-h - (float)Math.Floor(-h));
			else if (h > 1.0f)
				h = h - (float)Math.Floor(h);

			if (s < 0.0f)
				s = 0.0f;
			else if (s > 1.0f)
				s = 1.0f;

			if (l < 0.0f)
				l = 0.0f;
			else if (l > 1.0f)
				l = 1.0f;

			r = 0.0f;
			g = 0.0f;
			b = 0.0f;

			float[] rgb = new float[3] {0.0f, 0.0f, 0.0f};

			if (l > 0.0f)
			{
				if (s == 0.0f)
				{
					rgb[0] = l;
					rgb[1] = l;
					rgb[2] = l;
				}
				else
				{
					float temp1, temp2;
					float[] arr = new float[3] { h + 1.0f / 3.0f, h, h - 1.0f / 3.0f };
					temp2 = (l <= 0.5f) ? (l * (1.0f + s)) : (l + s - (l * s));
					temp1 = 2.0f * l - temp2;

					for (int i = 0; i < 3; ++i)
					{
						if (arr[i] < 0.0f)
							arr[i] += 1.0f;
						if (arr[i] > 1.0f)
							arr[i] -= 1.0f;

						if (6.0f * arr[i] < 1.0f)
							rgb[i] = temp1 + (temp2 - temp1) * arr[i] * 6.0f;
						else if (2.0f * arr[i] < 1.0f)
							rgb[i] = temp2;
						else if (3.0f * arr[i] < 2.0f)
							rgb[i] = temp1 + (temp2 - temp1) * ((2.0f/3.0f) - arr[i]) * 6.0f;
						else
							rgb[i] = temp1;
					}
				}
			}

			r = rgb[0];
			g = rgb[1];
			b = rgb[2];
		}
		*/
		
		// Calculate RGB from HSL. Values are scalar between 0 -> 1.
		public static void FromHSL(float h, float s, float l, out float r, out float g, out float b)
		{
			// Algorithm based from: http://www.geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm

			float v = (l <= 0.5f) ? (l * (1.0f + s)) : (l + s - l * s);
			r = l;
			g = l;
			b = l;

			if (h < 0.0f)
				h = 1 - (-h - (float)Math.Floor(-h));
			else if (h > 1.0f)
				h = h - (float)Math.Floor(h);

			if (v > 0.0f)
			{
				float m, sv, fract, vsf, mid1, mid2;
				int sextant;

				m = l + l - v;
				sv = (v - m) / v;
				h *= 6.0f;
				sextant = (int)h;
				fract = h - sextant;
				vsf = v * sv * fract;
				mid1 = m + vsf;
				mid2 = v - vsf;

				switch (sextant)
				{
				case 0:
				case 6:
					r = v;
					g = mid1;
					b = m;
					break;
				case 1:
					r = mid2;
					g = v;
					b = m;
					break;
				case 2:
					r = m;
					g = v;
					b = mid1;
					break;
				case 3:
					r = m;
					g = mid2;
					b = v;
					break;
				case 4:
					r = mid1;
					g = m;
					b = v;
					break;
				case 5:
					r = v;
					g = m;
					b = mid2;
					break;
				}
			}
		}
	}
}

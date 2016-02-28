

public static int[] RGBToHSV(int[] rgb)
		{
		    int maxI = Max(rgb[0], rgb[1], rgb[2]);
		    int minI = Min(rgb[0], rgb[1], rgb[2]);

			double rF = rgb[0] / 255;
			double gF = rgb[1] / 255;
			double bF = rgb[2] / 255;
			double[] rbgF = { rF, gF, bF };

			int hue;
			if (maxI == 0) hue = (rgb[1] - rgb[2]) / (rgb[maxI] - rgb[minI]);
			else if (maxI == 1) hue = (rgb[2] - rgb[0]) / (rgb[maxI] - rgb[minI]);
			else if (maxI == 2) hue = (rgb[0] - rgb[1]) / (rgb[maxI] - rgb[minI]);

		    int saturation = (int) ( (rgb[maxI] == 0) ? 0 : 1d - (1d * rgb[minI] / rgb[maxI]) );
		    int value = (int) ( rgb[maxI] / 255d );

			return new int[] { hue, saturation, value };
		}

		public static int Max(params int[] nums)
		{
			int i = 0;
			for(int j=0;j<nums.Length;j++) if (nums[j] > nums[i]) i = j;
			return i;
		}
		public static int Min(params int[] nums)
		{
			int i = 0;
			for(int j=0;j<nums.Length;j++) if (nums[j] < nums[i]) i = j;
			return i;
		}

		public static int[] ColorFromHSV(int[] hsv)
		{
		    int hi = (hsv[0] / 60) % 6;
		    double f = hue / 60 - Math.Floor(hue / 60);
		
		    value = value * 255;
		    int v = Convert.ToInt32(value);
		    int p = Convert.ToInt32(value * (1 - saturation));
		    int q = Convert.ToInt32(value * (1 - f * saturation));
		    int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));
		
		    if (hi == 0) return new int[] { v, t, p };
		    else if (hi == 1) return new int[] { q, v, p };
		    else if (hi == 2) return new int[] { p, v, t };
		    else if (hi == 3) return new int[] { p, q, v };
		    else if (hi == 4) return new int[] { t, p, v };
		    else return new int[] { v, p, q };
		}


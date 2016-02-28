﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.Fractals
{
    public static class FractalLibrary
    {
        public static IFractal GetFractal(string name, string[] args)
        { 
   			switch(name)
	    	{
		    	case "mandelbrot": return new Mandelbrot(args);
				case "lyapunov": return new Lyapunov(args);
				default: return null;
	    	}
        }
    }
}

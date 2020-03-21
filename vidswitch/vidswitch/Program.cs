/*
 * Created by SharpDevelop.
 * User: nin2k
 * Date: 3/20/2020
 * Time: 6:45 PM
 * 
 */
using System;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace vidswitch 
{
	class Program
	{
		public static int beforeRotate;	
		
		[DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
 		
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		const int SW_MAXIMIZE = 3;
		
		public static int Main(string[] args)
		{
			if (args.Length == 0)
        	{
            Console.WriteLine("Param 1 - Display Number  [ 1 2 3 4 ] ");
			Console.WriteLine("Param 2 - Rotation [ 0 90 180 270 ]");
			Console.WriteLine("Param 3 - Application");
		    Console.WriteLine("");
		    const string example = "Example: vidswitch 1 90"+ @"""c:\windows\system32\notepad.exe""";
		    Console.WriteLine(example);
            Console.ReadKey();
            return 1;
        	}
		else 
		{
			string getfile = args[2];
			
			if (File.Exists(getfile) == false)
			{
			System.Console.WriteLine("File is missing");
            Console.ReadKey();
            return 1;
        	}
        	
        	uint dnum;
        	bool dispno = uint.TryParse(args[0], out dnum);
        	
        	if (dispno == false || dnum == 0)
        	{
            System.Console.WriteLine("You did not enter a proper display number");
            Console.ReadKey();
            return 1;
        	}
        	
        	int rnum;
        	bool rotateno = int.TryParse(args[1], out rnum);
        	
        	if (rotateno == false)
        	{
            System.Console.WriteLine("You did not enter a display rotation number");
            Console.ReadKey();
            return 1;
        	}
        	
			// Save to return state.
        	beforeRotate = vidswitch.Display.GetCurrentRotate(dnum);

			//Rotate Monitor Display			
        	switch (rnum) {
        		case 0: //0
					try {
						vidswitch.Display.Rotate(dnum,Display.Orientations.DEGREES_CW_0);
						} 
						catch (Exception ex) {					
						System.Console.WriteLine("Error: " + ex.ToString());
					}
        			break;
        		case 90: //3
					try {
						vidswitch.Display.Rotate(dnum,Display.Orientations.DEGREES_CW_90);
						} 
						catch (Exception ex) {					
						System.Console.WriteLine("Error: " + ex.ToString());
					}
        			break;		
        		case 180: //2
					try {
        			vidswitch.Display.Rotate(dnum,Display.Orientations.DEGREES_CW_180);
						} 
						catch (Exception ex) {					
						System.Console.WriteLine("Error: " + ex.ToString());
					}        			
        			break;        			        			
        		case 270: //1
					try {
        			vidswitch.Display.Rotate(dnum,Display.Orientations.DEGREES_CW_270);
						} 
						catch (Exception ex) {					
						System.Console.WriteLine("Error: " + ex.ToString());
					}   
        			break;        			        			
        	}
        	
          
        	// Start Process
            Process obj = new System.Diagnostics.Process();
            obj.StartInfo.FileName = "Notepad.exe";
            obj.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal; 
            obj.Start();
            Thread.Sleep(250);
            // Move application to window
            MoveWindow(obj.MainWindowHandle,vidswitch.Display.MointorPixelStart(dnum),0,640,480,true);
            ShowWindow(obj.MainWindowHandle, SW_MAXIMIZE);
            obj.WaitForExit();

        	
			//Return Rotation back 
            switch (beforeRotate) {
        		case 0: 
					try {
						vidswitch.Display.Rotate(dnum,Display.Orientations.DEGREES_CW_0);
						} 
						catch (Exception ex) {					
						System.Console.WriteLine("Error: " + ex.ToString());
					}
        			break;
        		case 3: 
					try {
						vidswitch.Display.Rotate(dnum,Display.Orientations.DEGREES_CW_90);
						} 
						catch (Exception ex) {					
						System.Console.WriteLine("Error: " + ex.ToString());
					}
        			break;        			
        		case 2: 
					try {
        			vidswitch.Display.Rotate(dnum,Display.Orientations.DEGREES_CW_180);
						} 
						catch (Exception ex) {					
						System.Console.WriteLine("Error: " + ex.ToString());
					}        			
        			break;        			        			
        		case 1: 
					try {
        			vidswitch.Display.Rotate(dnum,Display.Orientations.DEGREES_CW_270);
						} 
						catch (Exception ex) {					
						System.Console.WriteLine("Error: " + ex.ToString());
					}   
        			break;        			        			
        	}        	      	 
        	      	 return 0;
			
		}
		}
		



		
	}
}
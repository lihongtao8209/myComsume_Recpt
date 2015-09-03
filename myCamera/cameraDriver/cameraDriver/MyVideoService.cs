using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace MyVideoService
{
	public class VideoAPI  //视频API类
	{
		//  视频ＡＰＩ调用
		[DllImport("avicap32.dll")]
		public static extern IntPtr capCreateCaptureWindowA(byte[] lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, int nID);
		[DllImport("avicap32.dll")]
		public static extern bool capGetDriverDescriptionA(short wDriver, byte[] lpszName, int cbName, byte[] lpszVer, int cbVer);
		[DllImport("User32.dll")]
		public static extern bool SendMessage(IntPtr hWnd, int wMsg, bool wParam, int lParam);
		[DllImport("User32.dll")]
		public static extern bool SendMessage(IntPtr hWnd, int wMsg, short wParam, int lParam);
		//  常量
		public const int WM_USER = 0x400;
		public const int WS_CHILD = 0x40000000;
		public const int WS_VISIBLE = 0x10000000;
		public const int SWP_NOMOVE = 0x2;
		public const int SWP_NOZORDER = 0x4;
		public const int WM_CAP_DRIVER_CONNECT = WM_USER + 10;
		public const int WM_CAP_DRIVER_DISCONNECT = WM_USER + 11;
		public const int WM_CAP_SET_CALLBACK_FRAME = WM_USER + 5;
		public const int WM_CAP_SET_PREVIEW = WM_USER + 50;
		public const int WM_CAP_SET_PREVIEWRATE = WM_USER + 52;
		public const int WM_CAP_SET_VIDEOFORMAT = WM_USER + 45;
		public const int WM_CAP_START = WM_USER;
		public const int WM_CAP_SAVEDIB = WM_CAP_START + 25;
	}
	public class cVideo     //视频类
	{
		private IntPtr lwndC;       //保存无符号句柄
		private IntPtr mControlPtr; //保存管理指示器
		private int mWidth;
		private int mHeight;
		private string mErrorMsg;
		public cVideo(IntPtr handle, int width, int height)
		{
			mControlPtr = handle; //显示视频控件的句柄
			mWidth = width;      //视频宽度
			mHeight = height;    //视频高度
		}
		/// <summary>
		/// 打开视频设备
		/// </summary>
		public void StartWebCam()
		{
			byte[] lpszName = new byte[100];
			byte[] lpszVer = new byte[100];
			try
			{
				VideoAPI.capGetDriverDescriptionA(0, lpszName, 100, lpszVer, 100);
				this.lwndC = VideoAPI.capCreateCaptureWindowA(lpszName, VideoAPI.WS_CHILD | VideoAPI.WS_VISIBLE, 0, 0, mWidth, mHeight, mControlPtr, 0);
				if (VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_DRIVER_CONNECT, 0, 0))
				{
					VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_SET_PREVIEWRATE, 100, 0);
					VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_SET_PREVIEW, true, 0);
				}
				else
				{
					mErrorMsg="连接摄像头失败[1]请检查USB是否正确安装.[2]是否正确安装驱动";
				}
			}
			catch(Exception e)
			{
				mErrorMsg="打开摄像头出错,原因:"+e.Message;
                throw new Exception(mErrorMsg);
			}
		}
		
		/// <summary>
		/// 关闭视频设备
		/// </summary>
		public void CloseWebcam()
		{
			try
			{
				VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_DRIVER_DISCONNECT, 0, 0);
			}
			catch(Exception e)
			{
				mErrorMsg="关闭摄像头出错,原因:"+e.Message;
                throw new Exception(mErrorMsg);
			}
		}
		///   <summary>
		///   拍照
		///   </summary>
		///   <param   name="path">要保存jpeg文件的路径</param>
		public void GrabImage(IntPtr hWndC, string path)
		{
			try
			{
			IntPtr hBmp = Marshal.StringToHGlobalAnsi(path);
			VideoAPI.SendMessage(lwndC, VideoAPI.WM_CAP_SAVEDIB, 0, hBmp.ToInt32());
			}
			catch(Exception e)
			{
				mErrorMsg="抓取图像"+path+"失败+原因:"+e.Message;
                throw new Exception(mErrorMsg);
			}

		}
	}

}
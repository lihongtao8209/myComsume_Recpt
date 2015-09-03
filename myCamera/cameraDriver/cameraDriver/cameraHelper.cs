using SqlFlow;
using System;
using System.Collections.Generic;
using System.Text;

namespace cameraDriver
{
    class CameraHelper
    {
        Flow flow = new Flow();

        public CameraHelper()
        {

        }

        public string FileName
        {
            get
            {
                return flow.FileName;
            }
        }

        public void Do(string item_no)
        {
            flow.CameraFlow(item_no);
        }

        public void Do_Recpt(string item_no)
        {
            flow.CameraRecptFlow(item_no);
        }
    }
}

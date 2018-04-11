using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using CAP.Utilities;

namespace CAP.Apps.PlaceComponentPlus
{
    public class AddinGlobal
    {
        public static Inventor.Application InventorApp;

        public static string AppFolder = Tools.GetAppFolder("Place Component Plus");

        public static string SettingsFile = Tools.GetHexString("Place Component Plus Settings") + ".xml";

        public static string AppId = "1342749003339575521";

        public static ApplicationSettings AppSettings;

        public static string PanelGUID = "383d648b-00f8-4754-a263-8cfbe52a2616";

        public static string InternalPanelName = "3d3aeae0-1541-4a75-ad92-2f2196a29264";

        public static string PlaceCompFilePath;
       

    }
}

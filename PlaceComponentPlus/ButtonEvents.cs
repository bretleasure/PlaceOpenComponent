using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventor;
using CAP.Utilities;

namespace PlaceComponentPlus
{
    public class ButtonEvents
    {

        static Inventor.Application InvApp = AddinGlobal.InventorApp;

        //static AssemblyDocument assyDoc;

        //static ApplicationSettings oSettings;

        public static void Button1_Event()
        {
            //Check Entitlement
            //if (!Tools.CheckForValidUser(AddinGlobal.InventorApp, "Place Component Plus", AddinGlobal.AppId))
            //{
            //    return;
            //}

            PlaceOpenCompUI frm = new PlaceOpenCompUI();
            frm.ShowDialog();

            if (AddinGlobal.PlaceCompFilePath != null)
            {
                ApplicationTools.PlaceComponent(AddinGlobal.PlaceCompFilePath);
                AddinGlobal.PlaceCompFilePath = null;
            }

        }



    }
}

using System;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using Inventor;
using Microsoft.Win32;
using System.Windows.Forms;
using iAD.Utilities;

namespace PlaceComponentPlus
{
    /// <summary>
    /// This is the primary AddIn Server class that implements the ApplicationAddInServer interface
    /// that all Inventor AddIns are required to implement. The communication between Inventor and
    /// the AddIn is via the methods on this interface.
    /// </summary>
    [GuidAttribute("056800f8-36fe-407f-9fa9-098e17f4229e")]
    public class StandardAddInServer : Inventor.ApplicationAddInServer
    {

        // Inventor application object.
        //private Inventor.Application m_inventorApplication;

        public StandardAddInServer()
        {
        }

        #region ApplicationAddInServer Members

        public void Activate(Inventor.ApplicationAddInSite addInSiteObject, bool firstTime)
        {
            // This method is called by Inventor when it loads the addin.
            // The AddInSiteObject provides access to the Inventor Application object.
            // The FirstTime flag indicates if the addin is loaded for the first time.


            // Initialize AddIn members.
            AddinGlobal.InventorApp = addInSiteObject.Application;

            //Create App Folder if it doesnt exist
            if (!System.IO.Directory.Exists(AddinGlobal.AppFolder))
            {
                DirectoryInfo di = System.IO.Directory.CreateDirectory(AddinGlobal.AppFolder);
                di.Attributes = FileAttributes.Hidden;
            }

            //Get User Settings
            //ApplicationTools.Get_SavedSettings();

            try
            {
                Icon icon1 = new Icon(this.GetType(), "Resources.Place Component Plus.ico");
                Icon icon1_sm = new Icon(icon1, 16, 16);
                InventorButton button1 = new InventorButton("Place Open Component", "cap_PlaceOpenComp", "Allows you to place a component that is open in Inventor into " +
                    "the current assemly.", "Place an open component into this assembly", icon1, icon1_sm);
                button1.Execute = ButtonEvents.Button1_Event;


                if (firstTime)
                {
                    UserInterfaceManager uiMan = AddinGlobal.InventorApp.UserInterfaceManager;

                    if (uiMan.InterfaceStyle == InterfaceStyleEnum.kRibbonInterface)
                    {
                        Ribbon ribbon = uiMan.Ribbons["Assembly"];
                        RibbonTab tab = ribbon.RibbonTabs["id_TabAssemble"];

                        RibbonPanel panel = tab.RibbonPanels["id_PanelA_AssembleComponent"]; //.Add("PlaceComponentPlus", AddinGlobal.InternalPanelName.ToString(), AddinGlobal.PanelGUID.ToString());
                        CommandControls controls = panel.CommandControls;

                        //controls.AddButton(button1.ButtonDef(), true, true);
                        controls["AssemblyPlaceSplit"].ChildControls.AddButton(button1.ButtonDef(), true, true);

                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }

        public void Deactivate()
        {
            // This method is called by Inventor when the AddIn is unloaded.
            // The AddIn will be unloaded either manually by the user or
            // when the Inventor session is terminated


            // Release objects.
            AddinGlobal.InventorApp = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void ExecuteCommand(int commandID)
        {
            // Note:this method is now obsolete, you should use the 
            // ControlDefinition functionality for implementing commands.
        }

        public object Automation
        {
            // This property is provided to allow the AddIn to expose an API 
            // of its own to other programs. Typically, this  would be done by
            // implementing the AddIn's API interface in a class and returning 
            // that class object through this property.

            get
            {

                return null;
            }
        }

        #endregion

    }
}

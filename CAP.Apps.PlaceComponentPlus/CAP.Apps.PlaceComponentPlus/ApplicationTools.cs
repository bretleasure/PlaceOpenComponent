using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using CAP.Utilities;
using System.Windows.Forms;

namespace CAP.Apps.PlaceComponentPlus
{
    public abstract class ApplicationTools
    {
        public static void Get_SavedSettings()
        {
            try
            {
                ApplicationSettings oSettings = new ApplicationSettings();
                oSettings = (ApplicationSettings)XMLTools.Get_ObjectFromXML(AddinGlobal.AppFolder + AddinGlobal.SettingsFile, oSettings);

                AddinGlobal.AppSettings = oSettings;
            }
            catch { }
        }

        public static void PlaceComponent(string fileName)
        {
            CommandManager cmdMgr = AddinGlobal.InventorApp.CommandManager;

            cmdMgr.PostPrivateEvent(PrivateEventTypeEnum.kFileNameEvent, fileName);

            //MessageBox.Show("placing comp " + fileName);

            cmdMgr.ControlDefinitions["AssemblyPlaceComponentCmd"].Execute2(true);
        }

        public static List<InvDoc> GetOpenDocuments()
        {
            List<InvDoc> docs = new List<InvDoc>();

            DocumentsEnumerator vdocs = AddinGlobal.InventorApp.Documents.VisibleDocuments;

            for (int i = 1; i <= vdocs.Count; i++)
            {
                switch (vdocs[i].DocumentType)
                {
                    case DocumentTypeEnum.kAssemblyDocumentObject:
                    case DocumentTypeEnum.kPartDocumentObject:

                        if (vdocs[i].FullFileName != AddinGlobal.InventorApp.ActiveDocument.FullFileName)
                            docs.Add(new InvDoc { Name = vdocs[i].DisplayName, Filepath = vdocs[i].FullFileName });
                        break;
                }
            }

            return docs;
        }
    }
}

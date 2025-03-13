using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using System.Windows.Forms;
using System.Drawing;
using Inventor.InternalNames;

namespace PlaceOpenComponent
{
    public abstract class ApplicationTools
    {
        public static void PlaceComponent(string fileName)
        {
            CommandManager cmdMgr = AddinServer.InventorApp.CommandManager;

            cmdMgr.PostPrivateEvent(PrivateEventTypeEnum.kFileNameEvent, fileName);

            //MessageBox.Show("placing comp " + fileName);

            cmdMgr.ControlDefinitions[CommandNames.AssemblyPlaceComponentCmd].Execute2(true);
        }

        public static List<InvDoc> GetOpenDocuments()
        {
            List<InvDoc> docs = new List<InvDoc>();

            DocumentsEnumerator vdocs = AddinServer.InventorApp.Documents.VisibleDocuments;

            for (int i = 1; i <= vdocs.Count; i++)
            {
                switch (vdocs[i].DocumentType)
                {
                    case DocumentTypeEnum.kAssemblyDocumentObject:
                    case DocumentTypeEnum.kPartDocumentObject:

                        if (vdocs[i].FullFileName != AddinServer.InventorApp.ActiveDocument.FullFileName && vdocs[i].FullFileName != "")
                        {
                            InvDoc newcomp = new InvDoc();
                            newcomp.Name = vdocs[i].DisplayName;
                            newcomp.Filepath = vdocs[i].FullFileName;

                            int GetThumbnailLoopCount = 0;

                            
                            try
                            {                              
                                IPictureDisp thumbnail = (IPictureDisp)vdocs[i].PropertySets["Inventor Summary Information"]["Thumbnail"].Value;
                                newcomp.Thumbnail = ImageConverter.CreateImage(thumbnail);
                            }
                            catch
                            {
                                //Assign default image based on part type

                                switch (vdocs[i].DocumentType)
                                {
                                    case DocumentTypeEnum.kAssemblyDocumentObject:
                                        newcomp.Thumbnail = ImageConverter.CreateImage("Resources.iam.png");
                                        
                                        break;
                                    case DocumentTypeEnum.kPartDocumentObject:
                                        newcomp.Thumbnail = ImageConverter.CreateImage("Resources.ipt.png");
                                        break;
                                }
                                    
                            }

                            docs.Add(newcomp);
                                                    
                        }
                        break;
                }
            }

            return docs;
        }
    }
}

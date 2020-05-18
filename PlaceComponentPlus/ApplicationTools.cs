using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using CAP.Utilities;
using System.Windows.Forms;
using System.Drawing;

namespace PlaceComponentPlus
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

                        if (vdocs[i].FullFileName != AddinGlobal.InventorApp.ActiveDocument.FullFileName && vdocs[i].FullFileName != "")
                        {
                            InvDoc newcomp = new InvDoc();
                            newcomp.Name = vdocs[i].DisplayName;
                            newcomp.Filepath = vdocs[i].FullFileName;

                            int GetThumbnailLoopCount = 0;

                            TryThumbnailAgain:

                            GetThumbnailLoopCount++;

                            try
                            {                              

                                long handle = 0;
                                do
                                {
                                    stdole.IPictureDisp thumbnail = (stdole.IPictureDisp)vdocs[i].PropertySets["Inventor Summary Information"]["Thumbnail"].Value;
                                    handle = thumbnail.Handle;
                                    newcomp.Thumbnail = ImageConverter.PictureToImage(thumbnail);
                                } while (handle < 0);
                                
                            }
                            catch
                            {
                                //Failed to get thumbnail

                                if (GetThumbnailLoopCount < 20)
                                {
                                    goto TryThumbnailAgain;
                                }
                                else
                                {
                                    //Assign default image based on part type

                                    switch (vdocs[i].DocumentType)
                                    {
                                        case DocumentTypeEnum.kAssemblyDocumentObject:
                                            newcomp.Thumbnail = Properties.Resources.iam;
                                            
                                            break;
                                        case DocumentTypeEnum.kPartDocumentObject:
                                            newcomp.Thumbnail = Properties.Resources.ipt;
                                            break;
                                        default:
                                            MessageBox.Show("unknown");
                                            break;
                                    }                                        

                                }
                                    
                            }

                            docs.Add(newcomp);
                                                    
                        }
                        break;
                }
            }

            return docs;
        }

        public class ImageConverter : AxHost
        {
            public ImageConverter() : base(String.Empty) { }

            public static stdole.IPictureDisp ImageToPicture(Image image)
            {
                return (stdole.IPictureDisp)GetIPictureDispFromPicture(image);
            }

            public static stdole.IPictureDisp IconToPicture(Icon icon)
            {
                return ImageToPicture(icon.ToBitmap());
            }

            public static Image PictureToImage(stdole.IPictureDisp picture)
            {
                return GetPictureFromIPicture(picture);
            }

            public static Icon PictureToIcon(stdole.IPictureDisp picture)
            {
                Bitmap bitmap = new Bitmap(PictureToImage(picture));
                return System.Drawing.Icon.FromHandle(bitmap.GetHicon());
            }
        }
    }
}

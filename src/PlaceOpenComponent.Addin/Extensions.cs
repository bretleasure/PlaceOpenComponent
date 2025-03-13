using Inventor;

namespace PlaceOpenComponent
{
    public static class Extensions
    {
        public static List<InvDoc> GetOpenDocuments(this Inventor.Application inventor)
        {
            return inventor.Documents.VisibleDocuments
                .Cast<Document>()
                .Where(doc => doc.DocumentType == DocumentTypeEnum.kAssemblyDocumentObject || doc.DocumentType == DocumentTypeEnum.kPartDocumentObject)
                .Select(doc => new InvDoc(doc.DisplayName, doc.FullFileName, doc.GetThumbnail()))
                .ToList();
        }

        public static Image GetThumbnail(this Document doc)
        {
            try
            {
                var thumbnail = (IPictureDisp)doc.PropertySets[Inventor.InternalNames.PropertySets.Part.SummaryInformation][Inventor.InternalNames.iProperties.Assembly.Thumbnail].Value;
                return ImageConverter.CreateImage(thumbnail);
            }
            catch
            {
                //Assign default image based on part type

                switch (doc.DocumentType)
                {
                    case DocumentTypeEnum.kAssemblyDocumentObject:
                        return ImageConverter.CreateImage("Resources.iam.png");

                    case DocumentTypeEnum.kPartDocumentObject:
                        return ImageConverter.CreateImage("Resources.ipt.png");
                }
            }

            return null;
        }
    }
}

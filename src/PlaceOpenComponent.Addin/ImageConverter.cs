using System.Reflection;
using Inventor;

namespace PlaceOpenComponent
{
	internal class ImageConverter : AxHost
	{
		public ImageConverter() : base(string.Empty)
		{
		}

		public static IPictureDisp BitmapToPicture(Bitmap bitmap)
		{
			return (IPictureDisp)GetIPictureDispFromPicture(bitmap);
		}
		
		public static IPictureDisp CreateIcon(string resourceName)
		{
			var resourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);

			if (resourceStream == null)
				throw new Exception($"Resource {resourceName} not found in assembly {Assembly.GetExecutingAssembly().FullName}");

			var bitmap = new Bitmap(resourceStream);

			return ImageConverter.BitmapToPicture(bitmap);
		}

		public static Image CreateImage(string resourceName)
		{
			return GetPictureFromIPicture(CreateIcon(resourceName));
		}
		
		public static Image CreateImage(IPictureDisp picture)
		{
			return GetPictureFromIPicture(picture);
		}
	}
}
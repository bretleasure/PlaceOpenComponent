using Inventor;
using Inventor.InternalNames.Ribbon;
using Application = Inventor.Application;

namespace PlaceOpenComponent.Buttons
{
	internal class PlaceButton : InventorButton
	{
		protected override void Execute(NameValueMap context, Inventor.Application inventor)
		{
			var form = new PlaceOpenCompUI();
			form.ShowDialog();

			var path = form.SelectedComponentPath;

			if (!string.IsNullOrWhiteSpace(path))
			{
				ApplicationTools.PlaceComponent(path);
			}
		}

		protected override string GetRibbonName() => InventorRibbons.Assembly;

		protected override string GetRibbonTabName() => AssemblyRibbonTabs.Assemble;

		protected override string GetRibbonPanelName() => AssemblyRibbonPanels.AssembleTab.Component;

		internal override void Initialize()
		{ 
			_button = this.RibbonPanel.CommandControls["AssemblyPlaceSplit"].ChildControls.AddButton(Definition, UseLargeIcon, ShowText);
		}

		protected override string GetButtonName() => "Place Open Component";

		protected override string GetDescriptionText() => "Allows you to place a component that is open in Inventor into the current assembly.";

		protected override string GetToolTipText() => "Place an open component into this assembly";

		protected override string GetLargeIconResourceName() => "PlaceOpenComponent.Buttons.Assets.logo.png";

		protected override string GetDarkThemeLargeIconResourceName() => GetLargeIconResourceName();

		protected override string GetSmallIconResourceName() => GetLargeIconResourceName();

		protected override string GetDarkThemeSmallIconResourceName() => GetDarkThemeLargeIconResourceName();
	}
}
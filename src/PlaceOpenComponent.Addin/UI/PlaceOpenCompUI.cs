namespace PlaceOpenComponent.UI
{
    public partial class PlaceOpenCompUI : Form
    {
        private readonly List<InvDoc> _openDocuments;

        public PlaceOpenCompUI(List<InvDoc> openDocuments)
        {
            _openDocuments = openDocuments;
            InitializeComponent();
        }

        private void PlaceComponentUI_Load(object sender, EventArgs e)
        {
            lb_OpenDocs.DataSource = _openDocuments;
            lb_OpenDocs.DisplayMember = "Name";
        }
        
        public string SelectedComponentPath { get; private set; }

        private void btn_Place_Click(object sender, EventArgs e)
        {
            if (lb_OpenDocs.SelectedItem != null)
            {
                if (lb_OpenDocs.SelectedItem is InvDoc invDoc)
                {
                    SelectedComponentPath = invDoc.FilePath;
                }
                this.Close();
            }            
            
        }

        private void lb_OpenDocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_OpenDocs.SelectedItem is InvDoc invDoc)
            {
                pictureBox1.Image = invDoc.Thumbnail;
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAP.Apps.PlaceComponentPlus
{
    public partial class PlaceOpenCompUI : Form
    {
        public PlaceOpenCompUI()
        {
            InitializeComponent();
        }

        List<InvDoc> OpenComps;

        string PlaceCompFilepath;

        private void PlaceComponentUI_Load(object sender, EventArgs e)
        {
            OpenComps = ApplicationTools.GetOpenDocuments();

            PopulateListBox();

        }

        void PopulateListBox()
        {
            foreach (InvDoc item in OpenComps)
            {
                lb_OpenDocs.Items.Add(item.Name);
            }
        }

        private void btn_Place_Click(object sender, EventArgs e)
        {
            if (lb_OpenDocs.SelectedItem != null)
            {
                string compName = lb_OpenDocs.SelectedItem.ToString();

                foreach (InvDoc item in OpenComps)
                {
                    if (item.Name == compName)
                    {
                        AddinGlobal.PlaceCompFilePath = item.Filepath;
                        this.Close();
                        break;
                    }
                }
            }
            
            
        }
    }
}

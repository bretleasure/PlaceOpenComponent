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
                //Panel oPanel = new Panel();
                //oPanel.AutoSize = true;

                //PictureBox oPB = new PictureBox();
                //oPB.Image = item.Thumbnail;
                //oPB.Size = new Size(150, 150);
                //oPB.SizeMode = PictureBoxSizeMode.Zoom;

                //Label oLbl = new Label();
                //oLbl.Text = item.Name;

                //oPanel.Controls.Add(oPB);
                //oPanel.Controls.Add(oLbl);

                //lb_OpenDocs.Items.Add(oPanel);

                lb_OpenDocs.Items.Add(item.Name);

            }
        }

        private void btn_Place_Click(object sender, EventArgs e)
        {
            if (lb_OpenDocs.SelectedItem != null)
            {
                AddinGlobal.PlaceCompFilePath = GetComponentByName(lb_OpenDocs.SelectedItem.ToString()).Filepath;

                this.Close();
                                
            }            
            
        }


        public InvDoc GetComponentByName(string compName)
        {
            InvDoc doc = null;

            foreach (InvDoc item in OpenComps)
            {
                if (item.Name == compName)
                {
                    doc = item;
                }
            }

            return doc;
        }

        private void lb_OpenDocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = GetComponentByName(lb_OpenDocs.SelectedItem.ToString()).Thumbnail;
        }
    }
}

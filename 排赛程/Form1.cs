#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace 排赛程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Create_Click(object sender, EventArgs e)
        {
            label4.Visible = true;
#if(!DEBUG)
            try
            {
#endif
                List<List<string>> groups = Arrange.arrangeGroup(Arrange.seed, Arrange.notSeed, Convert.ToInt32(GroupNumber.Text));
                SaveFileDialog groupPath = new SaveFileDialog();
                groupPath.RestoreDirectory = true;
                groupPath.Title = "保存分组表文件到";
                groupPath.FileName = "group.xls";
                groupPath.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                if (groupPath.ShowDialog() == DialogResult.OK)
                {
                    //File.WriteAllText(groupPath.FileName, Arrange.outputGroup(groups));
                    Arrange.writeGroupExcel(groupPath.FileName, groups);
                    SaveFileDialog versusPath = new SaveFileDialog();
                    versusPath.RestoreDirectory = true;
                    versusPath.Title = "保存对阵表文件到";
                    versusPath.FileName = "versus.xls";
                    versusPath.Filter = "xls files (*.xls)|*.xls|All files (*.*)|*.*";
                    if (versusPath.ShowDialog() == DialogResult.OK)
                    {
                        Arrange.writeVersusExcel(versusPath.FileName, groups);
                        label4.Text = "赛程和对阵已在当前目录生成。";
                    }
                    else
                    {
                        label4.Text = "只保存了分组文件，没用……";
                    }
                }
                else
                {
                    label4.Text = "";
                }
#if(!DEBUG)
            }
            catch (Exception ex)
            {
                label4.Text = "错误，是名单问题吗？" + ex.Message + " 百度一下该代码。";
            }
#endif
        }

        private void GroupNumber_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GroupNumber.Text = "8";
            Arrange.notSeed = new List<string>();
            Arrange.seed = new List<string>();
        }

        private void NotSeed_TextChanged(object sender, EventArgs e)
        {
            Arrange.notSeed = Arrange.readName(NotSeed.Text);
            notSeedNum.Text = "共 " + Arrange.notSeed.Count + " 人/队";
        }

        private void Seed_TextChanged(object sender, EventArgs e)
        {
            Arrange.seed = Arrange.readName(Seed.Text);
            seedNum.Text = "共 " + Arrange.seed.Count + " 人/队";
        }
    }
}

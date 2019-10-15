using System.Windows.Forms;
using MVC.DataAccess;
using MVC.View;

namespace MVC.Winform
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.InitializeComponent();
            DataContainer.InitializationData();

            ComboBox comboBox = this.toolStripComboBox.ComboBox;

            if (comboBox == null)
            {
                return;
            }

            ConcreteDataGridViewRequest concreteDataGridViewRequest = new ConcreteDataGridViewRequest(this.dataGridView);
            ConcreteTreeviewRequest concreteTreeviewRequest = new ConcreteTreeviewRequest(this.treeView);
            ConcreteComboxRequest comboxRequest = new ConcreteComboxRequest(comboBox);
            comboxRequest.Update("");
        }
    }
}
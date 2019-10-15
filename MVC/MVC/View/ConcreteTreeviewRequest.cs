using System.Collections.Generic;
using System.Windows.Forms;
using MVC.DataAccess;

namespace MVC.View
{
    public class ConcreteTreeviewRequest : BaseRequest, IDataObserver
    {
        private readonly TreeView _treeView;

        public ConcreteTreeviewRequest(TreeView treeView)
        {
            this._treeView = treeView;
            this.IntializeView();
        }

        public List<string> ObserverKeys { get; set; } = new List<string> { $"{nameof(ConcreteComboxRequest)}" };

        public string SubscriptionKey { get; set; } = $"{nameof(ConcreteTreeviewRequest)}";

        public void Update(object data)
        {
            BaseObject baseObject = (BaseObject)data;
            this.InitializeTreeView(baseObject);
        }

        private void IntializeView()
        {
            foreach (string observerKey in this.ObserverKeys)
            {
                ConcreteModel.RegisterObserver(this, observerKey);
            }

            this._treeView.AfterSelect += this.treeView_SelectedValue;
        }

        private void InitializeTreeView(BaseObject baseObject)
        {
            this._treeView.Nodes.Clear();
            List<Grade> grades = Grade.GetList(baseObject);

            foreach (Grade item in grades)
            {
                this.CreateTreeNode(null, item);
            }
        }

        private void treeView_SelectedValue(object sender, TreeViewEventArgs e)
        {
            TreeNode currentNode = this._treeView.SelectedNode;

            BaseObject baseObject = (BaseObject)currentNode.Tag;

            ConcreteController.GetDatas(baseObject, this.SubscriptionKey);
        }

        private TreeNode CreateTreeNode(TreeNode parentNode, BaseObject concreteData)
        {
            TreeNode treeNode = new TreeNode
            {
                Tag = concreteData,
                Name = concreteData.Id,
                Text = concreteData.Name
            };

            if (parentNode == null)
            {
                this._treeView.Nodes.Add(treeNode);
            }
            else
            {
                parentNode.Nodes.Add(treeNode);
            }

            return treeNode;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MVC.DataAccess;

namespace MVC.View
{
    public class ConcreteDataGridViewRequest : BaseRequest, IDataObserver
    {
        private readonly DataGridView _dataGridView;

        public ConcreteDataGridViewRequest(DataGridView dataGridView)
        {
            this._dataGridView = dataGridView;
            this.IntializeView();
        }

        public List<string> ObserverKeys { get; set; } = new List<string>
        {
            $"{nameof(ConcreteTreeviewRequest)}",
            $"{nameof(ConcreteComboxRequest)}"
        };

        public string SubscriptionKey { get; set; } = $"{nameof(ConcreteDataGridViewRequest)}";

        public void Update(object data)
        {
            BaseObject baseObject = (BaseObject)data;
            this.InitializeDataGridView(baseObject);
        }

        private void InitializeDataGridView(BaseObject baseObject)
        {
            this._dataGridView.Columns.Clear();
            List<Student> students = Student.GetList(baseObject);

            this._dataGridView.DataSource = students;
        }

        private void IntializeView()
        {
            foreach (string observerKey in this.ObserverKeys)
            {
                ConcreteModel.RegisterObserver(this, observerKey);
            }

            this._dataGridView.SelectionChanged += this.dataGridView_SelectionChanged;
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // Do some business logic
        }
    }
}
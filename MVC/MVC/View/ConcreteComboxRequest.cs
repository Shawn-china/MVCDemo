using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MVC.DataAccess;

namespace MVC.View
{
    public class ConcreteComboxRequest : BaseRequest, IDataObserver
    {
        private readonly ComboBox _comboBox;

        public ConcreteComboxRequest(ComboBox comboBox)
        {
            this._comboBox = comboBox;
            this.IntializeView();
        }

        public List<string> ObserverKeys { get; set; }

        public string SubscriptionKey { get; set; } = $"{nameof(ConcreteComboxRequest)}";

        public void Update(object data)
        {
            this._comboBox.DataSource = DataContainer.Schools;
        }

        private void IntializeView()
        {
            this._comboBox.DisplayMember = "Name";
            this._comboBox.ValueMember = "Id";
            this._comboBox.SelectedIndexChanged += this.cmb_SelectedValueChanged;
        }

        private void cmb_SelectedValueChanged(object sender, EventArgs e)
        {
            BaseObject baseObject = (BaseObject)this._comboBox.SelectedItem;
            ConcreteController.GetDatas(baseObject, this.SubscriptionKey);
        }
    }
}
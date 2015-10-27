using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Datapel.BreezeAPI.SDK;
using Datapel.BreezeAPI.SDK.Service;
using Datapel.BreezeAPI.SDK.Contract;
using System.Reflection;
using System.Xml;

namespace Datapel.BreezeAPI.Sample
{
    public partial class frmMain : Form
    {
        BreezeAPI.SDK.Client.AuthorisationState authoriseState;
        public frmMain()
        {
            InitializeComponent();
#if ! DEBUG
            tabCtrl.TabPages.Remove(tabDevTest); 
#endif      
        }

        private void btnGetToken_Click(object sender, EventArgs e)
        {
            var authoriser = new Datapel.BreezeAPI.SDK.Client.APIAuthorizer(txtServerUrl.Text);
            authoriseState = authoriser.AuthorizeClient(txtUser.Text, txtPwd.Text);
            authoriseState.BreezeAPIPath = txtServerUrl.Text; 
            txtBase64Auth.Text = authoriseState.AuthorisationCode;
            txtToken.Text = authoriseState.Auth_Token;
            chkIsAuthorised.Checked = authoriseState.isAuthorised;
            txtErrorMsg.Text = authoriseState.ErrorMsg; 
        }

        private void btnReq_Click(object sender, EventArgs e)
        {
            if (authoriseState == null || !authoriseState.isAuthorised)
                return; 
            var client = new Datapel.BreezeAPI.SDK.Client.APIClient(authoriseState);
            client.SetServerUrl(authoriseState.BreezeAPIPath);
            var tempStr = txtEndpoint.Text + "?" + txtQuery.Text; 
            var result = client.Get(tempStr);
            txtResult.Text = result.ToString();
        }

        private void btnRequest2_Click(object sender, EventArgs e)
        {
            if (authoriseState == null || !authoriseState.isAuthorised)
                return;

            switch(txtEndpoint2.Text.ToLower()){
                case "items":
                    GetItem();
                    break;
                case "inventorylist":
                    GetInventoryList();
                    break;
                case "inventory":
                    GetInventory();
                    break;
                case "contactlist":
                    GetContactList();
                    break;
                case "contact":
                    GetContact();
                    break;
                case "addresslist":
                    GetAddressList();
                    break;
                case "pricelist":
                    GetPriceList();
                    break;
                case "salelist":
                    GetSaleList();
                    break;
                case "sales":
                    GetSale();
                    break;
                case "locations":
                    GetLocation();
                    break;

            }
        }
        #region Service Get Method
        private void GetItem ()
        {
            var service = new ItemService();
            AuthorisedService(service);  
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetList(txtQuery2.Text, pageSkip, pagesize);
        }
        private void GetInventoryList()
        {
            var service = new InventoryListService();
            AuthorisedService(service); 
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            var inList = service.GetListByLocationId(txtID.Text);
            dgvReturn.DataSource = inList.inventorylist; 
            //dgvReturn.DataSource = service.GetList(txtQuery2.Text, pageSkip, pagesize);
        }
        private void GetInventory()
        {
            var service = new InventoryService();
            AuthorisedService(service); 
            dgvReturn.DataSource = service.GetInventoryById(txtID.Text);
        }
        private void GetContactList()
        {
            var service = new ContactListService();
            AuthorisedService(service); 
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetList(txtQuery2.Text, pageSkip, pagesize);
        }
        private void GetContact()
        {
            var service = new ContactService();
            AuthorisedService(service);        
            dgvReturn.DataSource = service.GetContactById(txtID.Text);
        }
        private void GetAddressList()
        {
            var service = new AddressListService();
            AuthorisedService(service); 
            dgvReturn.DataSource = service.GetAddressById(txtID.Text);
        }
        private void GetPriceList()
        {
            var service = new PriceListService();
            AuthorisedService(service); 
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetPriceList(txtID.Text, txtId2.Text); 
        }
        private void GetSaleList()
        {
            var service = new SaleListService();
            AuthorisedService(service); 
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetSaleListByMYOBCardId(txtID.Text); 
        }
        private void GetSale()
        {
            var service = new SaleService();
            AuthorisedService(service); 
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetSaleBySaleId(txtID.Text);
        }
        private void GetLocation()
        {
            var service = new LocationService();
            AuthorisedService(service); 
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;
            dgvReturn.DataSource = service.GetLocationByName(txtID.Text);
        }
        
        private void AuthorisedService(BreezeServiceBase service)
        {
            service.ServerUrl = txtServerUrl.Text;
            service.Authorised(txtUser.Text, txtPwd.Text);
        }
        

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region Get an item for update 
            var service = new ItemService();
            var item = Get(service, txtSaveQuery.Text).FirstOrDefault();
            if (item != null)
            {
                setProperty(item, txtSaveField.Text, txtSaveValue.Text); 
            }
            #endregion
        
            if(service.Update(txtSaveQuery.Text, item))
            {
                var newitem = Get(service, txtSaveQuery.Text).FirstOrDefault();
            }
        }

        private IList <Item> Get (ItemService service,  string query)
        {
            int pagesize = Convert.ToInt16(txtPageSize.Text);
            int pageSkip = Convert.ToInt16(txtPage.Text) * pagesize;

            AuthorisedService(service); 
            var itemList = service.GetList(query, pageSkip, pagesize);
            return itemList; 
        }

        private void setProperty(object obj, string propName, string strValue)
        {
            PropertyInfo prop = obj.GetType().GetProperty(propName, BindingFlags.Public|BindingFlags.Instance);
            if (null != prop && prop.CanWrite)
            {
                prop.SetValue(obj, strValue, null);
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            #region Get an item for update
            var service = new ItemService();
            var item = Get(service, txtSaveQuery.Text).FirstOrDefault();
            if (item != null)
            {
                setProperty(item, txtSaveField.Text, txtSaveValue.Text);
                item.basestockid = 0; 
            }
            #endregion

            if (service.Insert(txtSaveQuery.Text, item))
            {
                var newitem = Get(service, txtSaveQuery.Text).FirstOrDefault();
            }
        }

        private void txtSaveQuery_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(txtRunInput.Text);
            var nodeList = xmlDoc.SelectNodes("/SalesQueueXml/salesQueue/SalesQueue");

            foreach (XmlNode xn in nodeList)
            {
                string outData = "<NewDataSet>" + xn["data"].InnerXml + "</NewDataSet>";
                txtRunOutput.Text += xn["nameOfFile"].InnerText + "\n\r" + outData + "\n\r\n\r"; 
            }
        }
    }
}

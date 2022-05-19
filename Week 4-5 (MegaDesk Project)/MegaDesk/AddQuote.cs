using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk2
{
    public partial class AddQuote : Form
    {
        public AddQuote()
        {
            InitializeComponent();
/*
            List<DesktopMaterial> materials = Enum.GetValues(typeof(DesktopMaterial)).Cast<DesktopMaterial>().ToList();
            List<Delivery> delivery = Enum.GetValues(typeof(Delivery)).Cast<Delivery>().ToList();

            comboMaterial.DataSource = materials;
*/
        }
        private void AddQuote_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((Form)this.Tag).Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var desk = new Desk();

            desk.Width = (int)numWidth.Value;
            desk.Depth = (int)numDepth.Value;
            desk.NumberOfDrawers = (int)numberOfDrawers.Value;
            desk.DesktopMaterial = (DesktopMaterial)comboMaterial.SelectedIndex;
        
            var deskQuote = new DeskQuote
            {
                desk = desk,
                CustomerName = textCustomerName.Text,
                QuoteDate = DateTime.Now,
                DeliveryType = (Delivery)comboDelivery.SelectedIndex

            };

            var price = deskQuote.GetQuotePrice();

            WriteQuote(deskQuote);

            this.Close();
        }

        private void WriteQuote(DeskQuote deskQuote) 
        {
            string filePath = @"quotes.json";
            List<DeskQuote> deskQuotes = new List<DeskQuote>();

            if (File.Exists(filePath))
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string quotes = reader.ReadToEnd();
                    deskQuotes = System.Text.Json.JsonSerializer.Deserialize<List<DeskQuote>>(quotes);
                }

            deskQuotes.Add(deskQuote);

            SaveQuoteList(deskQuotes);
        }

        private void SaveQuoteList(List<DeskQuote> quoteList)
        {
            string filePath = @"quotes.json";

            var quotesToJSON = System.Text.Json.JsonSerializer.Serialize(quoteList);

            File.WriteAllText(filePath, quotesToJSON);
        }
    }
}

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
    public partial class SearchQuotes : Form
    {
        Form _mainMenu;
        public SearchQuotes(Form mainMenu)
        {
            InitializeComponent();

            _mainMenu = mainMenu;
            loadGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();
        }

        private void loadGrid()
        {
            var quotesFile = @"quotes.json";

            if (File.Exists(quotesFile))
            {
                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    //Load current quotes
                    string quotes = reader.ReadToEnd();

                    List<DeskQuote> deskQuotes = JsonSerializer.Deserialize<List<DeskQuote>>(quotes);


                    dataGridView1.DataSource = deskQuotes.Select(d => new
                    {
                        Date = d.QuoteDate,
                        Customer = d.CustomerName,
                        Depth = d.desk.Depth,
                        Width = d.desk.Width,
                        Drawers = d.desk.NumberOfDrawers,
                        SurfaceMaterial = d.desk.DesktopMaterial,
                        DeliveryType = d.DeliveryType,
                        QuoteAmount = d.GetQuotePrice().ToString("c")
                    }
                        )
                        .ToList();
                }
            }
        }


        private void loadGrid(DesktopMaterial desktopMaterial)
        {
            var quotesFile = @"quotes.json";

            if (File.Exists(quotesFile))
            {
                using (StreamReader reader = new StreamReader(quotesFile))
                {
                    //Load current quotes
                    string quotes = reader.ReadToEnd();

                    List<DeskQuote> deskQuotes = JsonSerializer.Deserialize<List<DeskQuote>>(quotes);


                    dataGridView1.DataSource = deskQuotes.Select(d => new
                    {
                        Date = d.QuoteDate,
                        Customer = d.CustomerName,
                        Depth = d.desk.Depth,
                        Width = d.desk.Width,
                        Drawers = d.desk.NumberOfDrawers,
                        SurfaceMaterial = d.desk.DesktopMaterial,
                        DeliveryType = d.DeliveryType,
                        QuoteAmount = d.GetQuotePrice().ToString("c")
                    })
                        .Where(q => q.SurfaceMaterial == desktopMaterial)
                        .ToList();
                }
            }
        }

        private void comboSurfaceMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadGrid((DesktopMaterial)comboSurfaceMaterial.SelectedIndex);
        }
    }
}

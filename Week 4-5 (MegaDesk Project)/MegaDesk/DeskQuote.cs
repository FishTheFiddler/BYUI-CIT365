using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MegaDesk2
{
    public enum Delivery
    {
        Rush3Days,
        Rush5Days,
        Rush7Days,
        None
    }

    internal class DeskQuote
    {

        // constants

        private const decimal BASE_PRICE = 200M;
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_PRICE = 50M;
        private const decimal OAK_COST = 200.00M;
        private const decimal LAMINATE_COST = 100.00M;
        private const decimal PINE_COST = 50.00M;
        private const decimal ROSEWOOD_COST = 300.00M;
        private const decimal VENEER_COST = 125.00M;
        private int[,] _rushOrderPrices;

        public string CustomerName { get; set; }

        public DateTime QuoteDate { get; set; }

        public Delivery DeliveryType { get; set; }

        public Desk desk { get; set; }

        public decimal GetQuotePrice()
        {


            decimal price = BASE_PRICE;

            decimal deskArea = desk.Width * desk.Depth;

            // Surface area
            if (deskArea > 1000)
            {
                price = price + (deskArea - 1000) * SURFACE_AREA_COST;
            }

            // Drawers
            price = price + desk.NumberOfDrawers * DRAWER_PRICE;


            switch (desk.DesktopMaterial)
            {
                case DesktopMaterial.Oak:
                    price = price + OAK_COST;
                    break;
                case DesktopMaterial.Laminate:
                    price = price + LAMINATE_COST;
                    break;
                case DesktopMaterial.Pine:
                    price = price + PINE_COST;
                    break;
                case DesktopMaterial.Veneer:
                    price = price + VENEER_COST;
                    break;
                case DesktopMaterial.Rosewood:
                    price = price + ROSEWOOD_COST;
                    break;
            }

            getRushOrderPrices();

            switch(DeliveryType)
            {
                case Delivery.Rush3Days:
                    if (deskArea < 1000)
                    {
                        price = price + _rushOrderPrices[0, 0];
                    }
                    else if (deskArea <= 2000)
                    {
                        price = price + _rushOrderPrices[0, 1];
                    }
                    else
                    {
                        price = price + _rushOrderPrices[0, 2];
                    }
                    break;
                case Delivery.Rush5Days:
                    if (deskArea < 1000)
                    {
                        price = price + (int) _rushOrderPrices[1, 0];
                    }
                    else if (deskArea <= 2000)
                    {
                        price = price + _rushOrderPrices[1, 1];
                    }
                    else
                    {
                        price = price + _rushOrderPrices[1, 2];
                    }
                    break;
                case Delivery.Rush7Days:
                    if (deskArea < 1000)
                    {
                        price = price + _rushOrderPrices[2, 0];
                    }
                    else if (deskArea <= 2000)
                    {
                        price = price + _rushOrderPrices[2, 1];
                    }
                    else
                    {
                        price = price + _rushOrderPrices[2, 2];
                    }
                    break;
                case Delivery.None:
                    break;
            }



            // Save info at 18:40 if we get stuck 5/12 session recording

            return price;
        }


        private void getRushOrderPrices()
        {
            _rushOrderPrices = new int[3, 3];

            var pricesFile = @"rushOrderPrices.txt";

            try
            {
                string[] prices = File.ReadAllLines(pricesFile);
                int i = 0, j = 0;

                foreach (string price in prices)
                {
                    _rushOrderPrices[i, j] = int.Parse(price);

                    if (j == 2)
                    {
                        i++;
                        j = 0;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

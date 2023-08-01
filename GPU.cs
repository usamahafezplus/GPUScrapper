using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPU_Price_Scanner
{
    class GPU
    {
        private string brand;
        private string chipset;
        private string model;
        private string VRAM;
        private string series;
        private double price;
        public GPU(string brand, string chipset, string model, string VRAM, string series, double price)
        {
            this.brand = brand;
            this.chipset = chipset;
            this.model = model;
            this.VRAM = VRAM;
            this.series = series;
            this.price = price;
        }
        public void setBrand(string brand)
        {
            this.brand = brand;
        }
        public void setChipset(string chipset)
        {
            this.chipset = chipset;
        }

        public void setModel(string model)
        {
            this.brand = model;
        }
        public void setVRAM(string VRAM)
        {
            this.VRAM = VRAM;
        }
        public void setSeries(string series)
        {
            this.brand = series;
        }
        public void setPrice(double price)
        {
            this.price = price;
        }
        public string getBrand()
        {
            return this.brand;
        }
        public string getChipset()
        {
            return this.chipset;
        }
        public string getModel()
        {
            return this.model;
        }
        public string getVRAM()
        {
            return this.VRAM;
        }
        public string getSeries()
        {
            return this.series;
        }
        public double getPrice()
        {
            return this.price;
        }


    }
}

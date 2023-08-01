using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPU_Price_Scanner
{
    class Page
    {
        private string url;
        private string filter_1;
        private string filter_2;
        private string filter_3;

        public Page(string url, string filter_1, string filter_2, string filter_3)
        {
            this.url = url;
            this.filter_1 = filter_1;
            this.filter_2 = filter_2;
            this.filter_3 = filter_3;
        }
        public void setUrl(string url)
        {
            this.url = url;
        }
        public void setFilter_1(string filter_1)
        {
            this.filter_1 = filter_1;
        }
        public void setFilter_2(string filter_2)
        {
            this.filter_2 = filter_2;
        }
        public void setFilter_3(string filter_3)
        {
            this.filter_3 = filter_3;
        }
        public string getUrl()
        {
            return this.url;
        }
        public string getFilter_1()
        {
            return this.filter_1;
        }
        public string getFilter_2()
        {
            return this.filter_2;
        }
        public string getFilter_3()
        {
            return this.filter_3;
        }
    }
}

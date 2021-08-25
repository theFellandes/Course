using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace EntityFrameworkDemo1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
       
        private void Form1_Load(object sender, EventArgs e)
        {
            //using şu anlama geliyor, ETradeContext bellek için pahalı bir nesne, çok yer kaplıyor.
            //bu tip nesnelerde IUsable interface'inden implement edilen bir nesne sağlar. Method bitince
            //işi biten methodları atıyor. Using olduğunda nesneyi zorla bellekten atıp Dispose ediyoruz.
            using (ETradeContext context = new ETradeContext())
            {
                dgwProducts.DataSource = context.Products.ToList();
            }
        }
    }
}
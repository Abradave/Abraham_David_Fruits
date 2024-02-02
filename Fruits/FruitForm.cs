using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fruits
{
    public partial class FruitForm : Form
    {
        string todo;
        public FruitForm(string todo, Object param = null)
        {
            InitializeComponent();
            this.todo = todo;
            switch (todo) 
            {
                case "new":
                    btnSubmit.Text = "New Fruit";
                    this.Text = "New Fruit";
                    break;
                case "update":
                    btnSubmit.Text = "Update Fruit";
                    this.Text = "Update Fruit";
                    Fruit fruit = (Fruit)param;
                    tbId.Text = fruit.Id.ToString();
                    tbName.Text = fruit.Name.ToString();
                    numQuantity.Value = fruit.Quantity;
                    break;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            switch (todo)
            {
                case "new":
                    newFruit();
                    break;
                case "update":
                    Update();
                    break;
            }
        }

        private void newFruit()
        {
            ulong id = (ulong)(Program.indexForm.lbFruits.Items.Count + 1);
            if (String.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Missing Name");
                tbName.Focus();
                return;
            }
            string name = tbName.Text;
            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Not a valid quantity.");
                return;
            }
            Fruit newFruit = new Fruit(id, name, (int)numQuantity.Value);
            Program.indexForm.lbFruits.Items.Add(newFruit);
            this.Close();
        }

        private void Update()
        {
            ulong id = ulong.Parse(tbId.Text);
            if (String.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Missing Name");
                tbName.Focus();
                return;
            }
            string name = tbName.Text;
            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Not a valid quantity.");
                return;
            }
            Fruit fruit = new Fruit(id, name, (int)numQuantity.Value);
     
            Program.indexForm.lbFruits.Items.Add(fruit);
            this.Close();
        }
    }
}

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

namespace Fruits
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FruitForm fruitForm = new FruitForm("new");
            fruitForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lbFruits.SelectedIndex < 0)
            {
                MessageBox.Show("Pick an Item Please");
                return;
            }
            Fruit fruit = (Fruit)lbFruits.SelectedItem;
            lbFruits.Items.Remove(fruit);
            FruitForm fruitForm = new FruitForm("update", fruit);
            fruitForm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbFruits.SelectedIndex < 0)
            {
                MessageBox.Show("Choose An Item!");
                return;
            }
            Fruit fruit = (Fruit)lbFruits.SelectedItem;
            lbFruits.Items.Remove(fruit);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            save.FilterIndex = 1;
            save.RestoreDirectory = true;
            save.InitialDirectory = Environment.CurrentDirectory;

            if (save.ShowDialog() == DialogResult.OK)
            {
                string fileName = save.FileName;
                using (StreamWriter myStream = new StreamWriter(fileName)) 
                {
                    foreach (Fruit item in lbFruits.Items)
                    {
                        myStream.Write(item.Totxt());
                    }
                    myStream.Flush();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            open.FilterIndex = 1;
            open.RestoreDirectory = true;
            open.InitialDirectory = Environment.CurrentDirectory;

            if (open.ShowDialog() == DialogResult.OK)
            {
                string dataFile = open.FileName;
                using (StreamReader sr = new StreamReader(dataFile))
                { 
                    while (!sr.EndOfStream) 
                    {
                        string[] line = sr.ReadLine().Split(';');
                        Fruit newFruit = new Fruit(ulong.Parse(line[0]), line[1], int.Parse(line[2]));
                        lbFruits.Items.Add(newFruit);
                    }
                }
            }
        }
    }
}

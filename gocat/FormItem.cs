using BAL;
using BEL;
using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gocat
{
    public partial class FormAgama : MetroForm
    {
        Item item = new Item();
        OPItem opAgama = new OPItem();

        public FormAgama() //Iki Mlaku pas proses Instansiasi
        {
            InitializeComponent();//Iki gawanan :D
            loadDataItem(); //Nampilne method sing nok isor kui
        }

        public void loadDataItem()//Iki method e gawe dewe , digae load data agama
        {
            DataTable dt = new DataTable();
            dt = opAgama.viewItem(item);// Nyeluk Method Agama , parametere objek agama
            metroGrid1.DataSource = dt; //Ngelbokne datane nang gridview
        }

        private void FormAgama_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

           
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            item.Name = metroTextBox1.Text;
            item.Desc = metroTextBox2.Text;

            int baris = opAgama.insertItem(item); //Method e diceluk , parametere objek e 

            if (baris > 0)
            {
                MetroMessageBox.Show(this, "Alert", "Tambah Data Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                loadDataItem(); // load data grid e , ben iso ngapdet table e langsung
            }
            else
            {
                MetroMessageBox.Show(this, "Alert", "Data gagal Disimpan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = "";
            metroTextBox2.Text = "";
            label2.Text = "ID";
        }

        private void metroGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            label2.Text = metroGrid1.SelectedRows[0].Cells[0].Value.ToString(); //Value tekan data grid index 0 di diuncalne nang label1
            metroTextBox1.Text = metroGrid1.SelectedRows[0].Cells[1].Value.ToString(); //Value tekan data grid index 1 di diuncalne nang txtbox1
            metroTextBox2.Text = metroGrid1.SelectedRows[0].Cells[2].Value.ToString();
            
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            item.Id = Int32.Parse(label2.Text); //Iki gae njumuk ID ne
            item.Name = metroTextBox1.Text;
            item.Desc = metroTextBox2.Text; //Iki sing ate diinputne jal
            opAgama.updateItem(item);
            loadDataItem();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            item.Id = Int32.Parse(label2.Text); //Iki gae njumuk ID ne
            opAgama.deleteItem(item);
            loadDataItem();
        }
    }
}

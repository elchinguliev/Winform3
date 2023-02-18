using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace Winform3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name=textBox1.Text,
                Surname=textBox2.Text,
            };
            var json = JsonSerializer.Serialize(user);
            File.WriteAllText($"{user.Name}.json  ", json);
    }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
     
                var json = File.ReadAllText($"{textBox3.Text}.json");
                var obj = JsonSerializer.Deserialize<User>(json);
                textBox1.Text=obj?.Name;
                textBox2.Text=obj?.Surname;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
       
        }
    }
}

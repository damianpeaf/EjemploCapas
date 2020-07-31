﻿using Dominio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class Mostrar : Form
    {
        public Mostrar()
        {
            InitializeComponent();
            mostrarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        void mostrarDatos()
        {

            try
            {
                DomioUsuario usuario = new DomioUsuario();
                dataGridView1.DataSource = usuario.mostrar().Tables[0];
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(""+ ex);
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }
    }
}

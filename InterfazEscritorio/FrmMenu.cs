using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfazEscritorio
{
    public partial class FrmMenu : Form
    {
        
        public FrmMenu()
        {
            InitializeComponent();           
        }
        
        private void btnSlide1_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 227)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 227;
            }
        }

        private void AbrirFormInPanel(object FormHijo)
        {
            // Se pregunta si existe un panel,si hay se elima
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = FormHijo as Form; //Se crea un formulario con el que le llega
            fh.TopLevel = false; // Con esto se dice que es un formulario secundario
            fh.Dock = DockStyle.Fill; // Se aclopa en todo el panel
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnPrograma_Click(object sender, EventArgs e)
        {
            //Se envia en los parámetros el formulario que se quiere abrir
            AbrirFormInPanel(new FrmProgramas());
            lbBievenida.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmModulo());
        }

        private void btnModAbiertos_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmModulosAbie());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmHorarMod());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmEntrenador());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmHorarEntrenador());

            //tituloForms.Text = "Horario de Entrenadores";
        }
        //public string TituloForms
        //{
        //    get
        //    {
        //        return this.tituloForms.Text;
        //    }
        //    set
        //    {
        //        this.tituloForms.Text = value;
        //    }
        //}

        private void button7_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmCertificacion());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmIncapEventos());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmReg_Horas_labo());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmAtleta());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AbrirFormInPanel(new FrmMatricula());
        }
    }
}

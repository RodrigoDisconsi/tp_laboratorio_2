using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TP1
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
            cmbOperador.Text = cmbOperador.Items[2].ToString();
        }

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "";
            cmbOperador.Text = "";
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1),new Numero(numero2) , operador);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            double resultado;
            double.TryParse(lblResultado.Text, out resultado);
            string aux = Numero.DecimalBinario(Math.Abs(resultado).ToString());
            if (aux == "Valor inválido")
            {
                MessageBox.Show(aux);
            }
            else
            {
                lblResultado.Text = aux;
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }
        }

        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            double binario;
            double.TryParse(lblResultado.Text, out binario);
            string aux = Numero.BinarioDecimal(Math.Abs(binario).ToString());
            if (aux == "Valor inválido")
            {
                MessageBox.Show(aux);
            }
            else
            {
                lblResultado.Text = aux;
                btnConvertirADecimal.Enabled = false;
                btnConvertirABinario.Enabled = true;
            }
        }
    }
}

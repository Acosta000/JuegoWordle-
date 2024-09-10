using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace Juego
{
    public partial class Form1 : Form
    {
        private string[] palabras;
        private Random random;
        private string palabra;
        int i = 0;

        public Form1()
        {
            InitializeComponent();
            CargarPalabras();
            random = new Random(); // Inicializar la instancia de Random
            SeleccionarPalabra();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void SeleccionarPalabra()
        {
            int min = 0;
            int max = 785;
            int numeroAleatorio = random.Next(min, max + 1); // Genera un número entre min y max (incluyendo max)
            palabra = palabras[numeroAleatorio];

        }
        private void CargarPalabras()
        {
            try
            {
                // Ruta del archivo dentro del directorio de salida
                string archivoRuta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "palabras.txt");

                // Leer todas las líneas del archivo
                palabras = File.ReadAllLines(archivoRuta);

                // Ejemplo de cómo mostrar las primeras 10 palabras
                string mensaje = "Palabras cargadas con exito";
                MessageBox.Show(mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el archivo: " + ex.Message);
            }
        }

        private void chequearCaracter(TextBox z, int i)
        {
            char caracter = z.Text[0];
            if (caracter == palabra[i])
            {
                z.BackColor = Color.Green;
            }
            else if (palabra.Contains(z.Text[0]))
            {
                z.BackColor = Color.Yellow;
            }

            z.Enabled = false;
        }

        private void chequearPalabra(TextBox a, TextBox b, TextBox c, TextBox d, TextBox e)
        {
            if(a.Text !="" && b.Text != "" && c.Text != "" && d.Text != "" && e.Text != "")
            {
                chequearCaracter(a, 0);
                chequearCaracter(b, 1);
                chequearCaracter(c, 2);
                chequearCaracter(d, 3);
                chequearCaracter(e, 4);
                i = i + 1;
            }

        }

        private void habilitar(TextBox a, TextBox b, TextBox c, TextBox d, TextBox e)
        {
            a.Enabled = true;
            b.Enabled = true;
            c.Enabled = true;
            d.Enabled = true;
            e.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                chequearPalabra(Txt1x1, Txt1x2, Txt1x3, Txt1x4, Txt1x5);
                habilitar(Txt2x1, Txt2x2, Txt2x3, Txt2x4, Txt2x5);
            }
            else if (i == 1)
            {
                chequearPalabra(Txt2x1, Txt2x2, Txt2x3, Txt2x4, Txt2x5);
                habilitar(Txt3x1, Txt3x2, Txt3x3, Txt3x4, Txt3x5);
            }
            else if (i == 2)
            {
                chequearPalabra(Txt3x1, Txt3x2, Txt3x3, Txt3x4, Txt3x5);
                habilitar(Txt4x1, Txt4x2, Txt4x3, Txt4x4, Txt4x5);
            }
            else if (i == 3)
            {
                chequearPalabra(Txt4x1, Txt4x2, Txt4x3, Txt4x4, Txt4x5);
                habilitar(Txt5x1, Txt5x2, Txt5x3, Txt5x4, Txt5x5);
            }
            else if (i == 4)
            {
                chequearPalabra(Txt5x1, Txt5x2, Txt5x3, Txt5x4, Txt5x5);
                habilitar(Txt6x1, Txt6x2, Txt6x3, Txt6x4, Txt6x5);
            }
            else if (i == 5)
            {
                chequearPalabra(Txt6x1, Txt6x2, Txt6x3, Txt6x4, Txt6x5);
            }
            else if (i == 7)
            {
                Application.Restart();
            }
            else
            {
                MessageBox.Show("GAME OVER\nLa palabra era: " + palabra);
                button1.Text = "REINTENTAR";
                i = i + 1;
            }
        }
    }
}
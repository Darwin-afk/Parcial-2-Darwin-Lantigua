using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Parcial2_Darwin_Lantigua.Entidades;
using Parcial2_Darwin_Lantigua.BLL;

namespace Parcial2_Darwin_Lantigua.UI.Registros
{
    /// <summary>
    /// Interaction logic for rParcial.xaml
    /// </summary>
    public partial class rParcial : Window
    {
        Contenedor contenedor = new Contenedor();
        public rParcial()
        {
            InitializeComponent();
            this.DataContext = contenedor;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (contenedor.llamada.LlamadaId == 0)
                paso = LlamadasBLL.Guardar(contenedor.llamada);
            else
            {
                if (existeEnLaBaseDeDatos())
                    paso = LlamadasBLL.Modificar(contenedor.llamada);
                else
                {
                    MessageBox.Show("No se puede modificar una llamada que no existe");
                    return;
                }
            }

            if (paso)
            {
                limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Llamadas llamada = LlamadasBLL.Buscar(contenedor.llamada.LlamadaId);

            if(llamada != null)
            {
                contenedor.llamada = llamada;
                reCargar();
            }
            else
            {
                MessageBox.Show("Llamada no encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (LlamadasBLL.Eliminar(contenedor.llamada.LlamadaId))
            {
                limpiar();
                MessageBox.Show("Eliminado");
            }
            else
                MessageBox.Show("No se puede eliminar una Llamada que no existe");
        }

        private void MasButton_Click(object sender, RoutedEventArgs e)
        {
            contenedor.llamada.Detalle.Add(new LlamadasDetalle(contenedor.detalle.Problema, contenedor.detalle.Solucion));

            reCargar();
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if(DetalleDataGrid.Items.Count>0 && DetalleDataGrid.SelectedIndex< DetalleDataGrid.Items.Count - 1)
            {
                contenedor.llamada.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                reCargar();
            }
        }

        private void limpiar()
        {
            contenedor = new Contenedor();

            reCargar();
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = contenedor;
        }

        private bool existeEnLaBaseDeDatos()
        {
            Llamadas llamada = LlamadasBLL.Buscar(contenedor.llamada.LlamadaId);

            return llamada != null;
        }

        private class Contenedor
        {
            public Llamadas llamada { get; set; }
            public LlamadasDetalle detalle { get; set; }

            public Contenedor()
            {
                llamada = new Llamadas();
                detalle = new LlamadasDetalle();
            }
        }
    }
}

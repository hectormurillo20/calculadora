using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculadora
{
    public partial class MainPage : ContentPage
    {
        private String operador = null;
        private double? valor1 = null;
        private double? valor2 = null;
        private double? resultado = null;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btn_clicked(object sender, EventArgs e)
        {
            Button boton = sender as Button;
            if("1234567890".Contains(boton.Text) && (valor1 == null || operador == null))
            {
                label_resultado.Text = valor1.ToString() + boton.Text;
                valor1 = Convert.ToDouble(label_resultado.Text);
            }
            else if ("1234567890".Contains(boton.Text) && (valor2 == null || operador != null))
            {
                label_resultado.Text = valor2.ToString() + boton.Text;
                valor2 = Convert.ToDouble(label_resultado.Text);
            }
            else if ("+-X/".Contains(boton.Text) && valor1 != null)
            {
                operador = boton.Text;
            }
            else
            {
                calcular(valor1, valor2, operador);
            }
        }

        private void calcular(double? v1, double? v2, String op)
        {
            switch (op)
            {
                case "+":
                    resultado = (v1 + v2);
                    label_resultado.Text = resultado.ToString();
                    valor1 = resultado;
                    valor2 = null;
                    break;
                case "-":
                    resultado = (v1 - v2);
                    label_resultado.Text = resultado.ToString();
                    valor1 = resultado;
                    valor2 = null;
                    break;
                case "X":
                    resultado = (v1 * v2);
                    label_resultado.Text = resultado.ToString();
                    valor1 = resultado;
                    valor2 = null;
                    break;
                case "/":
                    if (v2 != 0)
                    {
                        resultado = (v1 / v2);
                        label_resultado.Text = resultado.ToString();
                        valor1 = resultado;
                        valor2 = null;
                    }
                    else
                    {
                        label_resultado.Text = "ERROR";
                    }
                    break;
            }
        }

        private void btn_limpiar(object sender, EventArgs e)
        {
            valor1 = null;
            valor2 = null;
            operador = null;
            resultado = null;
            label_resultado.Text = "0";
        }
    }
}

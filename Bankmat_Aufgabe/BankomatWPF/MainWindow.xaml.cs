﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using E03.Vererbung.Buchkonto;

namespace BankomatWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// List of accounts to be stored in data grid
        /// </summary>
        private List<Konto> kontos = new List<Konto>();
        Sparkonto sparkonto = new Sparkonto();
        Girokonto girokonto = new Girokonto();

        public List<Konto>  Kontos
        {
            get { return kontos; }
            set { kontos = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// button adds new account info. to grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButAdd_Click(object sender, RoutedEventArgs e)
        {
            AccountWindow w = new AccountWindow();

            w.Owner = this;
            w.ShowDialog();

            if (w.DialogResult == true)
            {
                if (w.kontotyp == -1)
                {
                    sparkonto = w.sparkonto;
                    Kontos.Add(sparkonto);
                }
                else if (w.kontotyp == 1)
                {
                    girokonto = w.girokonto;
                    Kontos.Add(girokonto);
                }
                DataContext = null;
                DataContext = this;
            }
        }

        private void Butchange_Click(object sender, RoutedEventArgs e)
        {
            int indexval = Gridbank.SelectedIndex;
            sparkonto = Gridbank.SelectedItem as Sparkonto;
            girokonto = Gridbank.SelectedItem as Girokonto;
            AccountWindow w = new AccountWindow(sparkonto);
            w.Owner = this;
            if (sparkonto != null)
            {
                w.ShowDialog();
            }
            else if (girokonto != null)
            {
                w = new AccountWindow(girokonto);
                w.ShowDialog();
            }

            if (w.DialogResult == true)
            {
                if (w.kontotyp == -1)
                {
                    kontos.Remove(sparkonto);
                    sparkonto = w.sparkonto;
                    Kontos.Insert(indexval,sparkonto);
                }
                else if (w.kontotyp == 1)
                {
                    kontos.Remove(girokonto);
                    girokonto = w.girokonto;
                    Kontos.Insert(indexval,girokonto);
                }
                DataContext = null;
                DataContext = this;
            }
        }

        private void Buteinzahlen_Click(object sender, RoutedEventArgs e)
        {
            int indexval = Gridbank.SelectedIndex;
            sparkonto = Gridbank.SelectedItem as Sparkonto;
            girokonto = Gridbank.SelectedItem as Girokonto;
            PayWindow p = new PayWindow(sparkonto,1);
            p.Owner = this;
            if (sparkonto != null)
            {
                p.ShowDialog();
            }
            else if (girokonto != null)
            {
                p = new PayWindow(girokonto,1);
                p.ShowDialog();
            }
            if (p.DialogResult == true)
            {
                if (p.skonto != null)
                {
                    kontos.Remove(sparkonto);
                    sparkonto = p.skonto;
                    Kontos.Insert(indexval, sparkonto);
                }
                else if (p.gkonto != null)
                {
                    kontos.Remove(girokonto);
                    girokonto = p.gkonto;
                    Kontos.Insert(indexval, girokonto);
                }
                DataContext = null;
                DataContext = this;
            }
        }

        private void Butauzahlen_Click(object sender, RoutedEventArgs e)
        {
            int indexval = Gridbank.SelectedIndex;
            sparkonto = Gridbank.SelectedItem as Sparkonto;
            girokonto = Gridbank.SelectedItem as Girokonto;
            PayWindow p = new PayWindow(sparkonto, -1);
            p.Owner = this;
            if (sparkonto != null)
            {
                p.ShowDialog();
            }
            else if (girokonto != null)
            {
                p = new PayWindow(girokonto, -1);
                p.ShowDialog();
            }
            if (p.DialogResult == true)
            {
                if (p.skonto != null)
                {
                    kontos.Remove(sparkonto);
                    sparkonto = p.skonto;
                    Kontos.Insert(indexval, sparkonto);
                }
                else if (p.gkonto != null)
                {
                    kontos.Remove(girokonto);
                    girokonto = p.gkonto;
                    Kontos.Insert(indexval, girokonto);
                }
                DataContext = null;
                DataContext = this;
            }
        }
    }
}

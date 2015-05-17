﻿using Detrav.Terometr.TeraApi;
using System;
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
using System.Windows.Shapes;

namespace Detrav.Terometr.Windows
{
    /// <summary>
    /// Логика взаимодействия для ConfigWindow.xaml
    /// </summary>
    public partial class ConfigWindow : Window
    {
        public ConfigWindow()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            //МУХАХХАХАХА двоичная переменная с третим выбором, да бендер, ДВОЙКА существует!!!!!!
            DialogResult = true;
            Properties.Settings.Default.adapterIndex = comboBoxAdapters.SelectedIndex;
            foreach (var d in Repository.Instance.serverList)
            {
                if (comboBoxServers.SelectedItem.ToString() == d.serverName)
                {
                    Properties.Settings.Default.serverIp = d.serverIp;
                    break;
                }
            }
            double battleTimeout;
            if (!Double.TryParse(textBoxBattleTimeout.Text, out battleTimeout))
                battleTimeout = 5.153;
            Properties.Settings.Default.battleTimeout = battleTimeout;
            if (radioButtonBehavior1.IsChecked == true)
                Properties.Settings.Default.dpsBehaviorType = 1;
            else if (radioButtonBehavior2.IsChecked == true)
                Properties.Settings.Default.dpsBehaviorType = 2;
            else
                Properties.Settings.Default.dpsBehaviorType = 0;
            Properties.Settings.Default.Save();
            Repository.Instance.reStartSniffer(
                Properties.Settings.Default.serverIp,
                Properties.Settings.Default.adapterIndex);
            Repository.Instance.reConfigurate(
                Properties.Settings.Default.battleTimeout,
                Properties.Settings.Default.dpsBehaviorType
                );
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Сначало грузим список адаптеров
            foreach(var d in Repository.Instance.devices)
            {
                comboBoxAdapters.Items.Add(d);
            }
            comboBoxAdapters.SelectedIndex = Properties.Settings.Default.adapterIndex;
            foreach(var d in Repository.Instance.serverList)
            {
                comboBoxServers.Items.Add(d.serverName);
                if (Properties.Settings.Default.serverIp == d.serverIp)
                    comboBoxServers.SelectedItem = d.serverName;
            }
            textBoxBattleTimeout.Text = Properties.Settings.Default.battleTimeout.ToString();
            switch (Properties.Settings.Default.dpsBehaviorType)
            {
                case 0: radioButtonBehavior0.IsChecked = true; break;
                case 1: radioButtonBehavior1.IsChecked = true; break;
                case 2: radioButtonBehavior2.IsChecked = true; break;
                default: radioButtonBehavior0.IsChecked = true; break;
            }
            UpdateLayout();
        }
    }
}

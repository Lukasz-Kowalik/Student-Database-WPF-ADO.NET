using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Database
{
    public partial class MainWindow : Window
    {
      
        private void LoadFromXML_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            try
            {
                if (file.ShowDialog() == true)
                {
                    using (XmlReader doc = XmlReader.Create(file.FileName))
                    {
                        XmlSerializer serializer = new XmlSerializer(list.GetType());
                        list = (List<Student>)serializer.Deserialize(doc);
                    }
                    DG.ItemsSource = list;
                    DG.Items.Refresh();
                    MessageBox.Show("Data has been successfully loaded");
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("File didn't exist." + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error" + ex.Message);
            }
        }

        private void LoadFromFiel_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            try
            {
                if (file.ShowDialog() == true)
                {
                    if (!File.Exists(file.FileName))
                        throw new FileNotFoundException();

                    using (Stream stream = File.Open(file.FileName, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            StreamEnumerable<Student> st = new StreamEnumerable<Student>(reader);
                            foreach (var d in st)
                            {
                                list.Add(d);
                            }
                        }
                        DG.ItemsSource = list;
                        DG.Items.Refresh();
                        MessageBox.Show("Data has been successfully loaded");
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("File didn't exist." + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error: " + ex.Message);
            }
        }

        
    }
}
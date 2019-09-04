using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;

namespace Database
{
    public partial class MainWindow : Window
    {
        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog()
            {
                Filter = "Text (*.txt)|*.txt"
            };

            if (file.ShowDialog() == true)
            {
                using (Stream stream = File.Open(file.FileName,
                    FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(stream))
                    {
                        foreach (var student in list)
                        {
                            Save(student, sw);
                        }

                        MessageBox.Show("Plik zapisany");
                    }
                }
            }
        }

        private void SaveToXML_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog()
            {
                Filter = "FileName (*.xml)|*.xml"
            };

            if (file.ShowDialog() == true)
            {
                using (XmlWriter doc = XmlWriter.Create(file.FileName))
                {
                    XmlSerializer serializer = new XmlSerializer(list.GetType());
                    serializer.Serialize(doc, list);

                    MessageBox.Show("XML zapisany");
                }
            }
        }

        private void Save<T>(T ob, StreamWriter sw)
        {
            Type t = ob.GetType();
            sw.WriteLine($"[[{t.FullName}]]");
            foreach (var p in t.GetProperties())
            {
                sw.WriteLine($"[{p.Name}]");
                sw.WriteLine(p.GetValue(ob));
            }
            sw.WriteLine($"[[]]");
        }
    }
}
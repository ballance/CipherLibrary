using System;
using System.Collections.Generic;
using System.IO;
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
using CryptoLibrary;

namespace Crypto.UI
{
    /// <summary>
    /// Interaction logic for CryptoTest.xaml
    /// </summary>
    public partial class CryptoTest : UserControl
    {

        private List<string> _combinedDictionary = new List<string>();

        public CryptoTest()
        {
            InitializeComponent();
            LoadDictionary();
        }

        public void LoadDictionary()
        {
            var dictionaryDirectory = Directory.EnumerateFiles(@"..\..\wordlists\");
            foreach (string dictionaryFile in dictionaryDirectory)
            {
                var lines = File.ReadAllLines(dictionaryFile);
                _combinedDictionary.AddRange(lines);
            }
        }

        private void GoButton_OnClick(object sender, RoutedEventArgs e)
        {
            var wordRecognizer = new WordRecognizer(_combinedDictionary);
            var words = InputBox.Text.Split(' ');
            foreach (var word in words.Select(w => w.Replace(",","").Replace(".","").Replace("?","")))
            {
                //if (OutputBox2.Text != string.Empty)
                //{
                //    OutputBox2.Text += ", ";
                //}
                OutputBox2.Text = wordRecognizer.ContainsDictionaryWord(word).ToString();
            }

        }
    }
}

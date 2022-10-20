using Assignment21.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Assignment21.Service;
using Newtonsoft.Json;


namespace Assignment21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Contact> contacts; //lista av kontakter
        public Filemanager filemanager = new Filemanager();
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                contacts = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(filemanager.Read());
                lv_Contacts.ItemsSource = contacts; //hämtar information från contacts listan
            }
            catch
            {
                contacts = new ObservableCollection<Contact>(); 
            }
        }
        public void Btn_Delete_Click(object sender, RoutedEventArgs e) //funktion för att ta bprt kontakten
        {
            var button = sender as Button;
            var contact = (Contact)button.DataContext;
            contacts.Remove(contact);
        }
        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            var contact = contacts.FirstOrDefault(x => x.Email == tb_Email.Text); // kontrollerar så att det är en unik email
            if (contact == null) //lägger till kontakten om eposten är unik
            {
                contacts.Add(new Contact()
                {
                    FirstName = tb_Firstname.Text,
                    LastName = tb_Lastname.Text,
                    Email = tb_Email.Text,
                    StreetName = tb_Streetname.Text,
                    PostalCode = tb_Postalcode.Text,
                    City = tb_City.Text
                });
                filemanager.Save(JsonConvert.SerializeObject(contacts));
            }
            else                //ger ett felmeddelande om att eposten redan finns
            {
                MessageBox.Show("Det finns redan en kontakt med samma e-postadress");
            }
            ClearFields();
        }
        private void ClearFields()
        {
            tb_Firstname.Text = "";
            tb_Lastname.Text = "";
            tb_Email.Text = "";
            tb_Streetname.Text = "";
            tb_Postalcode.Text = "";
            tb_City.Text = "";
        }
        private void lv_Contacts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            try // för att programmet inte ska brytas ifall man tar bort alla kontakter
            {
                Btn_Update.Visibility = Visibility.Visible;
                var contact = (Contact)lv_Contacts.SelectedItems[0];
                tb_Firstname.Text = contact.FirstName;
                tb_Lastname.Text = contact.LastName;
                tb_Email.Text = contact.Email;
                tb_Streetname.Text = contact.StreetName;
                tb_Postalcode.Text = contact.PostalCode;
                tb_City.Text = contact.City; 
            }
            catch
            {
            }
        }
        private void Btn_Update_Click(object sender, RoutedEventArgs e)
        {
            var contact = contacts[lv_Contacts.SelectedIndex]; //uppdaterar informationen hos en kontakt genom att ta bort och lägga till
            contacts.Remove(contact);
            contact.FirstName = tb_Firstname.Text;
            contact.LastName = tb_Lastname.Text;
            contact.Email = tb_Email.Text;
            contact.StreetName = tb_Streetname.Text;
            contact.PostalCode = tb_Postalcode.Text;
            contact.City = tb_City.Text;
            contacts.Add(contact);
            ClearFields();
        }
    }
}



namespace HW4_CoffeeShop
{
    using Model;
    using Data;
    public partial class Form1 : Form
    {
        OrderList _orderList = new OrderList();
        string SelectedDrink = string.Empty;
        CupSize cupSize = new CupSize();
        Milk milkAddition = new Milk();
        int numberOfShotsAdded = 0;
        DataProvider dataProvider;
        string[] DrinkNames;
        public Form1(DataProvider _dataProvider)
        {
            InitializeComponent();
            dataProvider = _dataProvider;
            comboBoxCoffees.Items.AddRange(dataProvider.GetDrinkNames(DrinkCategories.Coffee));
            comboBoxColdDrinks.Items.AddRange(dataProvider.GetDrinkNames(DrinkCategories.ColdDrink));
            comboBoxHotDrinks.Items.AddRange(dataProvider.GetDrinkNames(DrinkCategories.HotDrink));


        }

        private OrderItem CreateOrderItem()
        {
            OrderItem item = new OrderItem
            {
                ProductName = SelectedDrink,
                CupSize = cupSize,
                MilkAddition = milkAddition,
                NumberOfShotsAdded = numberOfShotsAdded,
            };
            item.Price = dataProvider.GetPrice(item);
            return item;
        }

        private bool ValidateForm()
        {
            bool validation = true;
            validation = TextBoxUserName.Text != string.Empty
            && TextBoxAddress.Text != string.Empty
            && TextBoxPhone.Text != string.Empty
            && SelectedDrink != string.Empty;

            return validation;
        }
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                OrderItem item = CreateOrderItem();
                _orderList.AddItem(item);
                UpdateOrderListBox();
            }
        }

        private void BtnGiveOrder_Click(object sender, EventArgs e)
        {
            if(_orderList.Count > 0)
            {
                LabelTotalAmount.Text = $"Toplam Sipariþ Tutarý: {_orderList.GetPrice(),8:C2}TL"; 
            }
            MessageBox.Show($"Toplam {_orderList.Count} sipariþiniz {_orderList.GetPrice(),8:C2} Tutarýndadýr.");
        }

        private void UpdateOrderListBox()
        {
            ListBoxSelectedProducts.BeginUpdate();

            ListBoxSelectedProducts.Items.Clear();
            foreach (string item in _orderList.GetStringArray())
            {
                ListBoxSelectedProducts.Items.Add(item);
            }
            ListBoxSelectedProducts.EndUpdate();
        }

        private void DrinkComboboxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = ((ComboBox)sender).SelectedIndex;
            SelectedDrink = (string)((ComboBox)sender).Items[index];
            /*
            if (sender != comboBoxCoffees)
            {
                comboBoxCoffees.SelectedIndex = -1;
            }
            if (sender != comboBoxColdDrinks)
            {
                comboBoxColdDrinks.SelectedIndex = -1;
            }
            if (sender != comboBoxHotDrinks)
            {
                comboBoxHotDrinks.SelectedIndex = -1;
            }
            */
        }

        private void radioButtonSizeSmall_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                cupSize = CupSize.Small;
            }

        }

        private void radioButtonSizeMedium_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                cupSize = CupSize.Medium;
            }
        }

        private void radioButtonSizeBig_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                cupSize = CupSize.Big;
            }
        }

        private void RadioButtonFatless_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                milkAddition = Milk.Skimmed;
            }
        }

        private void RadioButtonFatSoya_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == true)
            {
                milkAddition = Milk.Soya;
            }
        }

        private void CheckBoxOneShot_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                numberOfShotsAdded += 1;
            }
            else
            {
                numberOfShotsAdded -= 1;
            }
        }

        private void CheckBoxTwoShot_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                numberOfShotsAdded += 2;
            }
            else
            {
                numberOfShotsAdded -= 2;
            }
        }
    }
}
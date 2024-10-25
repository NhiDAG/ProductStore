using BussinessObjects;
using Repositories;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IProductRepository iProductRepository;
        private readonly ICategoryRepository iCategoryRepository;

        public MainWindow()
        {
            InitializeComponent();
            iProductRepository = new ProductRepository();
            iCategoryRepository = new CategoryRepository();
        }

        public void LoadCategoryList()
        {
            try
            {
                var catList = iCategoryRepository.GetCategories();
                cboCategory.ItemsSource = catList;
                cboCategory.DisplayMemberPath = "CategoryName";
                cboCategory.SelectedValuePath = "CategoryId";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of categories");
            }
        }

        public void LoadProductList()
        {
            try
            {
                var productList = iProductRepository.GetProducts();
                dgData.ItemsSource = productList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of products");

            }
            finally
            {
                resetInput();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategoryList();
            LoadProductList();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtProductName == null || txtPrice == null || txtUnitsInStock == null || cboCategory == null)
                {
                    MessageBox.Show("One or more UI elements are not initialized.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtProductName.Text))
                {
                    MessageBox.Show("Please enter a product name.");
                    return;
                }

                if (!Decimal.TryParse(txtPrice.Text, out decimal price))
                {
                    MessageBox.Show("Please enter a valid price.");
                    return;
                }

                if (!short.TryParse(txtUnitsInStock.Text, out short unitsInStock))
                {
                    MessageBox.Show("Please enter a valid number for units in stock.");
                    return;
                }

                if (cboCategory.SelectedValue == null)
                {
                    MessageBox.Show("Please select a category.");
                    return;
                }
                Product product = new Product();
                product.ProductName = txtProductName.Text;
                product.UnitPrice = Decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                if (iProductRepository == null)
                {
                    MessageBox.Show("iProductService is not initialized.");
                    return;
                }
                iProductRepository.SaveProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedIndex == -1) return;
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid.SelectedIndex < 0) return;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);
            if (row == null) return;
            DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row)?.Parent as DataGridCell;
            if (RowColumn == null) return;
            string id = ((TextBlock)RowColumn.Content)?.Text;
            if (id == null) return;
            Product product = iProductRepository.GetProductById(Int32.Parse(id));
            if (product == null) return;
            txtProductID.Text = product.ProductId.ToString();
            txtProductName.Text = product.ProductName;
            txtPrice.Text = product.UnitPrice.ToString();
            txtUnitsInStock.Text = product.UnitsInStock.ToString();
            cboCategory.SelectedValue = product.CategoryId;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    Product product = new Product();
                    product.ProductId = Int32.Parse(txtProductID.Text);
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = Decimal.Parse(txtPrice.Text);
                    product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                    product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                    iProductRepository.UpdateProduct(product);
                }
                else
                {
                    MessageBox.Show("You must select a Product !");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadProductList();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtProductID.Text.Length > 0)
                {
                    Product product = new Product();
                    product.ProductId = Int32.Parse(txtProductID.Text);
                    product.ProductName = txtProductName.Text;
                    product.UnitPrice = Decimal.Parse(txtPrice.Text);
                    product.UnitsInStock = short.Parse(txtUnitsInStock.Text);
                    product.CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString());
                    iProductRepository.DeleteProduct(product);
                }
                else
                {
                    MessageBox.Show("You must select a Product !");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("You must select a Product!");
            }
            finally
            {
                LoadProductList();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resetInput()
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtUnitsInStock.Text = "";
            cboCategory.SelectedValue = 0;
        }
    }
}
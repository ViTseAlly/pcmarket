using System.ComponentModel.Design.Serialization;
using System.Globalization;
using App.Structs;
using App.Toolkit;



namespace App.Toolkit
{    
    public class ProductToolkits
    {
        Toolkits toolkits = new Toolkits();
        private string PATH_TO_PRODUCTS_FILE = "./Data/Components/products.json";

        public void GelAllProducts()
        {
            List<ProductStruct> productStruct = toolkits.GetDataFromProductsJsonFile(this.PATH_TO_PRODUCTS_FILE);
            foreach(ProductStruct pr in productStruct)
            {
                pr.GetAllProductData();
            }
        }
    }
}
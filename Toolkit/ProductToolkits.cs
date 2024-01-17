using App.Structs;



namespace App.Toolkit
{    
    public class ProductToolkits
    {
        Toolkits toolkits = new Toolkits();
        Fonts fonts = new Fonts();
        private string PATH_TO_PRODUCTS_FILE = "./Data/Components/products.json";

        public void GetAllProducts(List<ProductStruct> productsList)
        {
            foreach(ProductStruct pr in productsList)
            {
                pr.GetAllProductData();
            }
        }

        public List<ProductStruct> FindProducts(byte options)
        {
            List<ProductStruct> productStruct = toolkits.GetDataFromProductsJsonFile(this.PATH_TO_PRODUCTS_FILE);
            List<ProductStruct> result = new List<ProductStruct>();
            Console.Write("\n\t\t    What you find?\n\t\t    >>>");
            string findData = Console.ReadLine() ?? "";

            switch (options)
            {
                case 1:
                    return productStruct.FindAll(product => product.Type.Equals(findData, StringComparison.OrdinalIgnoreCase));

                case 2:
                    return productStruct.FindAll(product => product.Name.Contains(findData, StringComparison.OrdinalIgnoreCase));

                case 3:
                    if (int.TryParse(findData, out int maxPrice))
                    {
                        return productStruct.FindAll(product => product.Price <= maxPrice);
                    }
                    break;

                default:
                    fonts.RedText("I N V A L I D   D A T A");
                    fonts.OrangeText("Try again...", true);
                    break;
            }
            return result;
        }
    
        public ProductStruct GetProductById(int id)
        {
            List<ProductStruct> productStruct = toolkits.GetDataFromProductsJsonFile(this.PATH_TO_PRODUCTS_FILE);
            foreach(ProductStruct el in productStruct)
            {
                if(el.Id == id)
                return el;
            }
            return new ProductStruct();
        }
    }
}
using App.Path;
using App.Structs;
using Newtonsoft.Json;



namespace App.Toolkit
{    
    public class ProductToolkits
    {
        Toolkits toolkits = new Toolkits();
        Fonts fonts = new Fonts();
        PathToFiles pathToFiles = new PathToFiles();
        public void GetAllProducts(List<ProductStruct> productsList)
        {
            foreach(ProductStruct pr in productsList)
            {
                pr.GetAllProductData();
            }
        }

        public List<ProductStruct> FindProducts(byte options)
        {
            List<ProductStruct> productStruct = toolkits.GetDataFromProductsJsonFile(pathToFiles.GetPathToProducts());
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
            List<ProductStruct> productStruct = toolkits.GetDataFromProductsJsonFile(pathToFiles.GetPathToProducts());
            foreach(ProductStruct el in productStruct)
            {
                if(el.Id == id)
                return el;
            }
            return new ProductStruct();
        }

        public bool DeleteProductFromFile(int productId)
        {
            List<ProductStruct> productsList = toolkits.GetDataFromProductsJsonFile(pathToFiles.GetPathToProducts());
            if(productId > productsList[productsList.Count - 1].Id || productId <= 0) return false;
            foreach(ProductStruct pr in productsList)
            {
                if(pr.Id == productId)
                productsList.Remove(pr);
                break;
            }
            File.Delete(pathToFiles.GetPathToProducts());
            string jsonContent = JsonConvert.SerializeObject(productsList, Formatting.Indented);
            File.WriteAllText(pathToFiles.GetPathToProducts(), jsonContent);
            return true;
        }

        public bool EditProductFromFile(int productId)
        {
            List<ProductStruct> productsList = toolkits.GetDataFromProductsJsonFile(pathToFiles.GetPathToProducts());
            ProductStruct newProduct = new ProductStruct();
            if(productId > productsList[productsList.Count - 1].Id || productId <= 0) return false;
            foreach(ProductStruct pr in productsList)
            {
                if(productId == pr.Id)
                {
                    Console.WriteLine("\n\t\t    Old product data:");
                    pr.GetAllProductData();
                    Console.WriteLine("\n\t\t    New product data:");
                    newProduct.SetAllProductData(productsList);
                    productsList.Remove(pr);
                    productsList.Add(newProduct);
                    break;
                }
            }
            string jsonContent = JsonConvert.SerializeObject(productsList, Formatting.Indented);
            File.WriteAllText(pathToFiles.GetPathToProducts(), jsonContent);
            return true;
        }

        public bool AddNewProductInFile(ProductStruct productData)
        {
            List<ProductStruct> productsList = toolkits.GetDataFromProductsJsonFile(pathToFiles.GetPathToProducts());
            productsList.Add(productData);

            string jsonContent = JsonConvert.SerializeObject(productsList, Formatting.Indented);
            File.WriteAllText(pathToFiles.GetPathToProducts(), jsonContent);
            return true;
        }
    
        public bool ValidateProductData(ProductStruct productData)
        {
            return
                !string.IsNullOrWhiteSpace(productData.Type) &&
                !string.IsNullOrWhiteSpace(productData.Name) && productData.Name.Length > 4 &&
                productData.Count > 0 &&
                productData.Price > 0 &&
                !string.IsNullOrWhiteSpace(productData.Information) && productData.Information.Length >= 10;
        }
    }
}
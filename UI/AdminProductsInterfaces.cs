using App.Path;
using App.Toolkit;
using App.Structs;



namespace App.UI
{
    public class AdminProductsInterfaces
    {
        ProductToolkits prtoolkits = new ProductToolkits();
        Toolkits toolkits = new Toolkits();
        PathToFiles pathToFiles = new PathToFiles();
        Fonts fonts = new Fonts();

        public void CheckAllProducts()
        {
            List<ProductStruct> productsList = toolkits.GetDataFromProductsJsonFile(pathToFiles.GetPathToProducts());
            prtoolkits.GetAllProducts(productsList);
            fonts.GreenText("Press any key to leave in admin menu...", true);
        }
    
        public void AddNewProduct()
        {
            List<ProductStruct> productsList = toolkits.GetDataFromProductsJsonFile(pathToFiles.GetPathToProducts());
            bool isProductAdd = false;
            Console.Clear();
            Console.WriteLine("        ________    _______    ___       __                                          \r\n       |\\   ___  \\ |\\  ___ \\  |\\  \\     |\\  \\                                        \r\n       \\ \\  \\\\ \\  \\\\ \\   __/| \\ \\  \\    \\ \\  \\                                       \r\n        \\ \\  \\\\ \\  \\\\ \\  \\_|/__\\ \\  \\  __\\ \\  \\                                      \r\n         \\ \\  \\\\ \\  \\\\ \\  \\_|\\ \\\\ \\  \\|\\__\\_\\  \\                                     \r\n          \\ \\__\\\\ \\__\\\\ \\_______\\\\ \\____________\\                                    \r\n           \\|__| \\|__| \\|_______| \\|____________|                                    \r\n        ________   ________   ________   ________   ___  ___   ________  _________   \r\n       |\\   __  \\ |\\   __  \\ |\\   __  \\ |\\   ___ \\ |\\  \\|\\  \\ |\\   ____\\|\\___   ___\\ \r\n       \\ \\  \\|\\  \\\\ \\  \\|\\  \\\\ \\  \\|\\  \\\\ \\  \\_|\\ \\\\ \\  \\\\\\  \\\\ \\  \\___|\\|___ \\  \\_| \r\n        \\ \\   ____\\\\ \\   _  _\\\\ \\  \\\\\\  \\\\ \\  \\ \\\\ \\\\ \\  \\\\\\  \\\\ \\  \\        \\ \\  \\  \r\n         \\ \\  \\___| \\ \\  \\\\  \\|\\ \\  \\\\\\  \\\\ \\  \\_\\\\ \\\\ \\  \\\\\\  \\\\ \\  \\____    \\ \\  \\ \r\n          \\ \\__\\     \\ \\__\\\\ _\\ \\ \\_______\\\\ \\_______\\\\ \\_______\\\\ \\_______\\   \\ \\__\\\r\n           \\|__|      \\|__|\\|__| \\|_______| \\|_______| \\|_______| \\|_______|    \\|__|");
            Console.WriteLine("\n\t\t    Write new product information:");
            ProductStruct newProduct = new ProductStruct();
            while(!isProductAdd)
            {
                newProduct.SetAllProductData(productsList);
                if(prtoolkits.ValidateProductData(newProduct))
                {
                    isProductAdd = true;
                    prtoolkits.AddNewProductInFile(newProduct);
                    fonts.GreenText("P R O D U C T   A D D E D");
                    fonts.GreenText("Press any key to leave in admin menu...", true);
                }
                else
                {
                    fonts.RedText("I N V A L I D   D A T A");
                    fonts.OrangeText("Press any key to try again...");
                }
            }
        }
    
        public void DeleteProduct()
        {
            Console.Clear();
            Console.WriteLine("        ________  _______   ___       _______  _________  _______              \r\n       |\\   ___ \\|\\  ___ \\ |\\  \\     |\\  ___ \\|\\___   ___\\\\  ___ \\             \r\n       \\ \\  \\_|\\ \\ \\   __/|\\ \\  \\    \\ \\   __/\\|___ \\  \\_\\ \\   __/|            \r\n        \\ \\  \\ \\\\ \\ \\  \\_|/_\\ \\  \\    \\ \\  \\_|/__  \\ \\  \\ \\ \\  \\_|/__          \r\n         \\ \\  \\_\\\\ \\ \\  \\_|\\ \\ \\  \\____\\ \\  \\_|\\ \\  \\ \\  \\ \\ \\  \\_|\\ \\         \r\n          \\ \\_______\\ \\_______\\ \\_______\\ \\_______\\  \\ \\__\\ \\ \\_______\\        \r\n           \\|_______|\\|_______|\\|_______|\\|_______|   \\|__|  \\|_______|        \r\n        ________  ________  ________  ________  ___  ___  ________ _________   \r\n       |\\   __  \\|\\   __  \\|\\   __  \\|\\   ___ \\|\\  \\|\\  \\|\\   ____\\\\___   ___\\ \r\n       \\ \\  \\|\\  \\ \\  \\|\\  \\ \\  \\|\\  \\ \\  \\_|\\ \\ \\  \\\\\\  \\ \\  \\___\\|___ \\  \\_| \r\n        \\ \\   ____\\ \\   _  _\\ \\  \\\\\\  \\ \\  \\ \\\\ \\ \\  \\\\\\  \\ \\  \\       \\ \\  \\  \r\n         \\ \\  \\___|\\ \\  \\\\  \\\\ \\  \\\\\\  \\ \\  \\_\\\\ \\ \\  \\\\\\  \\ \\  \\____   \\ \\  \\ \r\n          \\ \\__\\    \\ \\__\\\\ _\\\\ \\_______\\ \\_______\\ \\_______\\ \\_______\\  \\ \\__\\\r\n           \\|__|     \\|__|\\|__|\\|_______|\\|_______|\\|_______|\\|_______|   \\|__|");
            Console.WriteLine("\n\t\t    Write product id what you want delete:");
            int userInput = toolkits.CheckUserInputInt();
            if(prtoolkits.DeleteProductFromFile(userInput))
            {
                fonts.GreenText("P R O D U C T   D E L E T E D");
                fonts.GreenText("Press any key to leave in menu...", true);
            }
            else
            {
                fonts.RedText("P R O D U C T   N O T   F I N D");
                fonts.OrangeText("Press any key to leave in menu...", true);
            }
        }
    
        public void EditProduct()
        {
            Console.Clear();
            Console.WriteLine("        _______   ________  ___  _________  _______                            \r\n       |\\  ___ \\ |\\   ___ \\|\\  \\|\\___   ___\\\\  ___ \\                           \r\n       \\ \\   __/|\\ \\  \\_|\\ \\ \\  \\|___ \\  \\_\\ \\   __/|                          \r\n        \\ \\  \\_|/_\\ \\  \\ \\\\ \\ \\  \\   \\ \\  \\ \\ \\  \\_|/__                        \r\n         \\ \\  \\_|\\ \\ \\  \\_\\\\ \\ \\  \\   \\ \\  \\ \\ \\  \\_|\\ \\                       \r\n          \\ \\_______\\ \\_______\\ \\__\\   \\ \\__\\ \\ \\_______\\                      \r\n           \\|_______|\\|_______|\\|__|    \\|__|  \\|_______|                      \r\n        ________  ________  ________  ________  ___  ___  ________ _________   \r\n       |\\   __  \\|\\   __  \\|\\   __  \\|\\   ___ \\|\\  \\|\\  \\|\\   ____\\\\___   ___\\ \r\n       \\ \\  \\|\\  \\ \\  \\|\\  \\ \\  \\|\\  \\ \\  \\_|\\ \\ \\  \\\\\\  \\ \\  \\___\\|___ \\  \\_| \r\n        \\ \\   ____\\ \\   _  _\\ \\  \\\\\\  \\ \\  \\ \\\\ \\ \\  \\\\\\  \\ \\  \\       \\ \\  \\  \r\n         \\ \\  \\___|\\ \\  \\\\  \\\\ \\  \\\\\\  \\ \\  \\_\\\\ \\ \\  \\\\\\  \\ \\  \\____   \\ \\  \\ \r\n          \\ \\__\\    \\ \\__\\\\ _\\\\ \\_______\\ \\_______\\ \\_______\\ \\_______\\  \\ \\__\\\r\n           \\|__|     \\|__|\\|__|\\|_______|\\|_______|\\|_______|\\|_______|   \\|__|");
            Console.WriteLine("\n\t\t    Write product id what you want edit:");
            int index = toolkits.CheckUserInputInt();
            if(prtoolkits.EditProductFromFile(index))
            {
                fonts.GreenText("P R O D U C T   D A T A   U P D A T E D   S U C C E S S");
                fonts.GreenText("Press any key to leave in menu...", true);
            }
            else
            {
                fonts.RedText("I N V A L I D   I N D E X");
                fonts.OrangeText("Press any key to leave in menu...", true);
            }
        }
    }
}
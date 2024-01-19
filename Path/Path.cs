using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Path
{
    public class PathToFiles
    {
        private string PATH_TO_PRODUCTS_FILE { get; set; }
        private string PATH_TO_USERS_FILE { get; set; }

        public PathToFiles()
        {
            PATH_TO_PRODUCTS_FILE = "./Data/Components/products.json";
            PATH_TO_USERS_FILE = "./Data/Users/users.json";
        }

        public string GetPathToUsers()
        {
            return this.PATH_TO_USERS_FILE;
        }

        public string GetPathToProducts()
        {
            return this.PATH_TO_PRODUCTS_FILE;
        }
    }
}

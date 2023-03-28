using Havedesign_Web_API.Model;
using Npgsql;
using NpgsqlTypes;

namespace Havedesign_Web_API
{
    public static class DBHandler
    {
        public static readonly string ConnectionString = "someString";

        public static List<Customer> RetrieveAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(("SELECT * FROM v_customers"), connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string? name;
                        if (reader.IsDBNull(reader.GetOrdinal("name")) == true)
                            name = null;
                        else
                            name = (string?)reader["name"];

                        int? phone;
                        if (reader.IsDBNull(reader.GetOrdinal("phone")) == true)
                            phone = null;
                        else
                            phone = (int?)reader["phone"];

                        string? address;
                        if (reader.IsDBNull(reader.GetOrdinal("address")) == true)
                            address = null;
                        else
                            address = (string?)reader["address"];

                        string? email;
                        if (reader.IsDBNull(reader.GetOrdinal("email")) == true)
                            email = null;
                        else
                            email = (string?)reader["email"];

                        Customer customer = new Customer(
                            (int)reader["customer_id"], 
                            name, 
                            phone, 
                            address, 
                            email
                            );
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }
        public static List<Item> RetrieveAllItems()
        {
            List<Item> items = new List<Item>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(("SELECT * FROM v_items"), connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Item item = new Item ((int)reader["item_id"], (int)reader["item_category_id"], (string)reader["name"], (string)reader["prefab_name"], (string)reader["thumb_path"]);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public static List<Category> RetrieveAllItemCategories()
        {
            List<Category> categories = new List<Category>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand((("SELECT * FROM v_item_categories")), connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category category = new Category((int)reader["item_category_id"], (string)reader["name"]);
                        categories.Add(category);
                    }
                }
            }
            return categories;
        }

        public static Customer RetrieveCustomer(int customerID)
        {
            Customer customer = new Customer(0, "", 0, "", "");
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand((("SELECT * FROM f_get_customer_by_id(@0)")), connection);

                command.Parameters.AddWithValue("@0", customerID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string? name;
                        if (reader.IsDBNull(reader.GetOrdinal("name")) == true)
                            name = null;
                        else
                            name = (string?)reader["name"];

                        int? phone;
                        if (reader.IsDBNull(reader.GetOrdinal("phone")) == true)
                            phone = null;
                        else
                            phone = (int?)reader["phone"];

                        string? address;
                        if (reader.IsDBNull(reader.GetOrdinal("address")) == true)
                            address = null;
                        else
                            address = (string?)reader["address"];

                        string? email;
                        if (reader.IsDBNull(reader.GetOrdinal("email")) == true)
                            email = null;
                        else
                            email = (string?)reader["email"];

                        customer = new Customer(
                            (int)reader["customer_id"],
                            name,
                            phone,
                            address,
                            email
                            );
                    }
                }
            }
            return customer;
        }

        public static Garden RetrieveGarden(int gardenID)
        {
            Garden garden = new Garden(0, 0, "", DateTime.Now, "");
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand((("SELECT * FROM f_get_garden_by_id(@0)")), connection);

                command.Parameters.AddWithValue("@0", gardenID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime? date;
                        if (reader.IsDBNull(reader.GetOrdinal("deleted_since")) == true)
                            date = null;
                        else
                            date = (DateTime?)reader["deleted_since"];

                        string? note;
                        if (reader.IsDBNull(reader.GetOrdinal("note")) == true)
                            note = null;
                        else
                            note = (string?)reader["note"];

                        garden = new Garden(
                            (int)reader["garden_id"],
                            (int)reader["customer_id"],
                            (string)reader["name"],
                            date,
                            note
                        );
                    }
                }
            }
            return garden;
        }

        public static Category RetrieveCategory(int categoryID)
        {
            Category category = new Category(0, "");
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand((("SELECT * FROM f_get_item_category_by_id(@0)")), connection);

                command.Parameters.AddWithValue("@0", categoryID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        category = new Category((int)reader["item_category_id"], (string)reader["name"]);
                    }
                }
            }
            return category;
        }

        public static Item RetrieveItem(int itemID)
        {
            Item item = new Item(0, 0, "", "", "");
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(("SELECT * FROM f_get_item_by_id(@0)"), connection);

                command.Parameters.AddWithValue("@0", itemID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        item = new Item((int)reader["item_id"], (int)reader["item_category_id"], (string)reader["name"], (string)reader["prefab_name"], (string)reader["thumb_path"]);
                    }
                }
            }
            return item;
        }

        public static List<Item> RetrieveItemsInCategory(int categoryID)
        {
            List<Item> items = new List<Item>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(("SELECT * FROM f_get_items_in_category_by_id(@0)"), connection);

                command.Parameters.AddWithValue("@0", categoryID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Item item = new Item((int)reader["item_id"], (int)reader["item_category_id"], (string)reader["name"], (string)reader["prefab_name"], (string)reader["thumb_path"]);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public static List<Garden> RetrieveCustomersGardens(int customerID)
        {
            List<Garden> gardens = new List<Garden>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(("SELECT * FROM f_get_customers_gardens_by_id(@0)"), connection);

                command.Parameters.AddWithValue("@0", customerID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime? date;
                        if (reader.IsDBNull(reader.GetOrdinal("deleted_since")) == true)
                            date = null;
                        else
                            date = (DateTime?)reader["deleted_since"];

                        string? note;
                        if (reader.IsDBNull(reader.GetOrdinal("note")) == true)
                            note = null;
                        else
                            note = (string?)reader["note"];

                        Garden garden = new Garden(
                            (int)reader["garden_id"], 
                            (int)reader["customer_id"], 
                            (string)reader["name"], 
                            date, 
                            note
                            );
                        gardens.Add(garden);
                    }
                }
            }
            return gardens;
        }

        public static List<GardensImg> RetrieveGardensImgs(int gardenID)
        {
            List<GardensImg> imgs = new List<GardensImg>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(("SELECT * FROM f_get_gardens_imgs_by_id(@0)"), connection);

                command.Parameters.AddWithValue("@0", gardenID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GardensImg img = new GardensImg((int)reader["garden_img_id"], (int)reader["garden_id"], (string)reader["img_path"], (bool)reader["is_main_img"]);
                        imgs.Add(img);
                    }
                }
            }
            return imgs;
        }

        public static List<GardensItem> RetrieveGardensItems(int gardenID)
        {
            List<GardensItem> items = new List<GardensItem>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(("SELECT * FROM f_get_gardens_items_by_id(@0)"), connection);

                command.Parameters.AddWithValue("@0", gardenID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GardensItem item = new GardensItem((int)reader["garden_item_id"], (int)reader["item_id"], (int)reader["item_category_id"], (string)reader["name"]);
                        items.Add(item);
                    }
                }
            }
            return items;
        }

        public static List<GardensUnityItem> RetrieveGardensUnityItems(int gardenID)
        {
            List<GardensUnityItem> items = new List<GardensUnityItem>();
            using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();
                NpgsqlCommand command = new NpgsqlCommand(("SELECT * FROM f_get_gardens_unity_items_by_id(@0)"), connection);

                command.Parameters.AddWithValue("@0", gardenID);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GardensUnityItem item = new GardensUnityItem((int)reader["garden_item_id"], (int)reader["garden_id"], (int)reader["item_id"], (string)reader["prefab_name"], (NpgsqlPoint)reader["placement"], (double)reader["rotation"]);
                        items.Add(item);
                    }
                }
            }
            return items;
        }
    }
}

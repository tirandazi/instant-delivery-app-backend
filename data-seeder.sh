# Before executing the file:
#   - In a terminal session, type the command: 'set -a'
#   - Next, 'source .env'
#   - Third step is to run the postgres container
#   - Now, run the script 'sh data-seeder.sh'

seed_products_data () {
    echo "Seeding product data in database..."
    PGPASSWORD=${DB_PASSWORD} psql -h ${DB_HOST} -p ${DB_EXPOSED_PORT} -U ${DB_USERNAME} -d ${DB_DATABASE} -qc \
    "insert into products (product_code, name, description, price, date) values \
    ('PK374GFB48SW1', 'Banana', 'One dozen of yellow banana', 72.00, '2024-12-12'), \
    ('J38DYR73YEB22', 'Brown Egg', '100% Natural brown eggs. Quantity: 2x6', 95.25, '2024-10-01'), \
    ('X9B0WZ42EQA34', 'Apple', 'Fresh red apples, pack of 6', 60.00, '2024-11-20'), \
    ('A1C2D3E4F5G6', 'Milk', '1 liter of organic whole milk', 1.99, '2024-12-01'), \
    ('B7G8H9J0K1L2', 'Bread', 'Whole wheat bread, sliced', 2.50, '2024-10-15'), \
    ('M2N3O4P5Q6R7', 'Cheese', '200 grams of aged cheddar cheese', 5.75, '2024-11-05'), \
    ('S8T9U0V1W2X3', 'Chicken Breast', '500 grams of fresh chicken breast', 7.99, '2024-09-25'), \
    ('Y4Z5A6B7C8D9', 'Yogurt', '1 kg tub of vanilla yogurt', 4.00, '2024-10-10'), \
    ('E1F2G3H4I5J6', 'Rice', '1 kg bag of long-grain rice', 3.25, '2024-11-15'), \
    ('K7L8M9N0O1P2', 'Orange Juice', '1 liter of freshly squeezed orange juice', 3.99, '2024-12-20'), \
    ('Q3R4S5T6U7V8', 'Cereal', '500 grams of breakfast cereal', 2.99, '2024-10-05'), \
    ('W9X0Y1Z2A3B4', 'Tomato', '1 kg of ripe tomatoes', 4.50, '2024-11-25'), \
    ('C5D6E7F8G9H0', 'Potato', '2 kg bag of potatoes', 3.75, '2024-12-10'), \
    ('J1K2L3M4N5O6', 'Onion', '1 kg of onions', 2.99, '2024-10-30'), \
    ('R7S8T9U0V1W2', 'Garlic', '200 grams of fresh garlic', 1.49, '2024-11-10'), \
    ('D3E4F5G6H7I8', 'Spinach', '500 grams of fresh spinach', 2.79, '2024-09-30'), \
    ('O9P0Q1R2S3T4', 'Butter', '250 grams of unsalted butter', 3.50, '2024-10-20'), \
    ('F6G7H8I9J0K1', 'Chicken Wings', '1 kg of chicken wings', 9.99, '2024-11-01'), \
    ('L2M3N4O5P6Q7', 'Pasta', '500 grams of spaghetti', 1.99, '2024-10-25'), \
    ('V8W9X0Y1Z2A3', 'Cookies', 'Pack of 12 chocolate chip cookies', 4.00, '2024-12-05'), \
    ('H4I5J6K7L8M9', 'Peanut Butter', '250 grams of creamy peanut butter', 3.25, '2024-11-20'), \
    ('T0U1V2W3X4Y5', 'Jam', '350 grams of strawberry jam', 2.75, '2024-10-12')";
}


seed_products_data
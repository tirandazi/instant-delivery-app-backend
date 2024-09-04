CREATE TABLE products (
    id UUID DEFAULT gen_random_uuid(),
    product_code VARCHAR(13) NOT NULL UNIQUE,
    name VARCHAR(50) NOT NULL,
    description VARCHAR(1000) NOT NULL,
    price MONEY NOT NULL,
    date DATE NOT NULL,
    PRIMARY KEY (id)
);
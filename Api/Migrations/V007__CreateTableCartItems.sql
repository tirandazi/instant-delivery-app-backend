CREATE TABLE cart_items (
  cart_id BIGINT,
  product_id BIGINT,
  quantity INT,
  price MONEY,
  FOREIGN KEY (cart_id) REFERENCES cart(id),
  FOREIGN KEY (product_id) REFERENCES products(id),
  PRIMARY KEY (cart_id, product_id)
);

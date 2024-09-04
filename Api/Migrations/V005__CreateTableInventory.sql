CREATE TABLE inventory (
  store_id UUID,
  product_id UUID,
  quantity INT,
  FOREIGN KEY (store_id) REFERENCES store(id),
  FOREIGN KEY (product_id) REFERENCES products(id),
  PRIMARY KEY (store_id, product_id)
);

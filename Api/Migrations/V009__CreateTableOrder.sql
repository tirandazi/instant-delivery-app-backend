CREATE TABLE orders (
  id UUID DEFAULT gen_random_uuid(),
  store_id UUID,
  customer_id UUID,
  delivery_partner_id UUID,
  cart_id UUID,
  payment_mode VARCHAR,
  delivery_status VARCHAR,
  total_amount MONEY,
  FOREIGN KEY (store_id) REFERENCES store(id),
  FOREIGN KEY (customer_id) REFERENCES customer(id),
  FOREIGN KEY (delivery_partner_id) REFERENCES delivery_partner(id),
  FOREIGN KEY (cart_id) REFERENCES cart(id),
  PRIMARY KEY(id)
);

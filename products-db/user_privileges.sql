CREATE USER IF NOT EXISTS 'product-api'@'%' IDENTIFIED BY 'securepass';
GRANT ALL PRIVILEGES ON product_db.* TO 'product-api'@'%';
FLUSH PRIVILEGES;

# 用户表

- id
- name
- password
- phone
- address

```sql
CREATE TABLE `user` (
`id`  int NOT NULL AUTO_INCREMENT PRIMARY KEY,
`name`  varchar(255) NOT NULL,
`password`  varchar(255) NOT NULL,
`phone`  varchar(255) NOT NULL,
`address`  varchar(255) NOT NULL
) DEFAULT CHARACTER SET=utf8;
```

# 商品表

- id
- name
- price
- count
- image
- status

```sql
CREATE TABLE `product` (
`id`  int NOT NULL AUTO_INCREMENT PRIMARY KEY,
`name`  varchar(255) NOT NULL,
`price`  float NOT NULL,
`count`  int NOT NULL,
`image`  varchar(255) NOT NULL,
`status`  int NOT NULL
) DEFAULT CHARACTER SET=utf8;
```

# 订单表

- id
- status
- count
- buy_id
- pro_id

```sql
CREATE TABLE `orderlist` (
`id`  int NOT NULL AUTO_INCREMENT PRIMARY KEY,
`status`  int NOT NULL,
`count`  int NOT NULL,
`buy_id`  int NOT NULL,
`pro_id`  int NOT NULL,
CONSTRAINT `order_buy_fk_id` FOREIGN KEY (`buy_id`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT `order_pro_fk_id` FOREIGN KEY (`pro_id`) REFERENCES `product` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) DEFAULT CHARACTER SET=utf8;
```

# 购物车表

- id
- count
- buy_id
- pro_id

```sql
CREATE TABLE `cart` (
`id`  int NOT NULL AUTO_INCREMENT PRIMARY KEY,
`count`  int NOT NULL,
`buy_id`  int NOT NULL,
`pro_id`  int NOT NULL,
CONSTRAINT `cart_buy_fk_id` FOREIGN KEY (`buy_id`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT `cart_pro_fk_id` FOREIGN KEY (`pro_id`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) DEFAULT CHARACTER SET=utf8;
```

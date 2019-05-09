# 参考资料

- 官方文档：https://docs.microsoft.com/zh-cn/aspnet/core/tutorials/first-mvc-app/?view=aspnetcore-2.2
- 我的asp博客：https://ljd1996.github.io/2019/04/30/asp-net-core%E5%AD%A6%E4%B9%A0%E7%AC%94%E8%AE%B0/#more
- 我的C#博客：https://ljd1996.github.io/2019/04/29/C-Sharp%E5%AD%A6%E4%B9%A0%E7%AC%94%E8%AE%B0/#more

# 环境配置

- 下载MySQL数据库，新建名为asp的数据库，根据下方的建表语句建表
- 下载asp.net core环境：net core sdk 2.2，下载地址：https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer ，具体在Window上的安装方法见官网：https://dotnet.microsoft.com/download/dotnet-core/2.2 。
- 通过VS code或者其他IDE打开代码（VS）
- 通过dotnet安装net core MySQL插件，命令：`dotnet add package  MySql.Data.EntityFrameworkCore`
- 通过`dotnet run`运行项目，浏览器访问：https://localhost:5001 。

# 数据库

## 用户表

字段：

- id
- name
- password
- phone
- address
- role

建表语句：

```sql
CREATE TABLE `User` (
`id`  int NOT NULL AUTO_INCREMENT PRIMARY KEY,
`name`  varchar(255) NOT NULL,
`password`  varchar(255) NOT NULL,
`phone`  varchar(255) NOT NULL,
`address`  varchar(255) NOT NULL,
`role`  varchar(255) NOT NULL
) DEFAULT CHARACTER SET=utf8;
```

## 商品表

字段：

- id
- name
- price
- count
- image
- status

建表语句：

```sql
CREATE TABLE `Product` (
`id`  int NOT NULL AUTO_INCREMENT PRIMARY KEY,
`name`  varchar(255) NOT NULL,
`price`  float NOT NULL,
`count`  int NOT NULL,
`image`  varchar(255) NOT NULL,
`status`  int NOT NULL
) DEFAULT CHARACTER SET=utf8;
```

## 订单表

字段：

- id
- status
- count
- buy_id
- pro_id

建表语句：

```sql
CREATE TABLE `Orderlist` (
`id`  int NOT NULL AUTO_INCREMENT PRIMARY KEY,
`status`  int NOT NULL,
`count`  int NOT NULL,
`buy_id`  int NOT NULL,
`pro_id`  int NOT NULL,
CONSTRAINT `order_buy_fk_id` FOREIGN KEY (`buy_id`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT `order_pro_fk_id` FOREIGN KEY (`pro_id`) REFERENCES `product` (`id`) ON DELETE SET NULL ON UPDATE CASCADE
) DEFAULT CHARACTER SET=utf8;
```

## 购物车表

字段：

- id
- count
- buy_id
- pro_id

建表语句：

```sql
CREATE TABLE `Cart` (
`id`  int NOT NULL AUTO_INCREMENT PRIMARY KEY,
`count`  int NOT NULL,
`buy_id`  int NOT NULL,
`pro_id`  int NOT NULL,
CONSTRAINT `cart_buy_fk_id` FOREIGN KEY (`buy_id`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT `cart_pro_fk_id` FOREIGN KEY (`pro_id`) REFERENCES `product` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) DEFAULT CHARACTER SET=utf8;
```

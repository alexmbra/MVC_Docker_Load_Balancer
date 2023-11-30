CREATE DATABASE LBProdutosdb;

USE LBProdutosdb;

DROP TABLE IF EXISTS `LBProdutos`;

CREATE TABLE `LBProdutos` (
`ProdutoId` INT AUTO_INCREMENT,
`Nome` VARCHAR(80) NOT NULL,
`Categoria` VARCHAR(50) NOT NULL,
`Preco` DECIMAL(10,2) NOT NULL,
PRIMARY KEY (`ProdutoId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

LOCK TABLES `LBProdutos` WRITE;
INSERT INTO `LBProdutos` VALUES(1,'Caneta','Material Escolar','6.50');
INSERT INTO `LBProdutos` VALUES(2,'Estojo','Material Escolar','3.40');
INSERT INTO `LBProdutos` VALUES(3,'Borracha','Material Escolar','2.50');
UNLOCK TABLES;
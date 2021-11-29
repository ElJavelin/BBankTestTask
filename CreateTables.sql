CREATE TABLE Category
(
	CategoryName nvarchar (60) NOT NULL,
	CategotyDescription nvarchar (128) DEFAULT 'Нет описания',

	PRIMARY KEY(CategoryName)
);

CREATE TABLE Product
(
	ProductID int IDENTITY NOT NULL,
	ProductName nvarchar (60) NOT NULL,
	CategoryName nvarchar (60) NOT NULL DEFAULT 'Не установлено',
	ProductDescription nvarchar (128) DEFAULT 'Нет описания',
	ProductPrice decimal (5,3) DEFAULT 0 NOT NULL,
	ProductGenaralNote nvarchar (128) DEFAULT 'Нет примечания',
	ProductSpeciallNote nvarchar (128) DEFAULT 'Нет примечания',

	PRIMARY KEY(ProductID),
	FOREIGN KEY (CategoryName) REFERENCES Category (CategoryName) ON DELETE SET DEFAULT
);

INSERT INTO Category
VALUES
('Еда', 'Гастрономия'),
('Вкусности', 'Деликатессы'),
('Вода', 'Жидкости');

INSERT INTO Product (ProductName, CategoryName, ProductDescription, ProductPrice, ProductGenaralNote, ProductSpeciallNote)
VALUES
('Селедка', 'Еда', 'Селедка соленая', 10.00, 'Акция', 'Пересоленая'),
('Тушенка', 'Еда', 'Тушенка говяжая', 20.000, 'Вкусная', 'Жилы'),
('Сгущенка', 'Вкусности', 'В банках', 30.000, 'С ключом', 'Вкусная'),
('Квас', 'Вода', 'В бутылках', 15.000, 'Вятский', 'Тёплый');
CREATE TABLE Category
(
	CategoryName nvarchar (60) NOT NULL,
	CategotyDescription nvarchar (128) DEFAULT '��� ��������',

	PRIMARY KEY(CategoryName)
);

CREATE TABLE Product
(
	ProductID int IDENTITY NOT NULL,
	ProductName nvarchar (60) NOT NULL,
	CategoryName nvarchar (60) NOT NULL DEFAULT '�� �����������',
	ProductDescription nvarchar (128) DEFAULT '��� ��������',
	ProductPrice decimal (5,3) DEFAULT 0 NOT NULL,
	ProductGenaralNote nvarchar (128) DEFAULT '��� ����������',
	ProductSpeciallNote nvarchar (128) DEFAULT '��� ����������',

	PRIMARY KEY(ProductID),
	FOREIGN KEY (CategoryName) REFERENCES Category (CategoryName) ON DELETE SET DEFAULT
);

INSERT INTO Category
VALUES
('���', '�����������'),
('���������', '�����������'),
('����', '��������');

INSERT INTO Product (ProductName, CategoryName, ProductDescription, ProductPrice, ProductGenaralNote, ProductSpeciallNote)
VALUES
('�������', '���', '������� �������', 10.00, '�����', '�����������'),
('�������', '���', '������� �������', 20.000, '�������', '����'),
('��������', '���������', '� ������', 30.000, '� ������', '�������'),
('����', '����', '� ��������', 15.000, '�������', 'Ҹ����');
﻿--1.1 Выбрать в таблице Orders заказы, которые были доставлены после
--6 мая 1998 года (колонка ShippedDate) включительно и которые
--доставлены с ShipVia >= 2. Формат указания даты должен быть
--верным при любых региональных настройках, согласно
--требованиям статьи “Writing International Transact-SQL Statements”
--в Books Online раздел “Accessing and Changing Relational Data
--Overview”. Этот метод использовать далее для всех заданий.
--Запрос должен высвечивать только колонки OrderID, ShippedDate
--и ShipVia.
--Пояснить почему сюда не попали заказы с NULL-ом в колонке
--ShippedDate. 
select OrderID, ShippedDate, ShipVia
from Northwind.Orders
where ShippedDate >= {d'1998-05-06'} 
and ShipVia >= 2;

--1.2 Написать запрос, который выводит только недоставленные заказы
--из таблицы Orders. В результатах запроса высвечивать для
--колонки ShippedDate вместо значений NULL строку ‘Not Shipped’ –
--использовать системную функцию CASЕ. Запрос должен
--высвечивать только колонки OrderID и ShippedDate.
select OrderID, ShippedDate = 
case when ShippedDate is NULL then 'Not Shipped' end
from Northwind.Orders 
where ShippedDate is NULL

--1.3 Выбрать в таблице Orders заказы, которые были доставлены после
--6 мая 1998 года (ShippedDate) не включая эту дату или которые
--еще не доставлены. В запросе должны высвечиваться только
--колонки OrderID (переименовать в Order Number) и ShippedDate
--(переименовать в Shipped Date). В результатах запроса
--высвечивать для колонки ShippedDate вместо значений NULL
--строку ‘Not Shipped’, для остальных значений высвечивать дату в
--формате по умолчанию.
select OrderID AS 'Order Number', 'ShippedDate' = 
case when ShippedDate is NULL then 'Not Shipped' end
from Northwind.Orders 
where ShippedDate > {d'1998-05-06'} OR ShippedDate IS NULL

--2 Использование операторов IN, DISTINCT, ORDER BY, NOT
--2.1 Выбрать из таблицы Customers всех заказчиков, проживающих в
--USA и Canada. Запрос сделать с только помощью оператора IN.
--Высвечивать колонки с именем пользователя и названием страны
--в результатах запроса. Упорядочить результаты запроса по имени
--заказчиков и по месту проживания.
select ContactName, Country 
from Northwind.Customers 
where Country in ('USA', 'CANADA')
order by ContactName, Country

--2.2 Выбрать из таблицы Customers всех заказчиков, не проживающих
--в USA и Canada. Запрос сделать с помощью оператора IN.
--Высвечивать колонки с именем пользователя и названием страны
--в результатах запроса. Упорядочить результаты запроса по имени
--заказчиков.
select ContactName, Country 
from Northwind.Customers 
where Country not in ('USA', 'CANADA')
order by ContactName, Country

--2.3 Выбрать из таблицы Customers все страны, в которых проживают
--заказчики. Страна должна быть упомянута только один раз и список
--отсортирован по убыванию. Не использовать предложение GROUP
--BY. Высвечивать только одну колонку в результатах запроса.
select distinct Country 
from Northwind.Customers 
where Country is not NULL
order by Country desc

--3 Использование оператора BETWEEN, DISTINCT
--Title: 10 – Queries to Database Error! Unknown document
--property name.
--Saved: May 29, 2017
--© EPAM Systems, 2017 Page: 4/11
--3.1 Выбрать все заказы (OrderID) из таблицы Order Details (заказы не
--должны повторяться), где встречаются продукты с количеством от
--3 до 10 включительно – это колонка Quantity в таблице Order
--Details. Использовать оператор BETWEEN. Запрос должен
--высвечивать только колонку OrderID.
select distinct OrderID 
from Northwind.[Order Details]
where Quantity BETWEEN 3 and 10

--3.2 Выбрать всех заказчиков из таблицы Customers, у которых
--название страны начинается на буквы из диапазона b и g.
--Использовать оператор BETWEEN. Проверить, что в результаты
--запроса попадает Germany. Запрос должен высвечивать только
--колонки CustomerID и Country и отсортирован по Country.
select CostumerID, Country --не компилится твой костюмер
from Northwind.Customers
Where Country BETWEEN 'b*' and 'h*'
order by Country, CustomerID

--3.3 Выбрать всех заказчиков из таблицы Customers, у которых
--название страны начинается на буквы из диапазона b и g, не
--используя оператор BETWEEN. С помощью опции “Execution Plan”
--определить какой запрос предпочтительнее 3.2 или 3.3 – для этого
--надо ввести в скрипт выполнение текстового Execution Plan-a для
--двух этих запросов, результаты выполнения Execution Plan надо
--ввести в скрипт в виде комментария и по их результатам дать ответ
--на вопрос – по какому параметру было проведено сравнение.
--Запрос должен высвечивать только колонки CustomerID и Country
--и отсортирован по Country.
SET SHOWPLAN_TEXT ON;
GO

select CustomerID, Country 
from Northwind.Customers                          
where Country > 'b*' AND Country < 'h*'					 
order by Country;
GO

SET SHOWPLAN_TEXT OFF;
GO
	--Результат ниже, по второму параметру
	--Sort(ORDER BY:([Northwind].[Northwind].[Customers].[Country] ASC))
    --Clustered Index Scan(OBJECT:([Northwind].[Northwind].[Customers].[PK_Customers]), WHERE:([Northwind].[Northwind].[Customers].[Country]>N'b*' AND [Northwind].[Northwind].[Customers].[Country]<N'h*'))

--4 Использование оператора LIKE
--4.1 В таблице Products найти все продукты (колонка ProductName), где
--встречается подстрока 'chocolade'. Известно, что в подстроке
--'chocolade' может быть изменена одна буква 'c' в середине - найти
--все продукты, которые удовлетворяют этому условию. Подсказка:
--результаты запроса должны высвечивать 2 строки.
select ProductName 
from Northwind.Products
where ProductName like '%cho_olade%'

--5 Использование агрегатных функций (SUM, COUNT)
--5.1 Найти общую сумму всех заказов из таблицы Order Details с учетом
--количества закупленных товаров и скидок по ним. Результат
--округлить до сотых и высветить в стиле 1 для типа данных money.
--Скидка (колонка Discount) составляет процент из стоимости для
--данного товара. Для определения действительной цены на 
--проданный продукт надо вычесть скидку из указанной в колонке
--UnitPrice цены. Результатом запроса должна быть одна запись с
--одной колонкой с названием колонки 'Totals'.
select CONVERT(NVARCHAR, CAST(ROUND(SUM(UnitPrice * (1 - Discount) * Quantity), 2) AS MONEY), 1) AS Totals
from Northwind.[Order Details]

--5.2 По таблице Orders найти количество заказов, которые еще не были
--доставлены (т.е. в колонке ShippedDate нет значения даты
--доставки). Использовать при этом запросе только оператор
--COUNT. Не использовать предложения WHERE и GROUP.
select COUNT(*) - COUNT(ShippedDate) as 'Not Shipped'
from Northwind.Orders

--5.3 По таблице Orders найти количество различных покупателей
--(CustomerID), сделавших заказы. Использовать функцию COUNT и
--не использовать предложения WHERE и GROUP.
select COUNT(CustomerID) as 'Customers'
from Northwind.Orders

--6 Явное соединение таблиц, самосоединения, использование
--агрегатных функций и предложений GROUP BY и HAVING
--6.1 По таблице Orders найти количество заказов с группировкой по
--годам. В результатах запроса надо высвечивать две колонки c
--названиями Year и Total. Написать проверочный запрос, который
--вычисляет количество всех заказов.
select YEAR(OrderDate) as 'Year', Count(CustomerID) as 'Total'
from Northwind.Orders 
group by YEAR(OrderDate)

select count(CustomerID) as 'Total Orders'
from Northwind.Orders

--6.2 По таблице Orders найти количество заказов, cделанных каждым
--продавцом. Заказ для указанного продавца – это любая запись в
--таблице Orders, где в колонке EmployeeID задано значение для
--данного продавца. В результатах запроса надо высвечивать
--колонку с именем продавца (Должно высвечиваться имя
--полученное конкатенацией LastName & FirstName. Эта строка
--LastName & FirstName должна быть получена отдельным запросом
--в колонке основного запроса. Также основной запрос должен
--использовать группировку по EmployeeID.) с названием колонки
--‘Seller’ и колонку c количеством заказов высвечивать с названием
--'Amount'. Результаты запроса должны быть упорядочены по
--убыванию количества заказов.
select COUNT(CustomerID) as 'Amount', --переписать на один запрос
	(select LastName + FirstName
	from Northwind.Employees
	where Employees.EmployeesID = Orders.EmployeeID) as 'Seller'
from Northwind.Orders
Group by EmployeeID
Order by Count(CustomerID) DESC

--6.3 По таблице Orders найти количество заказов, cделанных каждым
--продавцом и для каждого покупателя. Необходимо определить это
--только для заказов сделанных в 1998 году. В результатах запроса
--надо высвечивать колонку с именем продавца (название колонки
--‘Seller’), колонку с именем покупателя (название колонки 
--‘Customer’) и колонку c количеством заказов высвечивать с
--названием 'Amount'. В запросе необходимо использовать
--специальный оператор языка T-SQL для работы с выражением
--GROUP (Этот же оператор поможет выводить строку “ALL” в
--результатах запроса). Группировки должны быть сделаны по
--ID продавца и покупателя. Результаты запроса должны быть
--упорядочены по продавцу, покупателю и по убыванию количества
--продаж. В результатах должна быть сводная информация по
--продажам. Т.е. в резульирующем наборе должны присутствовать
--дополнительно к информации о продажах продавца для каждого
--покупателя следующие строчки:
--Seller Customer Amount
--ALL ALL <общее число продаж>
--<имя> ALL <число продаж для данного продавца>
--ALL <имя> <число продаж для данного покупателя>
--<имя> <имя> <число продаж данного продавца для даннного покупателя>
SELECT CASE	
			WHEN EmployeeID IS NULL
			THEN 'ALL'
			ELSE (SELECT LastName + ' ' +FirstName
					FROM Northwind.Employees
							WHERE Employees.EmployeeID = OrderTable.EmployeeID)
							END AS 'Seller',
			CASE 
				WHEN CustomerID IS NULL
				THEN 'ALL'
				ELSE (SELECT ContactName
						FROM Northwind.Customers
								WHERE Customers.CustomerID = OrderTable.CustomerID)
						END AS 'Customer',
						Amount
	FROM (SELECT EmployeeID, CustomerID, COUNT(*) AS Amount
				FROM Northwind.Orders
				WHERE YEAR(ShippedDate) = 1998
			GROUP BY EmployeeID, CustomerID) AS OrderTable
	ORDER BY Seller, Customer, Amount DESC

--6.4 Найти покупателей и продавцов, которые живут в одном городе.
--Если в городе живут только один или несколько продавцов или
--только один или несколько покупателей, то информация о таких
--покупателя и продавцах не должна попадать в результирующий
--набор. Не использовать конструкцию JOIN. В результатах запроса
--необходимо вывести следующие заголовки для результатов
--запроса: ‘Person’, ‘Type’ (здесь надо выводить строку ‘Customer’
--или ‘Seller’ в завимости от типа записи), ‘City’. Отсортировать
--результаты запроса по колонке ‘City’ и по ‘Person’.
(SELECT ContactName AS Person, 'Customer' AS 'Type', City
	FROM Northwind.Customers
	WHERE City IN (SELECT City 
					FROM Northwind.Customers 
					GROUP BY City 
					HAVING COUNT(*) > 2))
UNION ALL
(SELECT FirstName + ' ' + LastName AS Person, 'Seller' AS 'Type', City
	FROM Northwind.Employees
	WHERE City IN (SELECT City 
					FROM Northwind.Employees 
					GROUP BY City 
					HAVING COUNT(*) > 2))
ORDER BY City, Person

--6.5 Найти всех покупателей, которые живут в одном городе. В запросе
--использовать соединение таблицы Customers c собой -
--самосоединение. Высветить колонки CustomerID и City. Запрос не
--должен высвечивать дублируемые записи. Для проверки написать
--запрос, который высвечивает города, которые встречаются более
--одного раза в таблице Customers. Это позволит
--высвечены имена из колонки LastName. Высвечены ли все
--продавцы в этом запросе?
SELECT DISTINCT A.CustomerID, A.City
  FROM Northwind.Customers AS A
       INNER JOIN Northwind.Customers AS B
	   ON A.City = B.City
	   AND A.City = 'London'

SELECT City
  FROM Northwind.Customers
 GROUP BY City
HAVING COUNT(*) > 2

--7 Использование Inner JOIN
--7.1 Определить продавцов, которые обслуживают регион 'Western'
--(таблица Region). Результаты запроса должны высвечивать два
--поля: 'LastName' продавца и название обслуживаемой территории
--('TerritoryDescription' из таблицы Territories). Запрос должен
--использовать JOIN в предложении FROM. Для определения связей
--между таблицами Employees и Territories надо использовать
--графические диаграммы для базы Northwind.
SELECT LastName, TerritoryDescription
  FROM Northwind.Employees AS Empl
       INNER JOIN Northwind.EmployeeTerritories AS EmplTerr
	   ON Empl.EmployeeID = EmplTerr.EmployeeID
	   INNER JOIN Northwind.Territories AS Terr
	   ON EmplTerr.TerritoryID = Terr.TerritoryID
	   INNER JOIN Northwind.Region
	   ON Terr.RegionID = Region.RegionID
	   WHERE Region.RegionDescription = 'Western'

--8 Использование Outer JOIN
--8.1 Высветить в результатах запроса имена всех заказчиков из
--таблицы Customers и суммарное количество их заказов из таблицы
--Orders. Принять во внимание, что у некоторых заказчиков нет
--заказов, но они также должны быть выведены в результатах
--запроса. Упорядочить результаты запроса по возрастанию
--количества заказов.
SELECT A.ContactName, B.Amount AS 'Customers Count'
  FROM
       (SELECT ContactName, CustomerID
          FROM Northwind.Customers
         GROUP BY CustomerID, ContactName) AS A
	   LEFT JOIN
	   (SELECT COUNT(CustomerID) AS Amount, CustomerID
	      FROM Northwind.Orders
		 GROUP BY CustomerID) AS B
	   ON A.CustomerID = B.CustomerID

--9 Использование подзапросов
--9.1 Высветить всех поставщиков колонка CompanyName в таблице
--Suppliers, у которых нет хотя бы одного продукта на складе
--(UnitsInStock в таблице Products равно 0). Использовать
--вложенный SELECT для этого запроса с использованием
--оператора IN. Можно ли использовать вместо оператора IN
--оператор '=' ?
SELECT CompanyName
   FROM Northwind.Suppliers
  WHERE SupplierID IN
		(SELECT SupplierID
		   FROM Northwind.Products
		   WHERE UnitsInStock = 0)

--10 Коррелированный запрос
--10.1Высветить всех продавцов, которые имеют более 150 заказов.
--Использовать вложенный коррелированный SELECT.
SELECT LastName + ' ' + FirstName AS Seller
  FROM Northwind.Employees
 WHERE EmployeeID IN
	   (SELECT EmployeeID
	      FROM Northwind.Orders
		 WHERE EmployeeID IN
						(SELECT EmployeeID
						   FROM Northwind.Orders
							 GROUP BY EmployeeID
							 HAVING COUNT(EmployeeID) >= 150))

--11 Использование EXISTS
--11.1Высветить всех заказчиков (таблица Customers), которые не имеют
--ни одного заказа (подзапрос по таблице Orders). Использовать
--коррелированный SELECT и оператор EXISTS.
SELECT ContactName
  FROM Northwind.Customers
 WHERE NOT EXISTS
	   (SELECT CustomerID
	      FROM Northwind.Orders
	     WHERE Customers.CustomerID = Orders.CustomerID)

--12 Использование строковых функций
--12.1Для формирования алфавитного указателя Employees высветить
--из таблицы Employees список только тех букв алфавита, с которых
--начинаются фамилии Employees (колонка LastName ) из этой
--таблицы. Алфавитный список должен быть отсортирован по
--возрастанию.
SELECT LEFT(LastName, 1) AS EmployeesAlphabet
  FROM Northwind.Employees
 ORDER BY LastName

--13 Разработка функций и процедур
--13.1Написать процедуру, которая возвращает самый крупный заказ
--для каждого из продавцов за определенный год. В результатах не
--может быть несколько заказов одного продавца, должен быть
--только один и самый крупный. В результатах запроса должны быть
--выведены следующие колонки: колонка с именем и фамилией
--продавца (FirstName и LastName – пример: Nancy Davolio), номер
--заказа и его стоимость. В запросе надо учитывать Discount при
--продаже товаров. Процедуре передается год, за который надо
--сделать отчет, и количество возвращаемых записей. Результаты
--запроса должны быть упорядочены по убыванию суммы заказа.
--Процедура должна быть реализована с использованием оператора
--SELECT и БЕЗ ИСПОЛЬЗОВАНИЯ КУРСОРОВ. Название функции
--соответственно GreatestOrders. Необходимо продемонстрировать
--использование этих процедур. Также помимо демонстрации
--вызовов процедур в скрипте Query.sql надо написать отдельный
--ДОПОЛНИТЕЛЬНЫЙ проверочный запрос для тестирования
--правильности работы процедуры GreatestOrders. Проверочный
--запрос должен выводить в удобном для сравнения с результатами
--работы процедур виде для определенного продавца для всех его
--заказов за определенный указанный год в результатах следующие
--колонки: имя продавца, номер заказа, сумму заказа. Проверочный
--запрос не должен повторять запрос, написанный в процедуре, - он 
--должен выполнять только то, что описано в требованиях по нему.
--ВСЕ ЗАПРОСЫ ПО ВЫЗОВУ ПРОЦЕДУР ДОЛЖНЫ БЫТЬ
--НАПИСАНЫ В ФАЙЛЕ Query.sql – см. пояснение ниже в разделе
--«Требования к оформлению».
EXEC Northwind.GreatestOrders 1997, 10
EXEC Northwind.GreatestOrders 1998, 3
SELECT Emp.FirstName + ' ' + LastName AS EmployeeName, Orders.OrderID,
	   OrdDet.UnitPrice * (1 - OrdDet.Discount) AS Cost
  FROM Northwind.Employees AS Emp  
       INNER JOIN Northwind.Orders
	   ON Emp.EmployeeID = Orders.EmployeeID
	   INNER JOIN Northwind.[Order Details] AS OrdDet
	   ON Orders.OrderID = OrdDet.OrderID
 WHERE YEAR(Orders.OrderDate) = 1998
	   AND Emp.EmployeeID = 3
 ORDER BY Cost DESC

--13.2Написать процедуру, которая возвращает заказы в таблице Orders,
--согласно указанному сроку доставки в днях (разница между
--OrderDate и ShippedDate). В результатах должны быть
--возвращены заказы, срок которых превышает переданное
--значение или еще недоставленные заказы. Значению по
--умолчанию для передаваемого срока 35 дней. Название
--процедуры ShippedOrdersDiff. Процедура должна высвечивать
--следующие колонки: OrderID, OrderDate, ShippedDate,
--ShippedDelay (разность в днях между ShippedDate и OrderDate),
--SpecifiedDelay (переданное в процедуру значение). Необходимо
--продемонстрировать использование этой процедуры.
EXEC Northwind.ShippedOrdersDiff 10
EXEC Northwind.ShippedOrdersDiff -- здесь падает

--13.3Написать процедуру, которая высвечивает всех подчиненных
--заданного продавца, как непосредственных, так и подчиненных его
--подчиненных. В качестве входного параметра функции
--используется EmployeeID. Необходимо распечатать имена
--подчиненных и выровнять их в тексте (использовать оператор
--PRINT) согласно иерархии подчинения. Продавец, для которого
--надо найти подчиненных также должен быть высвечен. Название
--процедуры SubordinationInfo. В качестве алгоритма для решения
--этой задачи надо использовать пример, приведенный в Books
--Online и рекомендованный Microsoft для решения подобного типа
--задач. Продемонстрировать использование процедуры.
EXEC Northwind.SubordinationInfo 2 -- что за proc?

--13.4 Написать функцию, которая определяет, есть ли у продавца
--подчиненные. Возвращает тип данных BIT. В качестве входного
--параметра функции используется EmployeeID. Название функции
--IsBoss. Продемонстрировать использование функции для всех
--продавцов из таблицы Employees.
IF NOT EXISTS
(SELECT *
   FROM dbo.SYSOBJECTS
  WHERE NAME = 'Bosses'
        AND xType = 'U')

CREATE TABLE #Bosses
(EmployeeID int,
   HaveBoss BIT)

SELECT EmployeeID, Northwind.IsBoss(EmployeeID) AS HaveBoss
  FROM Northwind.Employees;

SELECT EmployeeID, HaveBoss
FROM #Bosses
DROP TABLE #Bosses
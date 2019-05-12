declare @dt date = '20171001'

--update ExcelBooks set 
--	AccountName = replace(replace(replace(AccountName,' ','<>'),'><',''),'<>',' ')
--where dt>='20170601'

update ExcelBooks set 
  CurrencyId='USD'
, Splus=Credits
, Sminus=Debits
where 
CurrencyId='GLAM';

update ExcelBooks set 
CurrencyId='GBP'
where 
CurrencyId='DPA';

INSERT INTO [dbo].[Banks] ([Name])
SELECT DISTINCT
  e.[BankName]
FROM 
	[ExcelBooks] e
WHERE not exists(select b.Id from [dbo].[Banks] b where b.Name=e.BankName) and dt >= @dt;

insert into AccountTypes (Name)
select distinct
 e.AccountTypeName
from ExcelBooks e
where not exists(select a.Id from AccountTypes a where a.Name=e.AccountTypeName) and dt >= @dt;


UPDATE ExcelBooks set
  BankId=(select top 1 b.Id from Banks b where b.Name=ExcelBooks.BankName)
, AccountTypeId=(select top 1 a.Id from AccountTypes a where a.Name=ExcelBooks.AccountTypeName)
, TransactionTypeId = (select t.Id from TransactionTypes t where t.Name=ExcelBooks.TrType);

UPDATE ExcelBooks set
  AccountTypeId=(select top 1 a.Id from AccountTypes a where a.Name='Other')
where AccountTypeId is null;

insert into Accounts(BankId,Name, CurrencyId, AccountTypeId)
select distinct
  e.BankId
, e.AccountName
, e.CurrencyId
, e.AccountTypeId
from ExcelBooks e
where not exists(select a.Id from Accounts a where a.BankId=e.BankId and a.Name=e.AccountName and a.CurrencyId=e.CurrencyId and a.AccountTypeId=e.AccountTypeId) and dt >= @dt;

UPDATE ExcelBooks set
  AccountId=(select top 1 a.Id from Accounts a 
			 where 
			 a.BankId=ExcelBooks.BankId 
			 and a.Name=ExcelBooks.AccountName 
			 and a.CurrencyId=ExcelBooks.CurrencyId 
			 and a.AccountTypeId=ExcelBooks.AccountTypeId);

/* Update Rates start */

UPDATE ExcelBooks set Splus = Credits WHERE Credits is not null and Splus is null and CurrencyId='USD'; 

UPDATE ExcelBooks set
  Sminus = isnull([Debits],(0))+isnull([Charges],(0))
WHERE
  (Debits is not null or Charges is not null) and Sminus is null
and CurrencyId='USD'  

UPDATE ExcelBooks
SET Splus = ROUND(Credits * (
			SELECT TOP 1 CASE CHARINDEX(ExcelBooks.CurrencyId, r1.CurrencyPairId)
					WHEN 1
						THEN r1.Rate
					ELSE 1 / r1.Rate
					END
			FROM CurrencyPairRates r1
			WHERE CHARINDEX(ExcelBooks.CurrencyId, r1.CurrencyPairId) > 0
				AND r1.RateDate = (
					SELECT MAX(r2.RateDate)
					FROM CurrencyPairRates r2
					WHERE r2.RateDate <= ExcelBooks.Dt
					)
				AND CHARINDEX('USD', r1.CurrencyPairId) > 0
			), 2)
WHERE Credits IS NOT NULL
	AND Splus IS NULL
	AND CurrencyId <> 'USD'

UPDATE ExcelBooks
SET Sminus = ROUND((isnull([Debits], (0)) + isnull([Charges], (0))) * (
			SELECT TOP 1 CASE CHARINDEX(ExcelBooks.CurrencyId, r1.CurrencyPairId)
					WHEN 1
						THEN r1.Rate
					ELSE 1 / r1.Rate
					END
			FROM CurrencyPairRates r1
			WHERE CHARINDEX(ExcelBooks.CurrencyId, r1.CurrencyPairId) > 0
				AND r1.RateDate = (
					SELECT MAX(r2.RateDate)
					FROM CurrencyPairRates r2
					WHERE r2.RateDate <= ExcelBooks.Dt
					)
				AND CHARINDEX('USD', r1.CurrencyPairId) > 0
			), 2)
WHERE (
		Debits IS NOT NULL
		OR Charges IS NOT NULL
		)
	AND Sminus IS NULL
	AND CurrencyId <> 'USD'

/* Update Rates end */
  


/*delete
  FROM [Transactions]
  where dt >= @dt;*/

INSERT INTO [dbo].[Transactions]
           ([Dt]
           ,[BankId]
           ,[AccountId]
           ,[TransactionTypeId]
           ,[CurrencyId]
           ,[Credits]
           ,[Debits]
           ,[Charges]
           ,[FromTo]
           ,[Description]
           ,[UsdCredits]
           ,[UsdDebits]
           ,[Report]
           ,[TransactionDate])
SELECT 
	[Dt]
	,[BankId]
	,[AccountId]
	,[TransactionTypeId]
	,[CurrencyId]
	,[Credits]
	,[Debits]
	,[Charges]
	,REPLACE(REPLACE([FromTo], CHAR(13), ''), CHAR(10), '')
	,REPLACE(REPLACE([Description], CHAR(13), ''), CHAR(10), '')
    ,[Splus]
    ,[Sminus]
    ,[Report]
	,[Dt]
  FROM [dbo].[ExcelBooks]
  /*WHERE Dt >= @dt;*/

update ExcelBooks set AccountId = 118 where AccountId=186
update Transactions set AccountId = 118 where AccountId=186

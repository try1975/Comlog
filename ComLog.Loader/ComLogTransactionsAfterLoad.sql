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
, Splus=Credits*1.55
, Sminus=Debits*1.55
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

delete
  FROM [Transactions]
  where dt >= @dt;

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
  WHERE Dt >= @dt;

update ExcelBooks set AccountId = 118 where AccountId=186
update Transactions set AccountId = 118 where AccountId=186


/*
-- fix account name for bank of cyprus
declare @BankId int
declare @AccountId int
declare @NewAccountId int

select @BankId = b.Id
from Banks b
where b.name='BANK OF CYPRUS'
--select @BankId

select @AccountId = a.Id
from Accounts a
where a.Name='INSIGNIA INTERNATIONAL  (CYP)' and a.CurrencyId='USD' and a.BankId=@BankId
select @NewAccountId = a.Id
from Accounts a
where a.Name='INSIGNIA INTERNATIONAL (CYP)' and a.CurrencyId='USD' and a.BankId=@BankId

if (@AccountId is not null) and (@NewAccountId is not null) and (@BankId is not null)
begin
update Transactions set AccountId=@NewAccountId where BankId=@BankId and AccountId=@AccountId
update ExcelBooks set AccountId=@NewAccountId where BankId=@BankId and AccountId=@AccountId
delete from Accounts where Id=@AccountId
select * from Transactions t where t.BankId=@BankId and t.AccountId=@AccountId
end
else 
select @AccountId

set @AccountId = null
set @NewAccountId = null

select @AccountId = a.Id
from Accounts a
where a.Name='INSIGNIA INTERNATIONAL  (CYP)' and a.CurrencyId='EUR' and a.BankId=@BankId
select @NewAccountId = a.Id
from Accounts a
where a.Name='INSIGNIA INTERNATIONAL (CYP)' and a.CurrencyId='EUR' and a.BankId=@BankId

if (@AccountId is not null) and (@NewAccountId is not null) and (@BankId is not null)
begin
update Transactions set AccountId=@NewAccountId where BankId=@BankId and AccountId=@AccountId
update ExcelBooks set AccountId=@NewAccountId where BankId=@BankId and AccountId=@AccountId
delete from Accounts where Id=@AccountId
select * from Transactions t where t.BankId=@BankId and t.AccountId=@AccountId
end
else 
select @AccountId

set @AccountId = null
set @NewAccountId = null
set @BankId = null
*/
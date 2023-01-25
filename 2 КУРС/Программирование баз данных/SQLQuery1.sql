Create table Parts
(
 PartID int primary key,
 PartName char (100) not null,
 HolderName char (100) not null,
 CostOfThePart int not null,
 ClientID int not null,
);

Create table PriceHistory
(
   PartID int primary key,
   Date1 date not null,
   HolderName char (100) not null,
   Price int not null,
);

Create table Worker
(
   IDOfTheWorker int primary key,
   EmployeeFullName char (100) not null,
   DateOfJobAcceptance date not null,
   DateOfCompletionOfWork date not null,
   HourlyRate smallint not null,
);

Create table Transactions
(
    ClientID int primary key,
 ThetransactionID int  not null,
 TransactionDate datetime2 not null,
 IDOfTheWorker int not null,
);

Create table Client
(
   ClientID int primary key,
   ClientFullName char(100) not null,
   DateOfBirth date not null,
   TheAddressOfTheClient char(200) not null,
   CustomerNumber bigint not null,

);

Create table Holder
(
   HolderName char(100) primary key,
   AddressOfTheSupplier char(100) not null,
   StandNumber bigint not null,
);
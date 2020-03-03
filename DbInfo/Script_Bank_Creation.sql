/*
	Database Project - BankDb

	Author: Eduardo Sanchez
*/

-- CREATION OF TABLES

drop table bankbranch cascade constraints;
drop table bankemployee cascade constraints;
drop table bankcustomer cascade constraints;
drop table accounttypes cascade constraints;
drop table bankaccount cascade constraints;
drop table banktransaction cascade constraints;

commit;

create table bankbranch (
branchid number (4) not null,
branchname varchar2 (15) not null,
address varchar2 (50) not null,
province varchar2 (2) not null,
postalcode varchar2 (6) not null,
phone number (10) not null,
    constraint branch_branchid_pk primary key(branchid),
    constraint branch_province_ck
                CHECK (province IN ('BC', 'ON', 'QC', 'NS', 'PE', 'NL', 'NB', 'MB', 'SK', 'AB', 'YT', 'NT', 'NU'))
);

create table bankemployee (
empid number (4) not null,
branchid number (4) not null,
name varchar2 (10) not null,
address varchar2 (50) not null,
province varchar2 (2) not null,
postalcode varchar2 (6) not null,
phone number (10) not null,
email varchar2 (20) not null,
managerid number (4),
    constraint bankemployee_empid_pk primary key(empid),
    constraint bankemployee_branchid_fk foreign key(branchid) references bankbranch(branchid)
);

create table bankcustomer (
customerid number (6) not null,
name varchar2 (10) not null,
sinnumber number (10),
address varchar2 (30) not null,
city varchar2 (20) not null,
province varchar2 (2) not null,
postalcode varchar2 (6) not null,
phone number (10) not null,
email varchar2 (20) not null,
password varchar2(15) not null,
    constraint bankcustomer_customerid_pk primary key(customerid),
    CONSTRAINT bankcustome_password_ch CHECK (password like('________%'))
);

create table accounttypes (
typeid number (3),
typename varchar2 (20) NOT NULL,
    constraint accounttypes_typeid_pk primary key(typeid)
);

create table bankaccount (
accountnumber number (10) not null,
customerid number (6) not null,
branchid number (4) not null,
managerid number (4) not null,
accounttype number (4) not null,
balance number (15,2) default 0,
    constraint bankaccount_accountnumber_pk primary key(accountnumber),
    constraint bankaccount_customerid_fk foreign key(customerid) references bankcustomer(customerid),
    constraint bankaccount_managerid_fk foreign key(managerid) references bankemployee(empid),
    constraint bankaccount_branchid_fk foreign key(branchid) references bankbranch(branchid),
    constraint bankaccount_accounttype_fk foreign key(accounttype) references accounttypes(typeid)
);

create table banktransaction(
transactionId number(4),
customerid number(6),
accountnumber number(10),
amount number(10,2) default 0 not null,
transaction_date DATE DEFAULT SYSDATE NOT NULL,
	constraint bt_transactionId_pk primary key(transactionId),
	constraint bt_accountnumber_fk foreign key(accountnumber) references bankaccount(accountnumber),
	constraint bt_customerid_fk foreign key(customerid) references bankcustomer(customerid)
);

commit;

-- Creation of sequences

DROP SEQUENCE bank_cutomers_seq;

CREATE SEQUENCE bank_cutomers_seq
INCREMENT BY 1
START WITH 1
NOCACHE;

DROP SEQUENCE bank_accounts_seq;

CREATE SEQUENCE bank_accounts_seq
INCREMENT BY 1
START WITH 1
NOCACHE;

DROP SEQUENCE bank_transaction_seq;

CREATE SEQUENCE bank_transaction_seq
INCREMENT BY 1
START WITH 1000
NOCACHE;

DROP SEQUENCE bank_accountype_seq;

CREATE SEQUENCE bank_accountype_seq
INCREMENT BY 1
START WITH 1
NOCACHE;

-- creation of indexes

DROP INDEX customers_pass_idx;

CREATE INDEX customers_pass_idx 
ON bankcustomer (name, password);


DROP INDEX account_balance_idx;

CREATE INDEX account_balance_idx 
ON bankaccount (balance);


-- Populate the tables
INSERT INTO bankbranch VALUES (0001, 'Sheppard', '5000 Yonge Street, Toronto', 'ON', 'M1N1M1', 1111111111);
INSERT INTO bankbranch VALUES (0002, 'Bloor', '200 Bloor Street East, Toronto', 'ON', 'M1C3C2', 2222222222);
INSERT INTO bankbranch VALUES (0003, 'Montreal', '50 Main Street, Montreal', 'QC', 'B2CR3R', 3333333333);
INSERT INTO bankbranch VALUES (0004, 'University', '100 University Avenue, Calgary', 'AB', 'A1B2B3', 4444444444);
INSERT INTO bankbranch VALUES (0005, 'Finch', '150 Finch Avenue, Halifax', 'NS', 'N1S1H3', 5555555555);
INSERT INTO bankbranch VALUES (0006, 'Eglinton', '100 Eglinton Avenue East, Fredericton', 'NB', 'A1B2B3', 6666666666);
INSERT INTO bankbranch VALUES (0007, 'Lawrence', '100 Lawrence Avenue West, Vancouver', 'BC', 'A1B2B3', 7777777777);
INSERT INTO bankbranch VALUES (0008, 'Queen', '100 Queen Street West, Victoria', 'BC', 'A1B2B3', 8888888888);
INSERT INTO bankbranch VALUES (0009, 'King', '100 King Street East, Toronto', 'ON', 'A1B2B3', 9999999999);
INSERT INTO bankbranch VALUES (0010, 'Dundas', '100 Dundas Street East, Montreal', 'QC', 'A1B2B3', 1010101010); --10

INSERT INTO bankemployee VALUES (001, 0001, 'Bob Burn', '5051 Yonge Street, Toronto', 'ON', 'M1N1M1', 1234567891, 'bob@bank.ca', 004);
INSERT INTO bankemployee VALUES (002, 0001, 'Ally', '2 Bloor Street West, Toronto', 'ON', 'M1C3C2', 2323232323, 'ally@bank.ca', 004);
INSERT INTO bankemployee VALUES (003, 0002, 'Charlie', '10 Main Street, Montreal', 'QC', 'B2CR3R', 3213213213, 'charlie@bank.ca', 001);
INSERT INTO bankemployee VALUES (004, 0003, 'Jane', '100 University Avenue, Calgary', 'AB', 'A1B2B3', 4445556664, 'jane@bank.ca', 004);
INSERT INTO bankemployee VALUES (005, 0003, 'Jane', '1 University Avenue, Halifax', 'NS', 'A1B2B3', 4445556664, 'jane@bank.ca', 004);
INSERT INTO bankemployee VALUES (006, 0003, 'Sean', '15 Finch Avenue, Halifax', 'NS', 'A1B2B3', 4445556664, 'sean@bank.ca', 003);
INSERT INTO bankemployee VALUES (007, 0003, 'John', '1000 Eglinton Avenue East, Fredericton', 'NB', 'A1B2B3', 4445556664, 'john@bank.ca', 003);
INSERT INTO bankemployee VALUES (008, 0003, 'Frank', '50 Lawrence Avenue West, Vancouver', 'BC', 'A1B2B3', 4445556664, 'frank@bank.ca', 001);
INSERT INTO bankemployee VALUES (009, 0003, 'Shania', '40 Queen Street West, Victoria', 'BC', 'A1B2B3', 4445556664, 'shania@bank.ca', 002);
INSERT INTO bankemployee VALUES (010, 0003, 'Ariana', '9 King Street East, Toronto', 'ON', 'A1B2B3', 4445556664, 'ariana@bank.ca', 001);
INSERT INTO bankemployee VALUES (011, 0003, 'Justin', '50 Dundas Street East, Montreal', 'QC', 'A1B2B3', 4445556664, 'justin@bank.ca', 001);--11

INSERT INTO bankcustomer VALUES (bank_cutomers_seq.NEXTVAL, 'Andre B', 9998889666, '55 Sheppard Avenue', 'Toronto', 'ON', 'M4N5T5', 4445552222, 'andre@behar.ca','mypass15');
INSERT INTO bankcustomer VALUES (bank_cutomers_seq.NEXTVAL, 'Elisa C', 7778889999, '2 Bloor Street West', 'Toronto', 'ON', 'M1C3C2', 4445552222, 'elisa@yahoo.ca','ThisIsSparta');
INSERT INTO bankcustomer VALUES (bank_cutomers_seq.NEXTVAL, 'Thalyta V', 5552223333, '10 Main Street', 'Montreal', 'QC', 'B2CR3R', 4445552222, 'thalyta@gmail.ca','PC_Master_88');
INSERT INTO bankcustomer VALUES (bank_cutomers_seq.NEXTVAL, 'Elton V', 3332225555, '100 University Avenue', 'Calgary', 'AB', 'M4N5T5', 4445552222, 'elton@gmail.ca','29021990clt');
INSERT INTO bankcustomer VALUES (bank_cutomers_seq.NEXTVAL, 'Marcos L', 4567416854, '450 Eglinton Ave East', 'Toronto', 'ON', 'M1L8G5', 6024587415, 'ingmarco@gmail.com','HolaMundo');
INSERT INTO bankcustomer VALUES (bank_cutomers_seq.NEXTVAL, 'Eduardo S', 8887779898, '45 Eglinton Ave East', 'Fredericton', 'NB', 'M1L8G5', 6024587415, 'ingmarco@gmail.com','HolaMundo');
INSERT INTO bankcustomer VALUES (bank_cutomers_seq.NEXTVAL, 'Paulo C', 4558774545, '1 Lawrence Avenue West', 'Vancouver', 'BC', 'M1L8G5', 6024587415, 'ingmarco@gmail.com','HolaMundo');
INSERT INTO bankcustomer VALUES (bank_cutomers_seq.NEXTVAL, 'Daison H', 2223336565, '4110 Queen Street West', 'Victoria', 'BC', 'M1L8G5', 6024587415, 'ingmarco@gmail.com','HolaMundo');
INSERT INTO bankcustomer VALUES (bank_cutomers_seq.NEXTVAL, 'Carla M', 4445351212, '75 King Street East', 'Toronto', 'ON', 'M1L8G5', 6024587415, 'ingmarco@gmail.com','HolaMundo');
INSERT INTO bankcustomer VALUES (bank_cutomers_seq.NEXTVAL, 'Maria S', 4562551414, '900 Dundas Street East', 'Montreal', 'QC', 'M1L8G5', 6024587415, 'ingmarco@gmail.com','HolaMundo');--10

INSERT INTO accounttypes VALUES (bank_accountype_seq.NEXTVAL, 'Checking');
INSERT INTO accounttypes VALUES (bank_accountype_seq.NEXTVAL, 'Savings');
INSERT INTO accounttypes VALUES (bank_accountype_seq.NEXTVAL, 'Investment'); --3

INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 1, 0001, 001, 001, 13450.43);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 1, 0001, 001, 002, 8756.77);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 2, 0002, 002, 001, 11899.89);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 5, 0002, 002, 002, 5999.00);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 2, 0002, 002, 003, 45237.78);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 3, 0003, 003, 001, 9786.12);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 4, 0004, 004, 001, 4500);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 4, 0004, 004, 003, 17345.48);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 1, 0004, 004, 003, 17345.48);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 7, 0004, 004, 003, 17345.48);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 6, 0004, 004, 003, 17345.48);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 8, 0004, 004, 003, 17345.48);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 9, 0004, 004, 003, 17345.48);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 3, 0004, 004, 003, 17345.48);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 9, 0004, 004, 003, 17345.48);
INSERT INTO bankaccount VALUES (bank_accounts_seq.NEXTVAL, 8, 0004, 004, 003, 17345.48);--16

INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 1, 1, 13450.43, TO_DATE('15-JAN-15'));
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 1, 2, 8756.77, TO_DATE('04-MAR-17'));
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 2, 3, 11899.89, TO_DATE('02-JUL-00'));
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 5, 4, 5999.00, TO_DATE('20-APR-15'));
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 2, 5, 45237.78, TO_DATE('08-SEP-15'));
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 3, 6, 9786.12, TO_DATE('23-OCT-18'));
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 4, 7, 4500, DEFAULT);
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 4, 8, 17345.48, DEFAULT);
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 1, 9, 17345.48, DEFAULT);
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 7, 10, 17345.48, DEFAULT); --10
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 6, 11, 17345.48, DEFAULT);
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 8, 12, 17345.48, DEFAULT);
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 9, 13, 17345.48, DEFAULT);
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 3, 14, 17345.48, DEFAULT);
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 9, 15, 17345.48, DEFAULT);
INSERT INTO banktransaction VALUES(bank_transaction_seq.NEXTVAL, 8, 16, 17345.48, DEFAULT); --16

commit;

--STORED FUNCTIONS

--Function
--Returns the total balance of all the accounts of a customer
CREATE OR REPLACE FUNCTION SUM_TOTALBALANCE_SF(
    cus_id IN NUMBER)
    RETURN NUMBER
IS
	total NUMBER(10,2);
BEGIN
    SELECT SUM(balance)
        INTO total
        FROM bankcustomer bc JOIN bankaccount ba
        USING (customerid)
        JOIN accounttypes at
        ON at.typeid = ba.accounttype
        WHERE customerid = cus_id;
        
    IF total IS NULL THEN
        total := 0;
    END IF;               
    RETURN total;
END;

--TEST
/*
SELECT customerid, name, SUM_TOTALBALANCE_SF(customerid) "Total balance" 
FROM bankcustomer;
*/
--Function
--Return the number of transactions of a customer
CREATE OR REPLACE FUNCTION NUM_OF_TRST_SF(
    customer_id IN NUMBER)
    RETURN NUMBER
IS
	lv_return_num NUMBER(10);
BEGIN
    SELECT COUNT(transactionid)
        INTO lv_return_num
        FROM banktransaction
        WHERE customerid = customer_id;
        
    RETURN lv_return_num;
END;

--TEST
/*
SELECT customerid, name ,NUM_OF_TRST_SF(customerid)
FROM bankcustomer;
*/
--STORED PROCEDURES

--Procedure that returns a record with information of one customer 
CREATE OR REPLACE PROCEDURE GET_CUSTOMER_INFO
(customer_id IN NUMBER, cur_customer OUT SYS_REFCURSOR)
IS
BEGIN
    OPEN cur_customer FOR
    SELECT * FROM bankcustomer
    WHERE customerid = customer_id;
END;
/*
--TEST
DECLARE
	cur_customer SYS_REFCURSOR;
	rec_cus bankcustomer%rowtype;
BEGIN
    GET_CUSTOMER_INFO(1, cur_customer);
    
    LOOP      
        FETCH cur_customer INTO rec_cus;
        EXIT WHEN cur_customer%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE (rec_cus.name);        
    END LOOP;
    
    CLOSE cur_customer;
END;
*/
--Procedure to get information of accounts of a customer 
CREATE OR REPLACE PROCEDURE GET_ACCOUNTS_SP
(customer_id IN NUMBER, cur_customer OUT SYS_REFCURSOR, total OUT NUMBER)
AS
BEGIN
    total := SUM_TOTALBALANCE_SF(customer_id);
    
    OPEN cur_customer FOR
    SELECT accountnumber, managerid, balance, typename 
    FROM bankcustomer bc JOIN bankaccount ba
    USING (customerid)
    JOIN accounttypes at
    ON at.typeid = ba.accounttype
    WHERE customerid = customer_id;    
END;
/*
--TEST
DECLARE
	cur_acc SYS_REFCURSOR;
	TOTAL NUMBER(10,2);
	TYPE account_rec IS RECORD(
    	accountnumber NUMBER(6), 
    	managerid NUMBER(6), 
    	balance NUMBER(10,2), 
    	typename VARCHAR2(30)
	);
	rec_acc account_rec;
BEGIN
    GET_ACCOUNTS_SP(1, cur_acc, TOTAL);

    LOOP       
        FETCH cur_acc INTO rec_acc;
        EXIT WHEN cur_acc%NOTFOUND;
        DBMS_OUTPUT.PUT_LINE(rec_acc.accountnumber || ' ' || rec_acc.balance);     
    END LOOP;   
    CLOSE cur_acc;
    
    DBMS_OUTPUT.PUT_LINE('Total: ' || TOTAL);
END;
*/
--Procedure to send number of transactions to web application
CREATE OR REPLACE PROCEDURE GET_TOTAL_TRST_SP
(customer_id IN NUMBER, total OUT NUMBER)
AS
BEGIN
    total := NUM_OF_TRST_SF(customer_id);
END;
/*
--TEST
DECLARE
    lv_cutomerid_num bankcustomer.customerid%Type := 6;
    lv_number_num NUMBER(10);
BEGIN
    GET_TOTAL_TRST_SP(lv_cutomerid_num, lv_number_num);
    DBMS_OUTPUT.PUT_LINE('Transactions: ' || lv_number_num);
END;
*/
--Procedure to incert a new Transaction
CREATE OR REPLACE PROCEDURE INSERT_TRANSACTION_SP
(customerid IN NUMBER, accountnumber IN NUMBER, amount IN NUMBER, isValid OUT NUMBER)
IS
BEGIN
	INSERT INTO banktransaction
	VALUES (bank_transaction_seq.NEXTVAL, customerid, accountnumber, amount, DEFAULT);
    COMMIT;
    isValid := 1;
EXCEPTION
    WHEN OTHERS THEN
        isValid := 0;       
END;

--TEST
/*
DECLARE
	lv_act_num banktransaction.accountnumber%TYPE := 1;
	lv_cus_num banktransaction.customerid%TYPE := 1;
	lv_amount_num banktransaction.amount%TYPE := 1000;
	lv_balance_num bankaccount.balance%TYPE;
    lv_isSuccessful_num NUMBER(5);
BEGIN
	SELECT balance 
		INTO lv_balance_num
		FROM bankaccount
		WHERE accountnumber = lv_act_num
		AND customerid = lv_cus_num;

	DBMS_OUTPUT.PUT_LINE('OLD: ' || lv_balance_num);

	INSERT_TRANSACTION_SP(lv_cus_num, lv_act_num, lv_amount_num, lv_isSuccessful_num);

    IF lv_isSuccessful_num = 1 THEN 
        DBMS_OUTPUT.PUT_LINE('Transaction succes: True');
    ELSE
        DBMS_OUTPUT.PUT_LINE('Transaction succes: False');
    END IF;

	SELECT balance 
		INTO lv_balance_num
		FROM bankaccount
		WHERE accountnumber = lv_act_num
		AND customerid = lv_cus_num;

	DBMS_OUTPUT.PUT_LINE('NEW: ' || lv_balance_num);
END;
*/

--Procedure to create a new Account Type
CREATE OR REPLACE PROCEDURE NEW_ACCOUNTTYPE_SP
(typeName IN VARCHAR2)
IS
BEGIN
    INSERT INTO accounttypes
    VALUES (bank_accountype_seq.NEXTVAL, typeName);
    COMMIT;
END;

--TEST

DECLARE
	lv_typeName_txt accounttypes.typename%TYPE := 'Deposits';
	lv_type_rec accounttypes%ROWTYPE;
BEGIN 
	NEW_ACCOUNTTYPE_SP(lv_typeName_txt);
	SELECT typeid, typename
		INTO lv_type_rec.typeid, lv_type_rec.typename
		FROM accounttypes
		WHERE typeid = (SELECT MAX(typeid) FROM accounttypes);
	DBMS_OUTPUT.PUT_LINE('New Account type has the next information');
	DBMS_OUTPUT.PUT_LINE('ID: ' || lv_type_rec.typeid || ' Name: ' || lv_type_rec.typename);
END;

--Procedure to crate a new Bank Account
CREATE OR REPLACE PROCEDURE NEW_ACCOUNT_SP
(customer_id IN NUMBER, branch_id IN NUMBER, manager_id IN NUMBER, account_type IN NUMBER, initial_balance IN NUMBER, isValid OUT NUMBER)
IS
    lv_initial NUMBER(1);
BEGIN

    INSERT INTO bankaccount
    VALUES(bank_accounts_seq.NEXTVAL,customer_id,branch_id,manager_id,account_type, DEFAULT);
    COMMIT;

    isValid := 1;

    IF initial_balance > 0 THEN
        INSERT_TRANSACTION_SP(customer_id, bank_accounts_seq.CURRVAL, initial_balance, lv_initial);

        IF lv_initial = 1 THEN
            isValid := 1;            
        ELSE
            isValid := 0;            
        END IF;

    END IF;

EXCEPTION
    WHEN OTHERS THEN
        isValid := 0;
END;
/*
--TEST
DECLARE
	lv_customerId_num bankaccount.customerid%TYPE := 1;
	lv_branchId_num bankaccount.branchid%TYPE := 1;
	lv_managerId_num bankaccount.managerid%TYPE := 1;
	lv_accType_num bankaccount.accounttype%TYPE := 2;
	lv_balance_num bankaccount.balance%TYPE := 700;
	isValid_num NUMBER(2);
    lv_new_acc_number bankaccount.accountnumber%TYPE;
    lv_new_balance bankaccount.balance%TYPE;
BEGIN
	NEW_ACCOUNT_SP(lv_customerId_num, lv_branchId_num, lv_managerId_num, lv_accType_num, lv_balance_num, isValid_num);
	
	IF isValid_num = 1 THEN
        DBMS_OUTPUT.PUT_LINE('Inser was successful');
        SELECT accountnumber, balance
            INTO lv_new_acc_number, lv_new_balance
            FROM bankaccount            
        	WHERE accountnumber = (SELECT MAX(accountnumber) FROM bankaccount);      
    ELSE
        isValid_num := 0;
        DBMS_OUTPUT.PUT_LINE('Inser failed');    
    END IF;
    
    DBMS_OUTPUT.PUT_LINE('New acccount id: ' || lv_new_acc_number || ' with initial balance of: $' || lv_new_balance);
END;
*/
-- TRIGGERS

-- Update balance of one account after a transaction is insert
CREATE OR REPLACE TRIGGER update_balance_trg
	AFTER INSERT ON banktransaction
DECLARE
	lv_act_num banktransaction.accountnumber%TYPE;
	lv_amount_num banktransaction.amount%TYPE;
	lv_cus_num banktransaction.customerid%TYPE;
BEGIN
	SELECT accountnumber, amount, customerid
		INTO lv_act_num, lv_amount_num, lv_cus_num
		FROM banktransaction
		WHERE transactionId = (SELECT MAX(transactionId) from banktransaction);

	UPDATE bankaccount
		SET balance = balance + lv_amount_num
		WHERE accountnumber = lv_act_num 
		AND customerid = lv_cus_num;
END;
/*
--TEST
DECLARE
	lv_cusId_num banktransaction.customerid%TYPE := 2;
	lv_act_num banktransaction.accountnumber%TYPE := 3;
	lv_amount_num banktransaction.accountnumber%TYPE := 2800;
	lv_date_date banktransaction.transaction_date%TYPE := TO_DATE('14-SEP-18');
	lv_balance_num bankaccount.balance%TYPE;
BEGIN

	SELECT balance 
		INTO lv_balance_num
		FROM bankaccount
		WHERE accountnumber = lv_act_num
		AND customerid = lv_cusId_num;

	DBMS_OUTPUT.PUT_LINE('Balance before transaction of '|| lv_amount_num || ' is: ' || lv_balance_num);
	
	INSERT INTO banktransaction
	VALUES (bank_transaction_seq.NEXTVAL, lv_cusId_num, lv_act_num, lv_amount_num, lv_date_date);
	COMMIT;

	SELECT balance 
		INTO lv_balance_num
		FROM bankaccount
		WHERE accountnumber = lv_act_num
		AND customerid = lv_cusId_num;

	DBMS_OUTPUT.PUT_LINE('Balance after transaction of '|| lv_amount_num || ' is: ' || lv_balance_num);
END;
*/
select * from accounttypes;
select * from bankaccount;
select * from bankbranch;
select * from bankcustomer;
select * from bankemployee;
select * from banktransaction order by transactionid;
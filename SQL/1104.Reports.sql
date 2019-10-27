/****** Скрипт для заливки отчетов ******/
delete from Report;
insert into Report (Report_Name, Report_File) values('Розрахунковий лист', 'SalaryList.rdlc');
insert into Report (Report_Name, Report_File) values('Сальдо на початок місяця', 'SalBalance.rdlc');
insert into Report (Report_Name, Report_File) values('Відомість по заробітній платі', 'SalStatement.rdlc');
insert into Report (Report_Name, Report_File) values('Укрупнений звіт (4 в одному)', 'Consolidate.rdlc');
insert into Report (Report_Name, Report_File) values('Відомість нарахуваннь', 'AccrStatement.rdlc');
insert into Report (Report_Name, Report_File) values('Підсумкова відомість нарахуваннь', 'AccrConsolidate.rdlc');
insert into Report (Report_Name, Report_File) values('Відомість виплат', 'PaymentStatement.rdlc');
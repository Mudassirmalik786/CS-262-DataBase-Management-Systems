declare @i int = 1;
while (@i <= 101)
	begin
		waitfor delay '00:00:01'

		Insert into Table_1 values (@i, rand()*100);
	set @i = @i+1;
end
delete from Table_1 
Insert into Table_1 values (0, 0);
		update Table_1 set Students = @i
		update Table_1 set Marks = RAND() * 100;
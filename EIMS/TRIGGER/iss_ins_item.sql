CREATE TRIGGER iss_ins_item ON iss2  
AFTER INSERT AS DECLARE @itcd BIGINT, @qty MONEY, @refund VARCHAR  
SELECT @itcd = it_cd, @qty = qty, @refund = refund FROM inserted  
BEGIN  
 IF @refund = 'N'  
  BEGIN  
   UPDATE item SET iss_stk = iss_stk + @qty, cl_stk = cl_stk - @qty WHERE it_cd= @itcd  
  END  
 ELSE  
  BEGIN  
   UPDATE item SET rec_stk = rec_stk + @qty, cl_stk = cl_stk + @qty WHERE it_cd = @itcd  
  END  
END
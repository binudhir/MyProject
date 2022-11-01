CREATE TRIGGER iss_del_item ON iss2    
AFTER DELETE AS DECLARE @itcd BIGINT, @qty MONEY, @refund VARCHAR    
SELECT @itcd = it_cd, @qty = qty, @refund = refund FROM deleted    
BEGIN    
 IF @refund = 'N'    
  BEGIN    
   UPDATE item SET iss_stk = iss_stk - @qty, cl_stk = cl_stk + @qty WHERE it_cd= @itcd    
  END    
 ELSE    
  BEGIN    
   UPDATE item SET rec_stk = rec_stk - @qty, cl_stk = cl_stk - @qty WHERE it_cd = @itcd    
  END    
END